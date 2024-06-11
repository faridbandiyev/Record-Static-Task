namespace Record___Static_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[3];
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine($"Enter details for user {i + 1}:");
                Console.Write("Fullname: ");
                string fullname = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                users[i] = new User(fullname, email, password);
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Show all users");
                Console.WriteLine("2. Get info by id");
                Console.WriteLine("3. Quit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 3)
                    {
                        break;
                    }
                    else if (choice == 1)
                    {
                        foreach (var user in users)
                        {
                            user.GetInfo();
                        }
                    }
                    else if (choice == 2)
                    {
                        Console.Write("Enter user Id: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            User user = User.FindUserById(users, id);
                            if (user != null)
                            {
                                user.GetInfo();
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a numeric Id.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please select a valid menu option.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric choice.");
                }
            }
        }
    }
}