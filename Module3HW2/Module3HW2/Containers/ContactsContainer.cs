using System;
using System.Collections.Generic;
using System.Globalization;

namespace Module3HW2
{
    public class ContactsContainer
    {
        private readonly IAlphabetConfigurationService _alphabetConfigurationService;

        public ContactsContainer(IAlphabetConfigurationService alphabetConfigurationService, CultureInfo culture)
        {
            _alphabetConfigurationService = alphabetConfigurationService;
            AlphabetConfig = _alphabetConfigurationService.DeserializeAlphabetConfig(@"C:\Users\sasha\source\repos\Module3HW2\Module3HW2\Module3HW2\Configs\alphabet-config.json");

            Culture = culture;

            Contacts = new Dictionary<string, List<ContactInfo>>();
            AddChapters();
        }

        public Dictionary<string, List<ContactInfo>> Contacts { get; set; }

        private CultureInfo Culture { get; set; }

        private AlphabetConfig AlphabetConfig { get; set; }

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

        private void AddChapters()
        {
            foreach (var letter in AlphabetConfig.Alphabets[Culture.Name])
            {
                Contacts.Add(letter.ToString(), new List<ContactInfo>());
            }

            Contacts.Add("#", new List<ContactInfo>());
            Contacts.Add("0-9", new List<ContactInfo>());
        }
    }
}
