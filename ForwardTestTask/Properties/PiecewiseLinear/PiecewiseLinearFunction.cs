using System;
using System.Collections.Generic;
using System.Linq;
namespace ForwardTestTask
{
    public class PiecewiseLinearFunction
    {
        public PiecewiseLinearFunction(List<double> args, List<double> values):
                    this(CreatePointList(args, values)
        )
        { 
        }
        private static List<Point> CreatePointList(List<double> args, List<double> values)
        {
            if (args.Count != values.Count)
            {
                return null;
            }
            var res = args.Zip(values, (x, y) => new Point(x, y));
            return res.ToList();
        }
        private PiecewiseLinearFunction(List<Point> points)
        {
            if(points==null || points.Count < 2)
            {
                throw new Exception("Not a piecewise linear function");
            }
            points.Sort((p0, p1) => p0.x.CompareTo(p1.x));
            for (int i = 1; i < points.Count; ++i)
            {
                sectors.Add(new Sector(points[i-1], points[i]));
            }
            nearestSector = sectors.GetEnumerator();
            nearestSector.MoveNext();
        }
        private Sector GetBoundingSector(double x)
        {
            if (nearestSector.Current.Contains(x))
            {
                return nearestSector.Current;
            }
            nearestSector.MoveNext();
            if (nearestSector.Current != null && nearestSector.Current.Contains(x))
            {
                return nearestSector.Current;
            }
            //if the argument isn't near the previous, just finding the sector
            return sectors.Find((obj) => obj.Contains(x));
        }
        public double Calculate(double x)
        {

            var sector = GetBoundingSector(x);
            if(sector==null)
            {
                throw new ArgumentOutOfRangeException(Convert.ToString(x));
            }
            return sector.Calculate(x);
        }
        private List<Sector> sectors = new List<Sector>();
        private IEnumerator<Sector> nearestSector; 
    }
}
