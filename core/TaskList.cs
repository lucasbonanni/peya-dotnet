using core.interfaces;

namespace core
{
    /// <summary>
    /// The task list.
    /// </summary>
    public class TaskList : ITaskList
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        public IEnumerable<TaskItem> Tasks { get; set; }
    }
}