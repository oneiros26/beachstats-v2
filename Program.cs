namespace BeachStats
{
    public class ServeType
    {
        public int StartPosition { get; }
        public int EndPosition { get; }

        public int AceCount { get; private set; }
        public int GoodCount { get; private set; }
        public int BadCount { get; private set; }
        public int MistakeCount { get; private set; }
        
        public ServeType(int startPosition, int endPosition)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
        }
        
        public void RecordAce()
        {
            AceCount++;
        }

        public void RecordGood()
        {
            GoodCount++;
        }

        public void RecordBad()
        {
            BadCount++;
        }
        
        public void RecordMistake()
        {
            MistakeCount++;
        }
        
        public override string ToString()
        {
            return $"Servis {StartPosition}->{EndPosition}: Eso = {AceCount}, Dobry={GoodCount}, Spatny={BadCount}, Chyby={MistakeCount}";
        }
    }
    
    public class ServeStatistics
    {
        private Dictionary<string, ServeType> _serveTypes;

        public ServeStatistics()
        {
            _serveTypes = new Dictionary<string, ServeType>();
            
            for (int start = 1; start <= 3; start++)
            {
                for (int end = 1; end <= 6; end++)
                {
                    string key = $"{start}-{end}";
                    _serveTypes[key] = new ServeType(start, end);
                }
            }
        }
        
        public ServeType GetServeType(int start, int end)
        {
            string key = $"{start}-{end}";
            _serveTypes.TryGetValue(key, out ServeType serveType);
            return serveType;

        }
        
        public void RecordServe(int startPosition, int endPosition, string outcome)
        {
            ServeType serveType = GetServeType(startPosition, endPosition);
            // Console.WriteLine($"Recording serve: Start={startPosition}, End={endPosition}, Outcome={outcome}"); // Debugging

            if (serveType != null)
            {
                if (outcome.Equals("3"))
                {
                    serveType.RecordAce();
                }
                else if (outcome.Equals("2"))
                {
                    serveType.RecordGood();
                }
                else if (outcome.Equals("1"))
                {
                    serveType.RecordBad();
                }
                else if (outcome.Equals("0"))
                {
                    serveType.RecordMistake();
                }
            }
        }
        
        // For debugging only
        /*
        public void DisplayStatistics()
        {
            foreach (var serveType in _serveTypes.Values)
            {
                Console.WriteLine(serveType);
            }
        }
        */
        
    }
    
     public class ReceiveType
    {
        public int Position { get; }

        public int GreatCount { get; private set; }
        public int GoodCount { get; private set; }
        public int BadCount { get; private set; }
        public int FailCount { get; private set; }
        
        public ReceiveType(int position)
        {
            Position = position;
        }
        
        public void RecordGreat()
        {
            GreatCount++;
        }

        public void RecordGood()
        {
            GoodCount++;
        }

        public void RecordBad()
        {
            BadCount++;
        }
        
        public void RecordFail()
        {
            FailCount++;
        }
        
        public override string ToString()
        {
            return $"Prijem {Position}: Skvely = {GreatCount}, Dobry={GoodCount}, Spatny={BadCount}, Chyby={FailCount}";
        }
    }
    
    public class ReceiveStatistics
    {
        private Dictionary<string, ReceiveType> _receiveTypes;

        public ReceiveStatistics()
        {
            _receiveTypes = new Dictionary<string, ReceiveType>();
            
            for (int position = 1; position <= 9; position++)
            {
                if (position == 5)
                {
                    
                }
                else
                {
                    string key = $"{position}";
                    _receiveTypes[key] = new ReceiveType(position);   
                }
            }
        }
        
        public ReceiveType GetReceiveType(int position)
        {
            string key = $"{position}";
            _receiveTypes.TryGetValue(key, out ReceiveType receiveType);
            return receiveType;

        }
        
        public void RecordReceive(int position,  string outcome)
        {
            ReceiveType receiveType = GetReceiveType(position);
            Console.WriteLine($"Recording receive: Position = {position}, Outcome={outcome}");

            if (receiveType != null)
            {
                if (outcome.Equals("3"))
                {
                    receiveType.RecordGreat();
                }
                else if (outcome.Equals("2"))
                {
                    receiveType.RecordGood();
                }
                else if (outcome.Equals("1"))
                {
                    receiveType.RecordBad();
                }
                else if (outcome.Equals("0"))
                {
                    receiveType.RecordFail();
                }
            }
        }
        
        // For debugging only
        /*
        public void DisplayStatistics()
        {
            foreach (var receiveType in _receiveTypes.Values)
            {
                Console.WriteLine(receiveType);
            }
        }
        */
        
    }

    class Program
    {
        public static string Username = "Karch Kiraly";
        public static string Manual = File.ReadAllText("manual.txt");
        public static ServeStatistics StatisticsSe = new ServeStatistics();
        public static ReceiveStatistics StatisticsRe = new ReceiveStatistics();

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
            MakeBox("Stisknete “P” pro přihlášení nebo “R” pro registraci");
            while (true)
            {
                ConsoleKeyInfo keyPress = Console.ReadKey();

                if (keyPress.Key == ConsoleKey.P)
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
                            Username = logUsername;
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
                            Username = regUsername;
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
            MakeBox("Stisknete \"N\" pro nový záznam nebo \"S\" pro statistiky\n\nstisknutím “Z” se vrátíte zpět");
            while (true) 
            {
                ConsoleKeyInfo keyPress = Console.ReadKey();
                if (keyPress.Key == ConsoleKey.N)
                {
                    WhatWillUserRecord();
                    break;
                }
                if (keyPress.Key == ConsoleKey.S)
                {
                    // To-do
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
            bool attack = false;
            
            do
            {
                MakeBox("Zahajili jste NOVY ZAZNAM\nstisknete vsechna cisla pro ktere chcete udelat statistiku\n\n1. Podani - " + serve.ToString() + "\n2. Prijem - " + receive.ToString() + "\n3. Utok - " + attack.ToString() + "\n\nAz budete spokojeni stisknete ENTER");
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
                            attack = !attack;
                            break;
                }
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    allSet = true;
                }

            } while (!allSet);
            NewData(serve, receive, attack);
        }
        
        public static void NewData(bool serve, bool receive, bool attack)
        {
            MakeBox("Byla zahajena NOVA STATISTIKA\n\nProsim zadejte datum ve formatu yyyymmdd\nPriklad: datum 26.9.1994, napiste: 19940926");
            string matchDate = Console.ReadLine();
            
            MakeBox("Zadejte název zápasu a stiskněte ENTER");
            string matchName = Console.ReadLine();
            File.WriteAllText(Username + "/" + matchName + ".txt", matchDate + "\n");
            
            bool normalOrientation = true;
            MakeBox("Zacina vas tym na blizsi nebo vzdalenejsi strane? Stisknete B pro blizsi nebo V pro vzdalenejsi");
            while (true)
            {
                ConsoleKeyInfo whichSide = Console.ReadKey();
                if (whichSide.Key == ConsoleKey.B)
                {
                    break;
                }

                if (whichSide.Key == ConsoleKey.V)
                {
                    normalOrientation = false;
                    break;
                }
            }
            
            string serveText = "";
            string receiveText = "";
            string attackText = "";
            bool exitNow = false;
            
            if (serve)
            {
                serveText = "\nS - servis";
            }
            if (receive)
            {
                receiveText = "\nP - prijem";
            }
            if (attack)
            {
                attackText = "\nU - utok";
            }
            
            MakeBox("KDYBYSTE KDYKOLIV POTREBOVALI MANUAL STISNEKTE \"H\" JAKO HELP\n\nStisknete pismeno podle typu uderu ktery chcete sledovat\nStisknete O jako otocit orientaci kdyz se meni strany\n" + serveText + receiveText + attackText);
            while (exitNow == false)
            {
                ConsoleKeyInfo keyPress = Console.ReadKey();
                switch (keyPress.Key) 
                {
                    case ConsoleKey.S:
                        EnterServeStats(normalOrientation);
                        break;
                    case ConsoleKey.P:
                        EnterReceiveStats(normalOrientation);
                        break;
                    case ConsoleKey.U:
                        EnterAttackStats(normalOrientation);
                        break;
                    case ConsoleKey.H:
                        MakeBox("Stisknete pismeno podle typu uderu ktery chcete sledovat\n" + serveText + receiveText + attackText + Manual);
                        break;
                    case ConsoleKey.Enter:
                        exitNow = true;
                        break;
                    case ConsoleKey.O:
                        normalOrientation = !normalOrientation;
                        break;
                }
            }
        }
        
        public static void EnterServeStats(bool normalOrientation)
        {
            int startPosition = 0;
            int endPosition = 0;
            string outcome = "";
            
            MakeBox("Odkud podava?");
            ConsoleKeyInfo keyPress = Console.ReadKey();
            switch (keyPress.KeyChar)
            {
                case '1':
                    if (normalOrientation == false)
                    {
                        startPosition = 3;
                    }
                    else
                    {
                        startPosition = 1;
                    }
                    break;
                case '2':
                    startPosition = 2;
                    break;
                case '3':
                    if (normalOrientation == false)
                    {
                        startPosition = 1;
                    }
                    else
                    {
                        startPosition = 3;
                    }
                    break;
            }
            MakeBox("Kam balon dopadl?");
            ConsoleKeyInfo keyPress2 = Console.ReadKey();
            switch (keyPress2.KeyChar)
            {
                case '4':
                    if (normalOrientation == false)
                    {
                        endPosition = 9;
                    }
                    else
                    {
                        endPosition = 4;
                    }
                    break;
                case '5':
                    if (normalOrientation == false)
                    {
                        endPosition = 8;
                    }
                    else
                    {
                        endPosition = 5;
                    }
                    break;
                case '6':
                    if (normalOrientation == false)
                    {
                        endPosition = 7;
                    }
                    else
                    {
                        endPosition = 6;
                    }
                    break;
                case '7':
                    if (normalOrientation == false)
                    {
                        endPosition = 6;
                    }
                    else
                    {
                        endPosition = 7;
                    }
                    break;
                case '8':
                    if (normalOrientation == false)
                    {
                        endPosition = 5;
                    }
                    else
                    {
                        endPosition = 8;
                    }
                    break;
                case '9':
                    if (normalOrientation == false)
                    {
                        endPosition = 4;
                    }
                    else
                    {
                        endPosition = 9;
                    }
                    break;
            }
            MakeBox("Jak servis dopadl?");
            ConsoleKeyInfo keyPress3 = Console.ReadKey();
            switch (keyPress3.KeyChar)
            {
                case '0':
                    outcome = "0";
                    break;
                case '1':
                    outcome = "1";
                    break;
                case '2':
                    outcome = "2";
                    break;
                case '3':
                    outcome = "3";
                    break;
            }
            StatisticsSe.RecordServe(startPosition, endPosition, outcome);
        }

        public static void EnterReceiveStats(bool normalOrientation)
        {
            int position = 0;
            string outcome = "";
            
            MakeBox("Kde prijima?");
            ConsoleKeyInfo keyPress = Console.ReadKey();
            switch (keyPress.KeyChar)
            {
                case '1':
                    if (normalOrientation == false)
                    {
                        position = 9;
                    }
                    else
                    {
                        position = 1;
                    }
                    break;
                case '2':
                    if (normalOrientation == false)
                    {
                        position = 8;
                    }
                    else
                    {
                        position = 2;
                    }
                    break;
                case '3':
                    if (normalOrientation == false)
                    {
                        position = 7;
                    }
                    else
                    {
                        position = 3;
                    }
                    break;
                case '4':
                    if (normalOrientation == false)
                    {
                        position = 6;
                    }
                    else
                    {
                        position = 4;
                    }
                    break;
                case '6':
                    if (normalOrientation == false)
                    {
                        position = 4;
                    }
                    else
                    {
                        position = 6;
                    }
                    break;
                case '7':
                    if (normalOrientation == false)
                    {
                        position = 3;
                    }
                    else
                    {
                        position = 7;
                    }
                    break;
                case '8':
                    if (normalOrientation == false)
                    {
                        position = 2;
                    }
                    else
                    {
                        position = 8;
                    }
                    break;
                case '9':
                    if (normalOrientation == false)
                    {
                        position = 1;
                    }
                    else
                    {
                        position = 9;
                    }
                    break;
            }
            MakeBox("Jak prijem dopadl?");
            ConsoleKeyInfo keyPress2 = Console.ReadKey();
            switch (keyPress2.KeyChar)
            {
                case '0':
                    outcome = "0";
                    break;
                case '1':
                    outcome = "1";
                    break;
                case '2':
                    outcome = "2";
                    break;
                case '3':
                    outcome = "3";
                    break;
            }
            StatisticsRe.RecordReceive(position, outcome);
        }

        public static void EnterAttackStats(bool normalOrientation)
        {
            // To-do
        }
    
        public static void Main(string[] args)
        {
            // WelcomeMessage(); // Line 8
            // LoginAndRegister(); // Line 18
            Menu(); // Line 97
            // StatisticsSe.DisplayStatistics(); // Debugging
            // StatisticsRe.DisplayStatistics(); // Debugging
        }
    }
}
