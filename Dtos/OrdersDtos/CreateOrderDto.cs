namespace CodeMasters.Dtos.OrdersDtos
{
    public class CreateOrderDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string University { get; set; } = null!;
        public string Major { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;    
        public string Description { get; set; } = null!;
        public DateTime? CreateAt { get; set; } 
        public DateTime? StartAtDate { get; set; }
        public DateTime? DeadLineDate { get; set; }
    }
}
