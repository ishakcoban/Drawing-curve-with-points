using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3HW
{
    class Curve
    {
        public List<point> points = new List<point>();





        public void RemovePoint(point point)
        {
            points.Remove(point);

        }
        public void AddPoint(point point)
        {
            points.Add(point);
        }

        public int CurveLength()
        {
            double sum = 0;

            int j = 1;

            for (int i = 0; i < points.Count; i++)
            {
                while (j < points.Count)
                {

                    sum += Math.Sqrt(Math.Abs(Math.Pow(points[i].x - points[j].x, 2) + Math.Pow(points[i].y - points[j].y, 2)));
                    break;

                }
            }
           
            return (int)sum;
        }



    }
}
