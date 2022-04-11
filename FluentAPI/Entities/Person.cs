using FluentAPI.Entities.Interfaces;

namespace FluentAPI.Entities
{
    // A Person is a type of contact, with a name and a DOB.
    public class Person : IContact
    {
        public List<string> AddressLines { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}