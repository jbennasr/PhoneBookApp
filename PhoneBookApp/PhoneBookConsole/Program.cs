using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneBookConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
           
            var contacts = Contact.GetAllContacts();
            
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Name} {contact.Mobil} {contact.Email}");
            }



            Console.ReadKey();
        }
    }
}
