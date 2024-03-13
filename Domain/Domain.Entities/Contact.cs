using System;

namespace Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public bool Default { get; set; }
    }
}
