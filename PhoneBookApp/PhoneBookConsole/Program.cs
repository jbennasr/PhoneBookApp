using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {


            var newcContact = Contact.AddContact("Fathi ben rabah", "666666666", "fathi@gmail.com");


            var contacts = Contact.GetAllContacts();
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.ContactID} {contact.Name}");
            }
            
           


            Console.ReadKey();
        }
    }
}
