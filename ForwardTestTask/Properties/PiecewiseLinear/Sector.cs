using System;
namespace ForwardTestTask
{
    class Sector
    {
        public Sector(Point left, Point right)
        {
            this.left = left;
            this.right = right;
            linearFunction = new LinearFunction(left, right);
        }
        public bool Contains(double x)
        {
            return (left.x <= x) && (x <= right.x);
        }
        public double Calculate(double x)
        {
            return linearFunction.Calculate(x);
        }
        LinearFunction linearFunction;
        Point left;
        Point right;
    }
}
