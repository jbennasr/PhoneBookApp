using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookConsole
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Mobil { get; set; }
        public string Email { get; set; }

        public static Contact AddContact(string name, string mobile, string email)
        {
           var contacts = Contact.GetAllContacts();

            Contact contact = new Contact() { ContactID = contacts.Count + 1, Name = name, Mobil = mobile, Email = email };
            contacts.Add(contact);
            return contact;

        }

        public static List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>()
            {
                new Contact() { ContactID = 1, Name = "Ali Ben Ali", Mobil = "53565765", Email = "ali@gmail.com" },
                new Contact() { ContactID = 2, Name = "maram tatoui", Mobil = "222222222", Email = "maram@gmail.com" },
                new Contact() { ContactID = 3, Name = "Foued ben rabeh ", Mobil = "111111111", Email = "foued@gmail.com" },
                new Contact() { ContactID = 4, Name = "marouen mbarki", Mobil = "444444444", Email = "maouren@gmail.com" }
            };
            return contacts;

        }
    }
}
