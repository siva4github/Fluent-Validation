namespace FluentAPI.Entities.Interfaces
{
    // We have an interface that represents a 'contact',
    // for example in a CRM system. All contacts must have a name and email.
    public interface IContact
    {
         string Name {get;set;}
         string Email {get;set;}
    }
}