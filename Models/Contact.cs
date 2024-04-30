namespace ContactBook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string? Address { get; set; }
    }
}
