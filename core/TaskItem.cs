using core;
using core.interfaces;

namespace core
{
    /// <summary>
    /// The task item.
    /// </summary>
    public class TaskItem: ITaskItem
    {
        public Guid id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public int Priority { get; set; }

        public bool CompletionStatus { get; set; }

        //public Category Category { get; set; }

        public string Notes { get; set; }

        public TaskList TaskList { get; set; }

    }
}
