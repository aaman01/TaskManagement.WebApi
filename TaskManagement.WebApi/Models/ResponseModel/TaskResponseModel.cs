namespace TaskManagement.WebApi.Models.ResponseModel
{
    public class TaskResponseModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the task title.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the task description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the task duedate.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the task completed status.
        /// </summary>
        /// <value>
        /// The is completed.
        /// </value>
        public bool IsCompleted { get; set; }
    }
}
