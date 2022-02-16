using System;
using System.Collections.Generic;
using System.Globalization;

namespace Module3HW2
{
    public class ContactsContainer
    {
        public ContactsContainer(CultureInfo culture)
        {
            Culture = culture;

            if (Culture.Name == "ru")
            {
                Contacts = new Dictionary<string, List<ContactInfo>>()
                {
                    { "А", new List<ContactInfo>() },
                    { "Б", new List<ContactInfo>() },
                    { "В", new List<ContactInfo>() },
                    { "Г", new List<ContactInfo>() },
                    { "Д", new List<ContactInfo>() },
                    { "Е", new List<ContactInfo>() },
                    { "Ё", new List<ContactInfo>() },
                    { "Ж", new List<ContactInfo>() },
                    { "З", new List<ContactInfo>() },
                    { "И", new List<ContactInfo>() },
                    { "Й", new List<ContactInfo>() },
                    { "К", new List<ContactInfo>() },
                    { "Л", new List<ContactInfo>() },
                    { "М", new List<ContactInfo>() },
                    { "Н", new List<ContactInfo>() },
                    { "О", new List<ContactInfo>() },
                    { "П", new List<ContactInfo>() },
                    { "Р", new List<ContactInfo>() },
                    { "С", new List<ContactInfo>() },
                    { "Т", new List<ContactInfo>() },
                    { "У", new List<ContactInfo>() },
                    { "Ф", new List<ContactInfo>() },
                    { "Х", new List<ContactInfo>() },
                    { "Ц", new List<ContactInfo>() },
                    { "Ч", new List<ContactInfo>() },
                    { "Ш", new List<ContactInfo>() },
                    { "Щ", new List<ContactInfo>() },
                    { "Ь", new List<ContactInfo>() },
                    { "Ъ", new List<ContactInfo>() },
                    { "Ы", new List<ContactInfo>() },
                    { "Э", new List<ContactInfo>() },
                    { "Ю", new List<ContactInfo>() },
                    { "Я", new List<ContactInfo>() },
                    { "#", new List<ContactInfo>() },
                    { "0-9", new List<ContactInfo>() }
                };
            }
            else
            {
                Contacts = new Dictionary<string, List<ContactInfo>>()
                {
                    { "A", new List<ContactInfo>() },
                    { "B", new List<ContactInfo>() },
                    { "C", new List<ContactInfo>() },
                    { "D", new List<ContactInfo>() },
                    { "E", new List<ContactInfo>() },
                    { "F", new List<ContactInfo>() },
                    { "G", new List<ContactInfo>() },
                    { "H", new List<ContactInfo>() },
                    { "I", new List<ContactInfo>() },
                    { "J", new List<ContactInfo>() },
                    { "K", new List<ContactInfo>() },
                    { "L", new List<ContactInfo>() },
                    { "M", new List<ContactInfo>() },
                    { "N", new List<ContactInfo>() },
                    { "O", new List<ContactInfo>() },
                    { "P", new List<ContactInfo>() },
                    { "Q", new List<ContactInfo>() },
                    { "R", new List<ContactInfo>() },
                    { "S", new List<ContactInfo>() },
                    { "T", new List<ContactInfo>() },
                    { "U", new List<ContactInfo>() },
                    { "V", new List<ContactInfo>() },
                    { "W", new List<ContactInfo>() },
                    { "X", new List<ContactInfo>() },
                    { "Y", new List<ContactInfo>() },
                    { "Z", new List<ContactInfo>() },
                    { "#", new List<ContactInfo>() },
                    { "0-9", new List<ContactInfo>() }
                };
            }
        }

        public Dictionary<string, List<ContactInfo>> Contacts { get; set; }

        private CultureInfo Culture { get; set; }

        public void ShowAllContacts()
        {
            foreach (var item in Contacts)
            {
                if (Contacts[item.Key].Count > 0)
                {
                    Console.WriteLine($"{item.Key}: ");

                    for (int i = 0; i < Contacts[item.Key].Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {Contacts[item.Key][i]}");
                    }

                    Console.WriteLine();
                }
            }
        }

        public void AddContact(ContactInfo contact)
        {
            if (char.IsDigit(contact.FullName.ToUpper()[0]))
            {
                Contacts["0-9"].Add(contact);
            }
            else if (!char.IsLetter(contact.FullName.ToUpper()[0]))
            {
                Contacts["#"].Add(contact);
            }
            else
            {
                bool isAdded = false;

                foreach (var item in Contacts)
                {
                    if (contact.FullName.ToUpper().StartsWith(item.Key))
                    {
                        Contacts[item.Key].Add(contact);
                        isAdded = true;
                    }
                }

                if (!isAdded)
                {
                    Contacts["#"].Add(contact);
                }
            }
        }

        public void DeleteContact(ContactInfo contact)
        {
            if (contact != null)
            {
                if (char.IsDigit(contact.FullName.ToUpper()[0]))
                {
                    Contacts["0-9"].Remove(contact);
                }
                else if (!char.IsLetter(contact.FullName.ToUpper()[0]))
                {
                    Contacts["#"].Remove(contact);
                }
                else
                {
                    bool isRemoved = false;

                    foreach (var item in Contacts)
                    {
                        if (contact.FullName.ToUpper().StartsWith(item.Key))
                        {
                            Contacts[item.Key].Remove(contact);
                            isRemoved = true;
                        }
                    }

                    if (!isRemoved)
                    {
                        Contacts["#"].Remove(contact);
                    }
                }

                Console.WriteLine($"Contact {contact.FullName} was deleted");
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void DeleteContact(string chapter, int index)
        {
            string fullNameOfDeletedPerson = Contacts[chapter][index].FullName;
            Contacts[chapter].RemoveAt(index);

            Console.WriteLine($"Contact {fullNameOfDeletedPerson} was deleted");
        }
    }
}
