namespace ContactBook.DTOs
{
    public class ContactDTO
    {
        public class ContactCreateDTO
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? HomePhone { get; set; }
            public string? MobilePhone { get; set; }
            public string? OfficePhone { get; set; }
            public string Address { get; set; }
        }

        public class ContactUpdateDTO
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

        public class ContactDeleteDTO
        {
            public int Id { get; set; }
        }

        public class ContactsDTO : ContactUpdateDTO
        { 
        }
    }
}
