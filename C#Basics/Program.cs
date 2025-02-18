using static Program;

class Program
{
    private static List<Grade> grades = new List<Grade>();

    public enum Subject
    {
        Math,
        Physics
    }

    class Grade
    {
        public Subject subject;
        public int score;
        public string name;
        public DateTime date;
        public int id;

        public void Print()
        {
            Console.WriteLine($"Предмет:{this.subject}, Оценка: {this.score}, Имя студента: {this.name}, Дата: {this.date}, Номер оценки: {score}");
        }

        public void AddNewStudent()
        {
            Console.WriteLine($"1.{Subject.Math}, 2.{Subject.Physics}");
            Console.Write("Выберите предмет оценивания: ");
            int choiceSubject = Convert.ToInt16(Console.ReadLine());
            switch (choiceSubject)
            {
                case 1:
                    Console.Write("Оценка: ");
                    score = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Имя студента: ");
                    name = Console.ReadLine();
                    Console.Write("Дата: ");
                    date = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Номер оценки: ");
                    score = Convert.ToInt16(Console.ReadLine());
                    grades.Add(new Grade { subject = Subject.Math, score = this.score, name = this.name, date = this.date, id = this.id });
                    break;
                case 2:
                    Console.Write("Оценка: ");
                    score = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Имя студента: ");
                    name = Console.ReadLine();
                    Console.Write("Дата: ");
                    date = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Номер оценки: ");
                    score = Convert.ToInt16(Console.ReadLine());
                    grades.Add(new Grade { subject = Subject.Physics, score = this.score, name = this.name, date = this.date, id = this.id });
                    break;
                default:
                    return;
            }
        }
    }

    class ErrorMessage
    {
        public static void Print()
        {
            Console.WriteLine("Ошибка! Совпадений не найдено и/или введено неверное знаечение!");
        }
    }

    public static void Main(string[] args)
    {
        grades.Add(new Grade { subject = Subject.Math, score = 14, name = "Olezik", date = new DateTime(2025, 02, 14), id = 1 });
        grades.Add(new Grade { subject = Subject.Math, score = 89, name = "Olezik", date = new DateTime(2025, 02, 15), id = 2 });
        grades.Add(new Grade { subject = Subject.Physics, score = 100, name = "Olezik", date = new DateTime(2025, 02, 14), id = 3 });
        grades.Add(new Grade { subject = Subject.Physics, score = 5, name = "Olezik", date = new DateTime(2025, 02, 15), id = 4 });
        int currentId = 0;

        while (true)
        {
            Console.WriteLine("1. Показать оценку по её номеру в журнале");
            Console.WriteLine("2. Показать все оценки");
            Console.WriteLine("3. Поиск оценок по предмету");
            Console.WriteLine("4. Удалить оценку");
            Console.WriteLine("5. Добавить студента");
            Console.WriteLine("6. Выход");
            int choice = Convert.ToInt16(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите номер оценки в журнале: ");
                    currentId = Convert.ToInt16(Console.ReadLine());
                    foreach (var grade in grades)
                    {
                        if (currentId == grade.id)
                        {
                            grade.Print();
                        }
                        else
                        {
                            ErrorMessage.Print();
                            break;
                        }
                    }
                    break;
                case 2:
                    foreach (var grade in grades)
                    {
                        grade.Print();
                    }
                    break;
                case 3:
                    Console.Write("Введите название предмета:");
                    string currentSubject = Console.ReadLine();
                    switch (currentSubject)
                    {
                        case "math" or "Math":
                            foreach (var grade in grades)
                            {
                                if (grade.subject == Subject.Math)
                                {
                                    grade.Print();
                                }
                            }
                            break;
                        case "physics" or "Physics":
                            foreach (var grade in grades)
                            {
                                if (grade.subject == Subject.Physics)
                                {
                                    grade.Print();
                                }
                            }
                            break;
                        default:
                            ErrorMessage.Print();
                            break;
                    }
                    break;
                case 4:
                    Console.Write("Введите номер оценки: ");
                    currentId = Convert.ToInt16(Console.ReadLine());
                    int indexToRemove = grades.FindIndex(g => g.id == currentId);
                    grades.RemoveAt(indexToRemove);
                    Console.WriteLine("Оценка удалена");
                    goto case 2;
                case 5:
                    break;
                case 6:
                    return;
                default:
                    ErrorMessage.Print();
                    break;
            }
        }
    }
}

