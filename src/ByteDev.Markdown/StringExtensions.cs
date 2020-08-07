namespace ByteDev.Markdown
{
    internal static class StringExtensions
    {
        public static string TrimEndNewLine(this string source)
        {
            return source?.TrimEnd('\r', '\n');
        }
    }
}