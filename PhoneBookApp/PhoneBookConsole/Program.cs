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

            Contact contact = new Contact() {ContactID = 1,Name = "Ali Ben Ali",Mobil = "53565765",Email = "ali@gmail.com"};

            List<Contact> contacts = new List<Contact>()
            {
                new Contact() { ContactID = 1, Name = "Ali Ben Ali", Mobil = "53565765", Email = "ali@gmail.com" },
                new Contact() { ContactID = 2, Name = "maram tatoui", Mobil = "222222222", Email = "maram@gmail.com" },
                new Contact() { ContactID = 1, Name = "Foued ben ", Mobil = "53565765", Email = "ali@gmail.com" },
                new Contact() { ContactID = 1, Name = "Ali Ben Ali", Mobil = "53565765", Email = "ali@gmail.com" }

            };
        }
    }
}
