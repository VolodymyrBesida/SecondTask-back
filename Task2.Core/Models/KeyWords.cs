namespace Task2.Core.Models;

public static class KeyWords
{
    public static string OrKey => " or ";
    public static string OrValue => " | ";
    public static string AndKey => " and ";
    //TODO: should take more time to investigate how to work with regex to realize 'and' feature

    public static string Check(string pattern)
    {
        if (pattern.Contains(OrKey))
            return pattern.Replace(OrKey, OrValue);
        return pattern;
    }
}
