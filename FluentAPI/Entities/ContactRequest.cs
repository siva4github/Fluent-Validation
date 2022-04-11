using FluentAPI.Entities.Interfaces;

namespace FluentAPI.Entities
{
    // Our model class that we'll be validating.
    // This might be a request to send a message to a contact.
    public class ContactRequest
    {
        public IContact Contact { get; set; }
        public string MessageToSend { get; set; }
    }
}