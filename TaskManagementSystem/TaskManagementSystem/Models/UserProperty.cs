namespace TaskManagementSystem.Models
{
    public class UserProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string E_mail { get; set; }
        public string Password { get; set; }

        public List<TaskItem> tasks = new List<TaskItem>();
    }
}