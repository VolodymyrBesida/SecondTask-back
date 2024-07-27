namespace Task2.Core.Models;

public class SearchRequest
{
    public string Argument { get; set; }
    public string[] FilePaths { get; set; }
}

public class SearchResult
{
    public string FileName { get; set; }
    public string Value { get; set; }
    public SearchResult(string name, string value)
    {
        FileName = name;
        Value = value;
    }
}

public class SearchResponse
{
    public List<SearchResult> Response { get; set; }
    public SearchResponse()
    {
        Response = new List<SearchResult>();
    }
}
