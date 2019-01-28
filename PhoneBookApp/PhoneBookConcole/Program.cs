using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhoneBookConcole;

namespace PhoneBookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************************************************************************************");
            Console.WriteLine("***************************Welcome to PhoneBook Application*************************************");
            Console.WriteLine("************************************************************************************************");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine("1 - Create or Update Contact Press (C)");
                Console.WriteLine("2 - Show All Contact Press (S)");
                Console.WriteLine("3 - Remove Contact Press (R)");
                Console.WriteLine("4 - Find Contact Press (F)");
                Console.WriteLine("5 - Exit Contact Press (E)");
                Console.WriteLine(" ");

                string value = Console.ReadLine().ToUpper();

                if (value == "C")
                {
                    Console.WriteLine("Please insert the Name of the Contact");
                    var name = Console.ReadLine();
                    var _name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());

                    if (Services.IsDublicated(_name) == true)
                    {
                        var contacts = Contact.GetContacts();
                        var contact = from c in contacts where c.Name == _name select c;
                        
                        Console.WriteLine($"The Contact {contact.FirstOrDefault().ToString()} exist in your list of contacts \r\n" +
                                          $"if you want to update it  Please press (Y)  \r\n" +
                                          $"if you want to create a new Contact with the same name preass (N) \r\n" +
                                          $"if you want to ignore press (I)");
                        var request = Console.ReadLine().ToUpper();
                        if (request == "Y")
                        {
                            Console.WriteLine("Please insert the Mobile ");
                            var mobile = Console.ReadLine();

                            Console.WriteLine("Please insert the Email ");
                            var email = Console.ReadLine();
                            Contact.UpdateContact(_name , mobile,email);
                      
                        }
                        else if (request == "N")
                        {
                            Console.WriteLine("Please insert the Mobile ");
                            var mobile = Console.ReadLine();

                            Console.WriteLine("Please insert the Email ");
                            var email = Console.ReadLine();
                            Contact.CreateNewContact(_name, mobile, email);
                        }
                        else
                        {
                            Console.WriteLine("Request ignored");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Please insert the Mobile ");
                        var mobile = Console.ReadLine();

                        Console.WriteLine("Please insert the Email ");
                        var email = Console.ReadLine();
                        Contact.CreateNewContact(_name, mobile, email);
                    }

                }
                else if (value == "S")
                {
                    foreach (var contact in Contact.GetContacts())
                    {
                        Console.WriteLine(contact.ToString());
                    }
                }
                else if (value == "R")
                {
                    Console.WriteLine("Please insert the Name of the Contact you want to remove");
                    var name = Console.ReadLine();
                    Contact.RemoveContact(name);
                }
                else if (value == "F")
                {
                    Console.WriteLine("Please insert a Name of the Contact you want to Find ");
                    var name = Console.ReadLine();
                    if (name.Length >2)
                    {
                        Services.FindContact(name);
                    }
                    else
                    {
                        Console.WriteLine("Please insert the Name That containt at list 3 characters Please Press F to retry  ");
                    }

                }
                else if (value == "E")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("please choose a correct option");
                }
            }
                
        }
    }
}
