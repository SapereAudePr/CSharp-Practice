namespace ClassesOOP
{
    class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ContactNumber { get; set; }

        private static int nextId = 0;

        private readonly int _id;

        private string _password;

        public string Password { set => _password = value; }

        public int Id
        {
            get
            {
                return _id;
            }
        }
        
        // All Parameters
        public Customer(string name, string address, int contctNum)
        {
            Name = name;
            Address = address;
            ContactNumber = contctNum;

            _id = nextId++;

            Console.WriteLine($"Customer: {Name} | Address: {Address} | Contact Number: {ContactNumber} | UserID: {_id}");
        }

        // Single Parameter
        public Customer(string name)
        {
            Name = name;

            _id = nextId++;

            Console.WriteLine($"Customer: {Name} | Address: {Address} | Contact Number: {ContactNumber} | UserID: {_id}");
        }

        //// Default Constructor
        //public Customer()
        //{
        //    Name = "Null";
        //    Address = "Null";
        //    ContactNumber = 0;

        //    _id = nextId++;
        //}


        public void GetDetails()
        {
            Console.WriteLine($"Customer: {Name} | Address: {Address} | Contact Number: {ContactNumber} | UserID: {_id}");
        }
    }
}
