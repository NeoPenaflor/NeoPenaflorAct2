namespace PenaflorLOAN_MARCH13_BL&DL
{
    internal class Program
    {
        static string[] usernames = new string[3];
        static string[] passwords = new string[3];
        static List<string> accessLogs = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("ACCOUNT MANAGEMENT SYSTEM");

            PopulateData();

            bool isLogin = LoginOption();

            while (isLogin)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (UserLogin())
                    {
                        Console.WriteLine("Login Successful!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials.");
                    }
                }

                isLogin = LoginOption();
            }

            DisplayLogs();
        }

        static bool LoginOption()
        {
            Console.Write("Do you want to login? y/n: ");
            string loginInput = Console.ReadLine();

            bool isLogin = false;

            switch (loginInput)
            {
                case "y":
                    isLogin = true;
                    break;
                case "n":
                    isLogin = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. System will exit.");
                    Environment.Exit(0);
                    break;
            }

            return isLogin;
        }

        static void PopulateData()
        {
            usernames[0] = "Neo";
            usernames[1] = "Neo1";
            usernames[2] = "Neo2";

            passwords[0] = "Neo12345";
            passwords[1] = "Neo123456";
            passwords[2] = "Neo1234567";

        }

        static void AddAccessLogs(string usernameInput, string passwordInput, bool isMatched)
        {
            accessLogs.Add($"username: {usernameInput}, password: {passwordInput}, Is Success?: {isMatched}");
        }

        static bool UserLogin()
        {
            Console.Write("Enter username: ");
            string usernameInput = Console.ReadLine();
            Console.Write("Enter password: ");
            string passwordInput = Console.ReadLine();

            bool isMatched = false;

            for (int x = 0; x < usernames.Length; x++)
            {
                if (usernameInput == usernames[x] && passwordInput == passwords[x])
                {
                    isMatched = true;
                    break;
                }
                else
                {
                    isMatched = false;
                }
            }

            AddAccessLogs(usernameInput, passwordInput, isMatched);

            return isMatched;
        }

        static void DisplayLogs()
        {
            foreach (var log in accessLogs)
            {
                Console.WriteLine(log);
            
                //loan form
                Console.WriteLine("Input your current job");
                string job = Console.Readline();
                Console.WriteLine("Input your current salary");
                string salary = Console.Readline();
                Console.WriteLine("Input your current company");
                string company = Console.Readline();
                Console.WriteLine("Select loan duration interest rate 5-10% is based on the duration of loan");

                //if else
                Console.WriteLine("3 month");
                Console.WriteLine("6 months");
                Console.WriteLine("9 months");
                Console.WriteLine("12 months");
                int choice = Convert.

                //notification part 1
                Console.WriteLine("You have loan this amount Deadline: date ");
                Console.WriteLine("Your loan has been approved");
                Console.WriteLine("Waiting for loan approval");

             
    }
}
