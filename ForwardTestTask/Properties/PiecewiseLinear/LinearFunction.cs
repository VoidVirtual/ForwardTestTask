using System;
namespace ForwardTestTask
{
    class LinearFunction
    {
        public LinearFunction(Point p0, Point p1)
        {
            if (p0.x.Equals(p1.x))
            {
                throw new Exception("Not a linear funciton");
            }
            k = (p1.y - p0.y) / (p1.x - p0.x);
            b = (p1.x * p0.y - p1.y * p0.x) / (p1.x - p0.x);
        }
        public double Calculate(double x)
        {
            return k * x + b;
        }
        private double k;
        private double b;
    }
}
