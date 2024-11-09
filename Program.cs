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
                    NewData();
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

        public static void NewData()
        {
            bool allSet = false;
            bool secondGo = false;
            
            bool all = false;
            bool serve = false;
            bool receive = false;
            bool setting = false;
            bool attack = false;
            do
            {
                MakeBox("Zahajili jste NOVY ZAZNAM\nnapiste vsechna cisla podle statistiky kterou chcete delat a stisnete ENTER\n\n1. Vse\n2. Podani\n3. Prijem\n4. Nahra\n5. Utok\n\n Priklod: chcete delat statistiku pro podani a nahru, napisete 24 a stisnete ENTER");
                string userInput = Console.ReadLine();
                
                all = false;
                serve = false;
                receive = false;
                setting = false;
                attack = false;
                secondGo = false;
                
                foreach (char c in userInput)
                {
                    switch (c) 
                    {
                        case '1':
                            all = !all;
                            break;
                        case '2':
                            serve = !serve;
                            break;
                        case '3':
                            receive = !receive;
                            break;
                        case '4':
                            setting = !setting;
                            break;
                        case '5':
                            attack = !attack;
                            break;        
                    }
                }

                if (all || serve || receive || setting || attack == true)
                {
                    if (all == true)
                    {
                        MakeBox("Byla vybrana moznost VSE\nPro pokracovani stisnete P\nPro vraceni zpet stisnete Z");
                        while (true)
                        {
                            string input = Console.ReadLine();
                            if (input == "p")
                            {
                                allSet = true;
                                break;
                            }

                            if (input == "z")
                            {
                                secondGo = true;
                                break;
                            }
                        
                            if (input != "z" && input != "p")
                            {
                                MakeBox("Nebylo zadano P nebo Z, zkuste znovu");
                            }
                        }
                    }
                    else
                    {
                        string vybraneMoznosti = "Vybrali jste: ";
                        if (serve)
                        {
                            vybraneMoznosti += "\nPodani";
                        }

                        if (receive)
                        {
                            vybraneMoznosti += "\nPrijem";                        
                        }

                        if (setting)
                        {
                            vybraneMoznosti += "\nNahra";                        
                        }

                        if (attack)
                        {
                            vybraneMoznosti += "\nUtok";                        
                        }
                        
                        MakeBox(vybraneMoznosti + "\n\nPro pokracovani stisnete P\nPro vraceni zpet stisnete Z");
                        while (true)
                        {
                            string input = Console.ReadLine();
                            if (input == "p")
                            {
                                allSet = true;
                                break;
                            }

                            if (input == "z")
                            {
                                secondGo = true;
                                break;
                            }
                        
                            if (input != "z" && input != "p")
                            {
                                MakeBox("Nebylo zadano P nebo Z, zkuste znovu");
                            }
                        }
                    }
                }

                if (allSet == false && secondGo == false)
                {
                    MakeBox("Nebyla vybrana zadna moznost, zkuste znovu");   
                }
                
            } while (!allSet);
            
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
string dataToSave = "Imagine if this worked?";
string username = Console.ReadLine();
string filePath = username + ".txt";

File.WriteAllText(filePath, dataToSave);

string filePath = "testFile.txt";
string data = File.ReadAllText(filePath);
Console.WriteLine(data);

Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\directory");
*/