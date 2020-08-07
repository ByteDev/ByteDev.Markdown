using System.Text;

namespace ByteDev.Markdown.Helper
{
    internal static class StringBuilderExtensions
    {
        public static void AppendTableHeaderDivider(this StringBuilder source, int columns)
        {
            for (var i = 0; i < columns; i++)
                source.Append("| --- ");

            source.AppendLine("|");
        }
    }
}