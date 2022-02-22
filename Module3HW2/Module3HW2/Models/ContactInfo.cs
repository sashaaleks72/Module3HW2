namespace Module3HW2
{
    public class ContactInfo
    {
        public ContactInfo(string firstName, string lastName, string patronymic, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            FullName = $"{LastName} {FirstName} {Patronymic}";
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        public override string ToString()
        {
            return $"Full name: {FullName}\nPhone number: {PhoneNumber}";
        }
    }
}
