namespace Record___Static_Task
{
    class User
    {
        private static int currentId = 0;
        public int Id { get; private set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        private string password;

        public User(string fullname, string email, string password)
        {
            Id = ++currentId;
            Fullname = fullname;
            Email = email;
            SetPassword(password);
        }

        public bool PasswordChecker(string password)
        {
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;

            if (password.Length < 8)
            {
                return false;
            }

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                if (char.IsLower(c)) hasLowerCase = true;
                if (char.IsDigit(c)) hasDigit = true;
            }

            return hasUpperCase && hasLowerCase && hasDigit;
        }

        public void SetPassword(string password)
        {
            while (!PasswordChecker(password))
            {
                Console.WriteLine("Password does not meet the criteria. Please enter a valid password:");
                password = Console.ReadLine();
            }
            this.password = password;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Id: {Id}, Fullname: {Fullname}, Email: {Email}");
        }

        public static User FindUserById(User[] users, int id)
        {
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
