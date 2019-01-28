using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneBookConcole
{
    public class Services
    {
     
        public static bool IsDublicated(string name)
        {
            var contacts = Contact.GetContacts();
            foreach (var contact in contacts)
            {
                if (CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()) == contact.Name)
                {
                    return true;
                }
            }
            return false;
        }

       

        public static List<Contact> FindContact(string name)
        {
            var _name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
            var contacts = Contact.GetContacts();
            List<Contact> listFounded = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (_name.Substring(0, 3) == contact.Name.Substring(0,3))
                {
                    listFounded.Add(contact);
                }
            }
            Console.WriteLine($"{listFounded.Count} Contacts found");
            foreach (var c in listFounded)
            {
                Console.WriteLine(c.ToString());
            }
            return listFounded;
           
        }
    }
}
