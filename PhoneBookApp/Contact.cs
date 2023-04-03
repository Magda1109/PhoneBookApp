namespace PhoneBookApp
{
    class Contact
    {
        public Contact(string name, string number)
        {
            Name = name;
            Number = number;
        }
        public string Name { get; }
        public string Number { get; }
    }
}
