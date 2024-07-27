using System.Text.RegularExpressions;
using Task2.Core.Interfaces;
using Task2.Core.Models;

namespace Task2.Core.Services;
public class FileSearchService : ISearchableService
{

    public async Task<SearchResponse> GetMatchedResultAsync(SearchRequest request)
    {
        string regexPattern = KeyWords.Check(request.Argument);
        List<Task> tasks = new();
        SearchResponse search = new();

        foreach (var file in request.FilePaths)
        {
            if (!File.Exists(file))
                throw new InvalidOperationException($"File not found: {file}");

            tasks.Add(Task.Run(async () =>
            {
                search.Response.AddRange(await this.SearchFileAsync(file, regexPattern));
            }));
        }
        await Task.WhenAll(tasks);
        return search;
    }

    private async Task<List<SearchResult>> SearchFileAsync(string filePath, string regexPattern)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            List<SearchResult> result = new();

            while ((line = await reader.ReadLineAsync()) != null)
                if (regex.IsMatch(line))
                    result.Add(new SearchResult($"File: {filePath}", $"Match: {line}"));
            return result;
        }
    }
}
