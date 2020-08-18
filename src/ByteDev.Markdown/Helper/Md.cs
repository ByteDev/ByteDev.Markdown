using System;
using System.Collections.Generic;
using System.Text;

namespace ByteDev.Markdown.Helper
{
    /// <summary>
    /// Represents helper for creating markdown text.
    /// </summary>
    /// <remarks>
    /// Suports:
    /// Common Markdown: https://commonmark.org/
    /// Large parts of GitHub Flavored Markdown: https://guides.github.com/features/mastering-markdown/
    /// </remarks>
    public static class Md
    {
        /// <summary>
        /// Returns text as markdown italic.
        /// </summary>
        /// <param name="text">Text to make italic.</param>
        /// <returns>Markdown italic text.</returns>
        public static string Italic(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return $"*{text}*";
        }

        /// <summary>
        /// Returns text as markdown bold.
        /// </summary>
        /// <param name="text">Text to make bold.</param>
        /// <returns>Markdown bold text.</returns>
        public static string Bold(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return $"**{text}**";
        }

        /// <summary>
        /// Returns text as markdown strike through.
        /// </summary>
        /// <param name="text">Text to strike through.</param>
        /// <returns>Markdown strike through text.</returns>
        public static string Strike(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return $"~~{text}~~";
        }

        /// <summary>
        /// Returns text as markdown block quote.
        /// </summary>
        /// <param name="text">Text to make block quote.</param>
        /// <returns>Markdown block quote.</returns>
        public static string Blockquote(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return $"> {text}";
        }

        /// <summary>
        /// Returns a markdown horizontal rule.
        /// </summary>
        /// <returns>Markdown horizontal rule.</returns>
        public static string HorizontalRule()
        {
            return "---" + Environment.NewLine;
        }

        /// <summary>
        /// Returns text as a markdown header 1.
        /// </summary>
        /// <param name="text">Header text.</param>
        /// <returns>Markdown header.</returns>
        public static string Header1(string text)
        {
            return Header(text, 1);
        }

        /// <summary>
        /// Returns text as a markdown header 2.
        /// </summary>
        /// <param name="text">Header text.</param>
        /// <returns>Markdown header.</returns>
        public static string Header2(string text)
        {
            return Header(text, 2);
        }

        /// <summary>
        /// Returns text as a markdown header 3.
        /// </summary>
        /// <param name="text">Header text.</param>
        /// <returns>Markdown header.</returns>
        public static string Header3(string text)
        {
            return Header(text, 3);
        }

        /// <summary>
        /// Returns text as a markdown header 4.
        /// </summary>
        /// <param name="text">Header text.</param>
        /// <returns>Markdown header.</returns>
        public static string Header4(string text)
        {
            return Header(text, 4);
        }

        /// <summary>
        /// Returns text as a markdown header 5.
        /// </summary>
        /// <param name="text">Header text.</param>
        /// <returns>Markdown header.</returns>
        public static string Header5(string text)
        {
            return Header(text, 5);
        }

        /// <summary>
        /// Returns text as a markdown header 6.
        /// </summary>
        /// <param name="text">Header text.</param>
        /// <returns>Markdown header.</returns>
        public static string Header6(string text)
        {
            return Header(text, 6);
        }

        /// <summary>
        /// Returns text as markdown code.
        /// </summary>
        /// <param name="code">Code.</param>
        /// <returns>Markdown code.</returns>
        public static string Code(string code)
        {
            if (string.IsNullOrEmpty(code))
                return string.Empty;

            return $"`{code}`";
        }

        /// <summary>
        /// Returns a markdown code block.
        /// </summary>
        /// <param name="code">Code.</param>
        /// <returns>Markdown code block.</returns>
        public static string CodeBlock(string code)
        {
            return CodeBlock(code, null);
        }

        /// <summary>
        /// Returns a markdown code block.
        /// </summary>
        /// <param name="code">Code.</param>
        /// <param name="language">Code language. Often used for syntax highlighting.</param>
        /// <returns>Markdown code block.</returns>
        public static string CodeBlock(string code, string language)
        {
            if (string.IsNullOrEmpty(code))
                return string.Empty;

            if (language == null)
                language = string.Empty;

            return $"```{language}" + Environment.NewLine +
                   $"{code.TrimEndNewLine()}" + Environment.NewLine +
                   "```" + Environment.NewLine;
        }

        /// <summary>
        /// Returns a markdown link. Text for the link will be the <paramref name="uri" />.
        /// </summary>
        /// <param name="uri">Link uri (or path).</param>
        /// <returns>Markdown link.</returns>
        public static string Link(string uri)
        {
            return Link(uri, null);
        }

        /// <summary>
        /// Returns a markdown link.
        /// </summary>
        /// <param name="uri">Link URI (or path).</param>
        /// <param name="text">Text for the link.</param>
        /// <returns>Markdown link.</returns>
        public static string Link(string uri, string text)
        {
            if (string.IsNullOrEmpty(uri))
                return string.Empty;

            if (string.IsNullOrEmpty(text))
                return $"[{uri}]({uri})";

            return $"[{text}]({uri})";
        }

        /// <summary>
        /// Returns a markdown image. Alt text for the image will be "Image".
        /// </summary>
        /// <param name="uri">Image URI (or path).</param>
        /// <returns>Markdown image.</returns>
        public static string Image(string uri)
        {
            return Image(uri, null);
        }

        /// <summary>
        /// Returns a markdown image.
        /// </summary>
        /// <param name="uri">Image URI (or path).</param>
        /// <param name="altText">Alt text.</param>
        /// <returns>Markdown image.</returns>
        public static string Image(string uri, string altText)
        {
            if (string.IsNullOrEmpty(uri))
                return string.Empty;

            if (string.IsNullOrEmpty(altText))
                return $"![Image]({uri})";

            return $"![{altText}]({uri})";
        }

        /// <summary>
        /// Returns a markdown task list.
        /// </summary>
        /// <param name="items">Task list items.</param>
        /// <returns>Markdown task list.</returns>
        public static string TaskList(params TaskListItem[] items)
        {
            return TaskList(items as IEnumerable<TaskListItem>);
        }

        /// <summary>
        /// Returns a markdown task list.
        /// </summary>
        /// <param name="items">Task list items.</param>
        /// <returns>Markdown task list.</returns>
        public static string TaskList(IEnumerable<TaskListItem> items)
        {
            if (items == null)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var item in items)
                sb.AppendLine(TaskListItem(item));

            return sb.ToString();
        }

        /// <summary>
        /// Returns a markdown unordered list.
        /// </summary>
        /// <param name="items">List items.</param>
        /// <returns>Markdown unordered list.</returns>
        public static string UnorderedList(params object[] items)
        {
            return UnorderedList(items as IEnumerable<object>);
        }

        /// <summary>
        /// Returns a markdown unordered list.
        /// </summary>
        /// <param name="items">List items.</param>
        /// <returns>Markdown unordered list.</returns>
        public static string UnorderedList(IEnumerable<object> items)
        {
            if (items == null)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var item in items)
                sb.AppendLine($"* {item}");

            return sb.ToString();
        }

        /// <summary>
        /// Returns a markdown ordered list.
        /// </summary>
        /// <param name="items">List items.</param>
        /// <returns>Markdown ordered list.</returns>
        public static string OrderedList(params object[] items)
        {
            return OrderedList(items as IEnumerable<object>);
        }

        /// <summary>
        /// Returns a markdown ordered list.
        /// </summary>
        /// <param name="items">List items.</param>
        /// <returns>Markdown ordered list.</returns>
        public static string OrderedList(IEnumerable<object> items)
        {
            if (items == null)
                return string.Empty;

            var sb = new StringBuilder();
            var number = 1;

            foreach (var item in items)
            {
                sb.AppendLine($"{number}. {item}");
                number++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns a markdown table header.
        /// </summary>
        /// <param name="values">Header values.</param>
        /// <returns>Markdown table header.</returns>
        public static string TableHeader(params object[] values)
        {
            return TableHeader(values as IEnumerable<object>);
        }

        /// <summary>
        /// Returns a markdown table header.
        /// </summary>
        /// <param name="values">Header values.</param>
        /// <returns>Markdown table header.</returns>
        public static string TableHeader(IEnumerable<object> values)
        {
            if (values == null)
                return string.Empty;

            var sb = new StringBuilder();
            var cols = 0;

            foreach (var item in values)
            {
                sb.Append(sb.Length == 0 ? "| " : " ");
                sb.Append(item);
                sb.Append(" |");
                cols++;
            }

            if (sb.Length == 0)
                return string.Empty;

            sb.AppendLine();
            sb.AppendTableHeaderDivider(cols);

            return sb.ToString();
        }

        /// <summary>
        /// Returns a markdown table row.
        /// </summary>
        /// <param name="values">Row values.</param>
        /// <returns>Markdown table row.</returns>
        public static string TableRow(params object[] values)
        {
            return TableRow(values as IEnumerable<object>);
        }
        
        /// <summary>
        /// Returns a markdown table row.
        /// </summary>
        /// <param name="values">Row values.</param>
        /// <returns>Markdown table row.</returns>
        public static string TableRow(IEnumerable<object> values)
        {
            if (values == null)
                return string.Empty;

            var sb = new StringBuilder();

            foreach (var item in values)
                sb.Append($"| {item} ");

            if (sb.Length == 0)
                return string.Empty;

            sb.AppendLine("|");

            return sb.ToString();
        }

        private static string TaskListItem(TaskListItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var textValue = string.IsNullOrWhiteSpace(item.Text) ? string.Empty : $" {item.Text}";
            
            var chkValue = item.IsChecked ? "x" : " ";
            
            return $"- [{chkValue}]{textValue}";
        }

        private static string Header(string text, int level)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            if (level < 1)
                level = 1;

            var prefix = new string('#', level);

            return $"{prefix} {text}" + Environment.NewLine;
        }

        private static string GetIndent(int indent)
        {
            if (indent < 1)
                return string.Empty;

            return new string('\t', indent);
        }
    }
}