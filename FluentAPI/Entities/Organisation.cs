using FluentAPI.Entities.Interfaces;

namespace FluentAPI.Entities
{
    // An organisation is another type of contact,
    // with a name and the address of their HQ.
    public class Organisation : IContact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Headquarters { get; set; }
    }
}