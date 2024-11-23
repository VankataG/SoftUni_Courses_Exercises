namespace _10._SoftUni_Course_Planning


{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            string command;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] commands = command.Split(":").ToArray();
                switch (commands[0])
                {
                    case "Add":

                        AddLesson(lessons, commands);
                        break;
                    case "Insert":
                        InsertLesson(lessons, commands);
                        break;
                    case "Remove":
                        RemoveLesson(lessons, commands);
                        break;
                    case "Swap":
                        SwapLessons(lessons, commands);
                        break;
                    case "Exercise":
                        AddExercise(lessons, commands);
                        break;
                }
            }
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
        static void AddLesson(List<string> lessons, string[] commands)
        {
            string lesson = commands[1];
            if (!(lessons.Contains(lesson)))
            { lessons.Add(lesson); }
        }
        static void InsertLesson(List<string> lessons, string[] commands)
        {
            string lesson = commands[1];
            int index = int.Parse(commands[2]);
            if (!(lessons.Contains(lesson)))
                lessons.Insert(index, lesson);
        }
        static void RemoveLesson(List<string> lessons, string[] commands)
        {
            string lesson = commands[1];
            if (lessons.Contains(lesson))
                lessons.Remove(lesson);
            if (lessons.Contains($"{lesson}-Exercise"))
            {
                lessons.Remove($"{lesson}-Exercise");
            }
        }
        static void SwapLessons(List<string> lessons, string[] commands)
        {
            string lesson1 = commands[1];
            string lesson2 = commands[2];
            if (lessons.Contains(lesson1) && lessons.Contains(lesson2))
            {
                string lesson1Copy = lesson1;
                int index1 = lessons.IndexOf(lesson1);
                int index2 = lessons.IndexOf(lesson2);
                lessons[index1] = lesson2;
                lessons[index2] = lesson1Copy;

                if (lessons.Contains($"{lesson1}-Exercise"))
                {
                    lessons.Remove($"{lesson1}-Exercise");
                    lessons.Insert(index2 + 1, $"{lesson1}-Exercise");
                }
                if (lessons.Contains($"{lesson2}-Exercise"))
                {
                    lessons.Remove($"{lesson2}-Exercise");
                    lessons.Insert(index1 + 1, $"{lesson2}-Exercise");
                }
            }
        }
        static void AddExercise(List<string> lessons, string[] commands)
        {
            string lesson = commands[1];
            if ((lessons.Contains(lesson)) && !(lessons.Contains($"{lesson}-Exercise")))
            {
                int index = lessons.IndexOf(lesson);
                lessons.Insert(index + 1, $"{lesson}-Exercise");
            }
            else if (!(lessons.Contains(lesson)))
            {
                lessons.Add(lesson);
                lessons.Add($"{lesson}-Exercise");
            }


        }
    }

}
