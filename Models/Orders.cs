namespace CodeMasters.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string University { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? CreateAt { get; set; } = DateTime.Now;
        public DateTime? StartAtDate { get; set; }
        public DateTime? DeadLineDate { get; set; }

      
    }
}
