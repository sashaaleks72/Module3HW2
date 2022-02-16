using System;
using System.Collections.Generic;
using System.Globalization;

namespace Module3HW2
{
    public class Starter
    {
        public void Run()
        {
            Console.WriteLine("1.English\n2.Русский\n3.Default\n");
            Console.Write("Choose culture: ");
            int choose = Convert.ToInt32(Console.ReadLine());

            CultureInfo culture;

            switch (choose)
            {
                case 1:
                    culture = new CultureInfo("en");
                    break;
                case 2:
                    culture = new CultureInfo("ru");
                    break;
                default:
                    culture = new CultureInfo("en");
                    break;
            }

            ContactsContainer contactsContainer = new ContactsContainer(culture);

            ContactInfo[] contactInfos = new ContactInfo[]
            {
                new ContactInfo("Vladimir", "Vladimirov", "Vladimirovich", "380506953565"),
                new ContactInfo("Aleksandr", "Aleksandrov", "Aleksandrovich", "380676953565"),
                new ContactInfo("Maksim", "Maksimov", "Maksimovich", "380686953565"),
                new ContactInfo("Nikita", "Nikitov", "Nickitich", "380636953565"),
                new ContactInfo("Pavel", "Pavlov", "Pavlovich", "380766953565"),
                new ContactInfo("Aleksandra", "Alesandrova", "Aleksandrovna", "380956953565"),
                new ContactInfo("Evgenii", "Evgenov", "Evgeniyevich", "380506127565"),
                new ContactInfo("Igor", "Igorev", "Igorevich", "380677643565"),
                new ContactInfo("Dmitrii", "Dmitrov", "Dmitriyevich", "380686764565"),
                new ContactInfo("Evgeniya", "Evgenova", "Evgeniyevna", "380506325465"),
                new ContactInfo("Nadezhda", "Vladimirova", "Mihailovna", "380735535565"),
                new ContactInfo("Diana", "Selezneva", "Nikolayevna", "380508753532"),
                new ContactInfo("Albina", "Abramova", "Andreyevna", "380957823123"),
                new ContactInfo("Maksim", "Ilchenko", "Romanovich", "380638751234"),
                new ContactInfo("Ekaterina", "Dubova", "Aleksanrovna", "380631234576"),
                new ContactInfo("Ekaterina", "..;$56", "Aleksanrovna", "380636576581"),
                new ContactInfo("Ekaterina", "346787", "Aleksanrovna", "380636576581"),
                new ContactInfo("Максим", "Ильченко", "Романович", "380636516234"),
                new ContactInfo("Александр", "Третьяков", "Александрович", "380501234567"),
                new ContactInfo("Максим", "Сорокин", "Владимирович", "380637641243"),
                new ContactInfo("Владимир", "Кель", "Алексеевич", "380501235443"),
                new ContactInfo("Александра", "Абрамова", "Александровна", "380956953565")
            };

            foreach (var contact in contactInfos)
            {
                contactsContainer.AddContact(contact);
            }

            contactsContainer.ShowAllContacts();

            try
            {
                contactsContainer.DeleteContact(contactInfos[17]);
                contactsContainer.DeleteContact("A", 0);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            contactsContainer.ShowAllContacts();
        }
    }
}
