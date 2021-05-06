using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRun
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessCalculateRoute BusinessCalculateRoute = new BusinessCalculateRoute();

            BusinessCalculateRoute.GetBestRoute();
        }
    }
}
