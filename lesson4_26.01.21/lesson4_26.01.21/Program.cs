using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace lesson4_26._01._21
{
    class Program
    {
        static void Main(string[] args)
        {
            //Код задач я записал в скобках для удобства

            /*
            Написать программу, которая принимает от пользователя длины двух
            сторон прямоугольника и выводит на экран периметр и площадь. 
            */
            {
                Console.WriteLine("Введите стороны прямоугольника: ");
                double side1 = double.Parse(Console.ReadLine()), side2 = double.Parse(Console.ReadLine());
                Rectangle rec1 = new Rectangle(side1, side2);
                Console.WriteLine($"Площадь прямоугольника: {rec1.Area}");
                Console.WriteLine($"Периметер прямоугольника: {rec1.Perimeter}");
                Console.ReadKey();
            }

            /*
            Выведите на экран разными цветами при помощи метода Show() название
            книги, имя автора и содержание.
            */
            {
                Console.Write("\nВведите название книги: ");
                string title = Console.ReadLine();
                Console.Write("Введите автора книги: ");
                string author = Console.ReadLine();
                Console.Write("Введите содержание книги: ");
                string content = Console.ReadLine();

                Book book1 = new Book
                {
                    BookTitle = new Title
                    {
                        Title1 = title
                    },
                    BookAuthor = new Author
                    {
                        Author1 = author
                    },
                    BookContent = new Content
                    {
                        Content1 = content
                    }
                };
                Console.Write("Название книги: ");
                book1.BookTitle.Show();
                Console.Write("Автор книги: ");
                book1.BookAuthor.Show();
                Console.Write("Содержание книги: ");
                book1.BookContent.Show();
                Console.ReadKey();
            }

            /*
            Требуется: создать класс которое описывает состояние и поведение некой сущности.
            */
            //Решил сделать мини-меню с описанием персонажа в видеоигре (это ведь считается за некую сущность?)
            {
                Player player1 = new Player
                {
                    PlayerName = "Nush",
                    PlayerLevel = 7,
                    PlayerQuest = new Quest
                    {
                        PlayerMoving = true,
                        QuestName = "В поисках кота",
                        QuestComplete = false
                    },
                    PlayerHealth = new Health
                    {
                        CurrentHealth = 75,
                        MaxHealth = 110
                    },
                    PlayerMana = new Mana
                    {
                        CurrentMana = 0,
                        MaxMana = 80
                    },
                    PlayerBagWeight = new Weight
                    {
                        CurrentBagWeight = Math.Round(32.6, 1),
                        MaxBagWeight = Math.Round(50.0, 1)
                    }
                };
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n\t\tДобро пожаловать в AlifRPG! ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\n1.Характеристики Персонажа");
                Console.Write(
                   $"\n  Имя - ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(
                    $"{player1.PlayerName} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(
                    $"\n  Уровень - ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(
                    $"{player1.PlayerLevel} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(
                    $"\n  Здоровье - ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(
                    $"{player1.PlayerHealth.CurrentHealth}/{player1.PlayerHealth.MaxHealth}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(
                    $"\n  Мана - ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(
                    $"{player1.PlayerMana.CurrentMana}/{player1.PlayerMana.MaxMana}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.Write("\n2.Заполненность сумки");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"\n  {player1.PlayerBagWeight.CurrentBagWeight}кг /" +
                    $"{player1.PlayerBagWeight.MaxBagWeight}кг");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.Write($"\n3.Квест" +
                    $"\n  Текущий квест: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"'{player1.PlayerQuest.QuestName}'");
                Console.ForegroundColor = ConsoleColor.White;
                if (player1.PlayerQuest.PlayerMoving == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n  {player1.PlayerName} не выполняет квеcт в данный момент.");
                }
                else if (player1.PlayerQuest.QuestComplete == false)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n  {player1.PlayerName} выполняет квеcт в данный момент.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n  {player1.PlayerName} выполнил данный квест!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }

            /*
                Написать программу, которая будет выполнять конвертацию из сомони в
                одну из указанных валют, также программа должна производить
                конвертацию из указанных валют в сомони.
            */
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nКонвертер валют \nВведите курсы валют по отношению к сомони (1 value = X TJS)");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nВведите курс доллара к сомони: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                double usd = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите курс евро к сомони: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                double eur = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите курс рубля к сомони: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                double rub = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                Converter convert = new Converter(usd, eur, rub);

                Console.WriteLine("Выберите операцию: (1, 2)");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(
                    "1.Конвертация из сомони" +
                    "\n2.Конвертация в сомони");
                Console.ForegroundColor = ConsoleColor.White;
                int operchoice = int.Parse(Console.ReadLine());
                Console.WriteLine("Выберите валюту: (1, 2, 3)");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(
                    "1.USD" +
                    "\n2.EUR" +
                    "\n3.RUB");
                Console.ForegroundColor = ConsoleColor.White;
                int curr = int.Parse(Console.ReadLine());
                Console.Write("Введите количетсво вашей валюты: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                double val = double.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                switch (operchoice)
                {
                    case 1:
                        convert.ConvFrom(curr, val);
                        break;
                    case 2:
                        convert.ConvTo(curr, val);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка ввода.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            /*
            Написать программу, которая выводит на экран информацию о
            сотруднике (фамилия, имя, должность), оклад (заработная плата) и
            налоговый сбор (13 % налог + 1% пенсионный фонд) от заработной платы.
            */
            {
                Console.Write("\nВведите своё имя: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите свою фамилию: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string surname = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Employee employee1 = new Employee(name, surname);
                employee1.PaymentCount();
                Console.ReadKey();
            }
        }
    }

    class Rectangle
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }

        public double Area
        {
            get
            {
                return AreaCalculator();
            }
        }
        public double Perimeter
        {
            get
            {
                return PerimeterCalculator();
            }
        }
        
        public Rectangle(double side1, double side2)
        {
            Side1 = side1;
            Side2 = side2;
        }
        public double AreaCalculator()
        {
            return Math.Round(Side1 * Side2, 2);
        }
        public double PerimeterCalculator()
        {
            return Math.Round((Side1 + Side2) * 2, 2);
        }
    }

    class Book
    {
        public Title BookTitle { get; set; }
        public Author BookAuthor { get; set; }
        public Content BookContent { get; set; }
    }
    class Title
    {
        public string Title1 { get; set; }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Title1);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    class Author
    {
        public string Author1 { get; set; }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Author1);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    class Content
    {
        public string Content1 { get; set; }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(Content1);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class Player
    {
        public string PlayerName { get; set; }
        public int PlayerLevel { get; set; }
        public Weight PlayerBagWeight{ get; set; }
        public Health PlayerHealth { get; set; }
        public Mana PlayerMana { get; set; }
        public Quest PlayerQuest { get; set; }
    }
    class Weight
    {
        public double MaxBagWeight { get; set; }
        public double CurrentBagWeight { get; set; }
    }
    class Health
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
    class Mana
    {
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }
    }
    class Quest
    {
        public bool PlayerMoving { get; set; }
        public string QuestName { get; set; }
        public bool QuestComplete { get; set; }
    }

    class Converter
    {
        public double USD { get; set; }
        public double EUR { get; set; }
        public double RUB { get; set; }

        public Converter(double usd, double eur, double rub)
        {
            USD = usd;
            EUR = eur;
            RUB = rub;
        }
        public void ConvTo(int curr, double val)
        {
            switch (curr)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{val}USD = {Math.Round(val * USD, 2)}TJS");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{val}EUR = {Math.Round(val * EUR, 2)}TJS");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{val}RUB = {Math.Round(val * RUB, 2)}TJS");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        public void ConvFrom(int curr, double val)
        {
            switch (curr)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{val}TJS = {Math.Round(val / USD, 2)}USD");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{val}TJS = {Math.Round(val / EUR, 2)}EUR");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{val}TJS = {Math.Round(val / RUB, 2)}RUB");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }

    class Employee
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeePost { get; set; }
        public double EmployeeSalary{ get; set; }
        public int EmployeeExperience { get; set; }
        public int EmployeeBonus { get; set; }
        public double EmployeeTotalPayment { get; set; }

        public Employee(string name, string surname)
        {
            EmployeeFirstName = name;
            EmployeeLastName = surname;
            EmployeePost = "Кассир";
            EmployeeExperience = 6;
        }

        public void PaymentCount()
        {
            switch (EmployeePost)
            {
                case "Кассир":
                    EmployeeSalary = 1000;
                    break;
                case "Управляющий отделением":
                    EmployeeSalary = 1800;
                    break;
                case "Главный бухгалтер":
                    EmployeeSalary = 2500;
                    break;
                case "Шефи хона":
                    Console.WriteLine($"Акаи {EmployeeFirstName}, сумтон халай карочи");
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Сотрудник {EmployeeLastName} не имеет должности");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
            }
            if(EmployeeExperience < 5)
            {
                EmployeeBonus = 0;
            }
            else if (EmployeeExperience < 11)
            {
                EmployeeBonus = 15;
            }
            else if (EmployeeExperience < 16)
            {
                EmployeeBonus = 20;
            }
            else
            {
                EmployeeBonus = 30;
            }

            EmployeeTotalPayment = EmployeeSalary + (EmployeeSalary / 100 * EmployeeBonus);

            Console.Write(
                $"Сотрудник {EmployeeLastName} {EmployeeFirstName}, {EmployeePost}. " +
                $"\nОтклад составляет ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(EmployeeTotalPayment - (EmployeeTotalPayment / 100 * 14) + " сомони");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(
                $", с учётом бонуса за стаж работы(");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(EmployeeBonus + "%");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                $") и налогового сбора (13% налог + 1% пенсионный фонд)");
        }

    }
}
