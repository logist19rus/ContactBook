using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContactBook.Models
{
    public class ContactContext:DbContext
    {
        public ContactContext() : base("ContactContext")
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> Phones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}