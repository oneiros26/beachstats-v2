using System.IO;
using System.Reflection;

namespace BeachStats
{
    class Program
    {
        public static string username;
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
            ConsoleKeyInfo keyPress = Console.ReadKey();
            MakeBox("Stisknete “P” pro přihlášení nebo “R” pro registraci");
            while (true)
            {

                if (keyPress.Key == ConsoleKey.S)
                {
                    MakeBox("Zahajili jste PRIHLASENI\nnapiste jmeno hrace pro ktereho chcete statistiku tvorit");
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
                        else
                        {
                            username = logUsername;
                        }
                    } while (!Directory.Exists(expectedUserPath));
                    
                    MakeBox("Prihlaseni probehlo uspesne!");
                    break;
                }

                if (keyPress.Key == ConsoleKey.R)
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
                        else
                        {
                            username = regUsername;
                        }
                    } while (regUsername == "");
                    
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\" + regUsername);
                    MakeBox("Uzivatel uspesne vytvoren");
                    
                    break;
                }
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
            ConsoleKeyInfo keyPress = Console.ReadKey();
            while (true)
            {
                MakeBox("Stisknete \"N\" pro nový záznam nebo \"S\" pro statistiky\n\nstisknutím “Z” se vrátíte zpět");
                
                if (keyPress.Key == ConsoleKey.N)
                {
                    WhatWillUserRecord();
                    break;
                }
                if (keyPress.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Statistics coming soon");
                    break;
                }
                if (keyPress.Key == ConsoleKey.Z)
                {
                    LoginAndRegister();
                    break;
                }
            }
        }

        public static void WhatWillUserRecord()
        {
            bool allSet = false;
            bool serve = false;
            bool receive = false;
            bool setting = false;
            bool attack = false;
            
            do
            {
                MakeBox("Zahajili jste NOVY ZAZNAM\nstisknete vsechna cisla pro ktere chcete udelat statistiku\n\n1. Podani - " + serve.ToString() + "\n2. Prijem - " + receive.ToString() + "\n3. Nahra - " + setting.ToString() + "\n4. Utok - " + attack.ToString() + "\n\nAz budete spokojeni stisknete ENTER");
                ConsoleKeyInfo keyPress = Console.ReadKey();
                
                switch (keyPress.KeyChar) 
                {
                        case '1':
                            serve = !serve;
                            break;
                        case '2':
                            receive = !receive;
                            break;
                        case '3':
                            setting = !setting;
                            break;
                        case '4':
                            attack = !attack;
                            break;
                }
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    allSet = true;
                }

            } while (!allSet);
            NewData(serve, receive, setting, attack);
        }
        
        public static void NewData(bool serve, bool receive, bool setting, bool attack)
        {
            MakeBox("Byla zahajena NOVA STATISTIKA\n\nProsim zadejte datum ve formatu yyyymmdd\nPriklad: datum 26.9.1994, napiste: 19940926");
            string matchDate = Console.ReadLine();
            
            MakeBox("Zadejte název zápasu a stiskněte ENTER");
            string matchName = Console.ReadLine();
            File.WriteAllText(username + "/" + matchName + ".txt", matchDate + "\n");
            
            ConsoleKeyInfo keyPress = Console.ReadKey();
        }
        public static void Main(string[] args)
        {
            //WelcomeMessage(); // Line 8
            //LoginAndRegister(); // Line 18
            Menu(); // Line 97
        }
    }
}
