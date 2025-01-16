namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(2, 4);
            Circle cir = new Circle(3);

            Console.WriteLine(rec.Draw());
            Console.WriteLine(cir.Draw());
        }
    }
}
