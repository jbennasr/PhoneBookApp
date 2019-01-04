using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

            Contact contact = new Contact() {ContactID = contacts.Count + 1, Name = name, Mobil = mobile, Email = email };
            contacts.Add(contact);
            return contact;

        }

        public static List<Contact> GetAllContacts()
        {

            using (StreamReader data =File.OpenText(@"../../ListOfContact.json"))
            {

                var stringListOfContact = data.ReadToEnd();

                var ObjectsJsonList = JsonConvert.DeserializeObject<List<Contact>>(stringListOfContact);

                return ObjectsJsonList.OrderBy(c => c.Name).ToList();
            }
            


        }
    }
}
