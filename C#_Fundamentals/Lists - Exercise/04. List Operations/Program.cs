namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string operation;
            while ((operation = Console.ReadLine()) != "End")
            {
                string[] elements = operation.Split().ToArray();
                switch (elements[0])
                {
                    case "Add":
                        int numberAdd = int.Parse(elements[1]);
                        numbers.Add(numberAdd);
                       
                        break;
                    case "Insert":
                        int numberInsert = int.Parse(elements[1]);
                        int indexInsert = int.Parse(elements[2]);
                        if (indexInsert < 0 || indexInsert >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.Insert(indexInsert, numberInsert);
                        }

                        break;
                    case "Remove":
                        int indexRemove = int.Parse(elements[1]);
                        if (indexRemove < 0 || indexRemove >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.RemoveAt(indexRemove);
                        }
                            break;
                    case "Shift":
                        string leftOrRight = elements[1];
                        int count = int.Parse(elements[2]);
                        switch(leftOrRight)
                        {
                            case "left":
                                for (int i = 1; i <= count; i++)
                                {
                                    numbers.Add(numbers[0]);
                                    numbers.RemoveAt(0);
                                }
                                break;
                            case "right":
                                for (int i = 1; i <= count; i++)
                                {
                                    numbers.Insert(0, numbers[numbers.Count - 1]);
                                    numbers.RemoveAt(numbers.Count - 1);
                                }

                                break;
                        }
                        break;
                    
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
