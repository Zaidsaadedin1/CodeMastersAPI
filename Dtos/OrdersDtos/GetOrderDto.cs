namespace CodeMasters.Dtos.OrdersDtos
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? University { get; set; }
        public string? Major { get; set; }
        public string? PhoneNumber { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? StartAtDate { get; set; }
        public DateTime? DeadLineDate { get; set; }
    }
}
