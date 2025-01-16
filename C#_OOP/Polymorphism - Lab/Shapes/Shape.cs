using System.Runtime.InteropServices;

namespace Shapes
{
    public abstract class Shape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();

        public virtual string Draw()
        {
            string classType = GetType().Name;
            return $"Drawing {classType}";
        }

    }
}
