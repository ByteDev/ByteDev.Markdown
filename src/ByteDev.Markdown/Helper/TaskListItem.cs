namespace ByteDev.Markdown.Helper
{
    public class TaskListItem
    {
        public string Text { get; }

        public bool IsChecked { get; }

        public TaskListItem(string text) : this(text, false)
        {
        }

        public TaskListItem(string text, bool isChecked)
        {
            Text = text;
            IsChecked = isChecked;
        }
    }
}