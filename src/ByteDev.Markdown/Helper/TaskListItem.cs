namespace ByteDev.Markdown.Helper
{
    /// <summary>
    /// Represensts an item in a task list.
    /// </summary>
    public class TaskListItem
    {
        /// <summary>
        /// Label text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Indicates if the item is checked.
        /// </summary>
        public bool IsChecked { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Markdown.Helper.TaskListItem" /> class.
        /// </summary>
        /// <param name="text">Item label text.</param>
        public TaskListItem(string text) : this(text, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Markdown.Helper.TaskListItem" /> class.
        /// </summary>
        /// <param name="text">Item label text.</param>
        /// <param name="isChecked">Indicates if the item is checked.</param>
        public TaskListItem(string text, bool isChecked)
        {
            Text = text;
            IsChecked = isChecked;
        }
    }
}