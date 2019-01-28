using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneBookConcole
{
    public class Contact
    {
        public int ContactID { get; set; }

        private string name;
        public string Name
        {
            get { return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()); }
            set { name = value; }
        }

        public string Mobile { get; set; }
        public string Email { get; set; }


        public static List<Contact> GetContacts()
        {
            using (StreamReader file = File.OpenText(@"../../ListOfContact.json"))
            {
                var stringListOFContact = file.ReadToEnd();
                var lisftDeserializeObject = JsonConvert.DeserializeObject<List<Contact>>(stringListOFContact);

                return lisftDeserializeObject.OrderBy(c => c.Name).ToList();
            }
        }

        //public static void CreateContact(string name, string mobile, string email)
        //{

        //    if (Services.IsDublicated(name) == true)
        //    {
        //        Console.WriteLine($"The Contact {name} exist you want to update it ?" +
        //                          $"Please press (Y/N)");
        //        var request = Console.ReadLine().ToUpper();
        //        if (request == "Y")
        //            UpdateContact(name, mobile, email);
               
        //        if (request == "N")
        //            CreateNewContact(name, mobile, email);
               



        //    }


        //}
        public static Contact CreateNewContact(string name, string mobile, string email)
        {
            var listContact = GetContacts();
            Contact newContact = new Contact()
            {
               // ContactID = Services.FindLastId() + 1,
                ContactID = listContact.Max(c => c.ContactID) +1,
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()),
                Mobile = mobile,
                Email = email

            };

            using (StreamWriter file = File.CreateText(@"../../ListOfContact.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                listContact.Add(newContact);
                serializer.Serialize(file, listContact);
            }
            Console.WriteLine($"New Contact Created : {newContact.ToString()}");
            return newContact;

        }

        public static Contact UpdateContact(string name, string mobile, string email)
        {

            var ListContact = GetContacts();
            var oldContact = Enumerable.FirstOrDefault<Contact>(ListContact, c => c.Name == name);

            var UpdatedContact = new Contact()
            {
                ContactID = oldContact.ContactID,
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()),
                Mobile = mobile,
                Email = email

            };

            using (StreamWriter file = File.CreateText(@"../../ListOfContact.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                ListContact.Add(UpdatedContact);
                ListContact.Remove(oldContact);
                serializer.Serialize(file, ListContact);
            }

            Console.WriteLine($"Contact Updated : {UpdatedContact.ToString()}");
            return UpdatedContact;


        }

        public static void RemoveContact(string name)
        {

            var ListContact = GetContacts();
            var removedContact = Enumerable.FirstOrDefault<Contact>(ListContact, c => c.Name == name);
            Console.WriteLine($"You are sure to delete {removedContact.Name} if yes please press (Y/N)");
            var request = Console.ReadLine().ToUpper();
            if (Services.IsDublicated(name) == true || request == "Y")
            {
                using (StreamWriter file = File.CreateText(@"../../ListOfContact.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    ListContact.Remove(removedContact);
                    serializer.Serialize(file, ListContact);
                }
                Console.WriteLine($"Contact Updated : {removedContact.ToString()}");
            }
            else
            {
                Console.WriteLine($"The Conatact {name} doesn't exist ");
            }

        }

        public override string ToString()
        {
            return $"Contact Name : {Name}, Mobile : {Mobile}, Email : {Email}";
        }
    }
}
