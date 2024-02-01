namespace Building_a_User_s_and_Tasks_API.Models
{
    public class Tasks
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Assignee { get; set; }
        public DateTime DueDate { get; set; }
    }

}
