class Program
{
    private static List<Grade> grades = new List<Grade>();

    public enum Subject
    {
        Math,
        Physics
    }
    public struct Grade
    {
        public Subject subject;
        public int score;
        public string name;
        public DateTime date;
        public int id;
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
            Console.WriteLine("5. Выход");
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
                            Console.WriteLine($"Предмет:{grade.subject}, Оценка: {grade.score}, Имя студента: {grade.name}, Дата: {grade.date}");
                        }
                        else
                        {                         
                            Console.WriteLine("Совпадений не найдено!");
                            break;
                        }
                    }
                    break;
                case 2:
                    foreach (var grade in grades)
                    {  
                        Console.WriteLine($"Предмет:{grade.subject}, Оценка: {grade.score}, Имя студента: {grade.name}, Дата: {grade.date}, Номер: {grade.id}");
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
                                    Console.WriteLine($"Предмет:{grade.subject}, Оценка: {grade.score}, Имя студента: {grade.name}, Дата: {grade.date}");
                                }
                            }
                            break;
                        case "physics" or "Physics":
                            foreach (var grade in grades)
                            {
                                if (grade.subject == Subject.Physics)
                                {
                                    Console.WriteLine($"Предмет:{grade.subject}, Оценка: {grade.score}, Имя студента: {grade.name}, Дата: {grade.date}");
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Совпадений не найдено!");
                            break;
                    }
                    break;
                case 4:
                    Console.Write("Введите номер оценки: ");
                    currentId = Convert.ToInt16(Console.ReadLine());
                    int indexToRemove = grades.FindIndex(g =>  g.id == currentId);
                    grades.RemoveAt(indexToRemove);
                    Console.WriteLine("Оценка удалена");
                    goto case 2;
                case 5:
                    return;
                default:
                    Console.WriteLine("Ошибка ввода");
                    break;
            }
        }
    }
}
