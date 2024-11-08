using System.IO;
using System.Reflection;

namespace BeachStats
{
    class Program
    {
        public static void WelcomeMessage()
        {
            string welcome = "Vitejte v aplikaci BeachStats!";
            for (int i = 0; i < welcome.Length; i++)
            {
                Console.Write(welcome[i]);
                Thread.Sleep(100);
            }
        }

        public static void LoginAndRegister()
        {
            while (true)
            {
                MakeBox("napište “p” pro přihlášení nebo “r” pro registraci\nstiskněte ENTER pro potvrzení");

                string logOrReg = Console.ReadLine();
                if (logOrReg == "p")
                {
                    MakeBox("Zahajili jste PRIHLASENI\nnapiste jmeno hrace pro ktereho chcete statistiku tvorit\nstisknete ENTER pro potvrzeni");
                    string expectedUserPath;
                    
                    do
                    {
                        string logUsername;
                        do
                        {
                            logUsername = Console.ReadLine();
                            if (logUsername == "")
                            {
                                MakeBox("Nebylo zadano zadne jmeno, zkuste znovu");
                            }
                        } while (logUsername == "");

                        if (logUsername == "z")
                        {
                            LoginAndRegister();
                            break;
                        }
                        
                        expectedUserPath = Directory.GetCurrentDirectory() + "\\" + logUsername;
                        if (!Directory.Exists(expectedUserPath))
                        {
                            MakeBox("Uzivatel na vasem zarizeni neexistuje\nZkuste znovu");
                        }

                    } while (!Directory.Exists(expectedUserPath));
                    
                    MakeBox("Prihlaseni probehlo uspesne!");
                    break;
                }

                if (logOrReg == "r")
                {
                    MakeBox("Zahajili jste REGISTRACI\nnapiste jmeno hrace pro ktereho chcete statistiku tvorit\nstisknete ENTER pro potvrzeni");
                    string regUsername;
                    do
                    {
                        regUsername = Console.ReadLine();
                        if (regUsername == "")
                        {
                            MakeBox("Nebylo zadano zadne jmeno, zkuste znovu");
                        }
                    } while (regUsername == "");
                    
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\" + regUsername);
                    MakeBox("Uzivatel uspesne vytvoren");
                    
                    break;
                }
                MakeBox("Nebylo vlozeno \"r\" nebo \"p\". Zkuste znovu");
            }
        }
        public static void MakeBox(string s)
        {
            Console.WriteLine();
            for (int i = 0; i < 80; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine(s);
            for (int i = 0; i < 80; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public static void Menu()
        {
            while (true)
            {
                MakeBox("napište \"n\" pro nový záznam a stiskněte ENTER\nnapište \"s\" pro statistiky a stiskněte ENTER\n\nstisknutím “z” se vrátíte zpět");

                string menuChoice = Console.ReadLine();
                if (menuChoice == "n")
                {
                    Console.WriteLine("Data input coming soon");
                    break;
                }
                if (menuChoice == "s")
                {
                    Console.WriteLine("Statistics coming soon");
                    break;
                }
                if (menuChoice == "z")
                {
                    LoginAndRegister();
                    break;
                }

                Console.WriteLine("Nebylo vlozeno \"n\" nebo \"s\". Zkuste zaonovu");
            }
        }
            
        public static void Main(string[] args)
        {
            // WelcomeMessage();
            // LoginAndRegister();
            while (true)
            {
                Menu();
            }
        }
    }
}

/*
            Console.WriteLine("Registrace nebo Prihlaseni");
            if (Console.ReadLine() == "r")
            {
                Console.WriteLine("What should we call you?");
                string username = Console.ReadLine();
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\" + username);
                Console.WriteLine("User successfully created!");
            }
            else
            {
                Console.WriteLine("Enter your username:");
                string username = Console.ReadLine();
                if (Directory.Exists(Directory.GetCurrentDirectory() + "\\" + username))
                {
                    Console.WriteLine("Successfully logged in!");
                }
                else
                {
                    Console.WriteLine("User does not exist.");
                }
            }
            */


/*
string dataToSave = "Imagine if this worked?";
string username = Console.ReadLine();
string filePath = username + ".txt";

File.WriteAllText(filePath, dataToSave);

string filePath = "testFile.txt";
string data = File.ReadAllText(filePath);
Console.WriteLine(data);

Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\directory");
*/