using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ContactBook.Models
{
    public class Contact:IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int BirthDate { get; set; }

        public virtual ICollection<PhoneNumber> Phones { get; set; }

    }
    public class PhoneNumber:IEntity
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string Number { get; set; }

        public virtual Contact Contact { get; set; }
    }

    public class ContactRepository
    {
        private readonly ContactContext context;

        public ContactRepository(ContactContext _context)
        {
            context = _context;
        }

        public ICollection<Contact> GetContacts()
        {
            return context.Contacts.ToList();
        }
        public ICollection<Contact> GetContacts(Expression<Func<Contact, bool>> selector)
        {
            return context.Contacts.Where(selector).ToList();
        }

        public void AddContact(Contact contact)
        {
            context.Contacts.Add(contact);
        } 
    }
    public class ContactFormater : IFormated
    {
        private Contact contact;

        public ContactFormater(Contact _contact)
        {
            contact = _contact;
        }
        string IFormated.HtmlFormat()
        {
            throw new NotImplementedException();
        }
    }
}