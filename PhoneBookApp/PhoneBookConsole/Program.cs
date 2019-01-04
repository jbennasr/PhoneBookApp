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

            //using (StreamWriter file = new StreamWriter(@"../../ListOfContact.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file,contacts);
            //}
            
           // var newcContact = Contact.AddContact("Fathi ben rabah", "666666666", "fathi@gmail.com");

           

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.ContactID} {contact.Name}");
            }


            Console.ReadKey();
        }
    }
}
