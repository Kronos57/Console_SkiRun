using SkiRun.Transversal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRun
{
    public class BusinessCalculateRoute
    {
        public int[,] Map { get; set; }

        public int MapSize { get; set; }

        public int Max { get; set; }

        public List<int> RouteOption { get; set; }

        public List<List<int>> RouteOptionList { get; set; }

        public List<int> BestRoute { get; set; }


        public BusinessCalculateRoute()
        {
            this.MapSize = 4;
            this.Map = new int[4, 4] { { 4, 8, 7, 3 }, { 2, 5, 9, 3 }, { 6, 3, 2, 5 }, { 4, 4, 1, 6 } }; ;
            this.Max = 0;
            this.RouteOption = new List<int>();
            this.RouteOptionList = new List<List<int>>();
            this.BestRoute = new List<int>();
        }

        /// <summary>
        /// Initialize the process to get the best route in a Map
        /// </summary>
        public void GetBestRoute()
        {
            MapPosition rowMaxPosition = new MapPosition();

            for (int x = 0; x < MapSize; x++)
            {
                for (int y = 0; y < MapSize; y++)
                {
                    if (Map[x, y] > Max)
                    {
                        Max = Map[x, y];

                        rowMaxPosition.Value = Max;
                        rowMaxPosition.RowPosition = x;
                        rowMaxPosition.ColumnPosition = y;
                    }
                }

                this.CalculateBestRoute(rowMaxPosition);
            }
        }

        /// <summary>
        /// Calculate the Best Route
        /// </summary>
        /// <param name="mapPosition"></param>
        private void CalculateBestRoute(MapPosition mapPosition)
        {
            //Add value to Route
            RouteOption.Add(mapPosition.Value);

            //Load closer values
            MapPositionAroundValues mapPositionAroundValues = this.GetAroundValues(mapPosition);

            //Calculate next position
            MapPosition nextPosition = this.CalculateNextPosition(mapPositionAroundValues);

            //Validate next position
            if (nextPosition.Value > 0)
            {
                CalculateBestRoute(nextPosition);
            }
            else
            {
                RouteOptionList.Add(RouteOption);

                CompareRoutes();

                PrintBestRoute();
            }
        }

        /// <summary>
        /// Load closer values
        /// </summary>
        /// <param name="rowMaxPosition"></param>
        /// <returns></returns>
        private MapPositionAroundValues GetAroundValues(MapPosition rowMaxPosition)
        {
            int x = rowMaxPosition.RowPosition;
            int y = rowMaxPosition.ColumnPosition;

            MapPositionAroundValues mapPositionAroundValues = new MapPositionAroundValues
            {
                Value = rowMaxPosition,

                UpValue = new MapPosition(x - 1 < 0 ? 0 : Map[(x - 1), y], (x - 1), y),

                DownValue = new MapPosition(x + 1 > (MapSize - 1) ? 0 : Map[(x + 1), y], (x + 1), y),

                Leftvalue = new MapPosition(y - 1 < 0 ? 0 : Map[x, (y - 1)], x, (y - 1)),

                RightValue = new MapPosition(y + 1 > (MapSize - 1) ? 0 : Map[x, (y + 1)], x, (y + 1))
            };

            return mapPositionAroundValues;
        }

        /// <summary>
        /// Calculate next position
        /// </summary>
        /// <param name="mapPositionAroundValues"></param>
        /// <returns></returns>
        private MapPosition CalculateNextPosition(MapPositionAroundValues mapPositionAroundValues)
        {
            int a = mapPositionAroundValues.Leftvalue.Value;
            int b = mapPositionAroundValues.DownValue.Value;
            int c = mapPositionAroundValues.RightValue.Value;

            MapPosition MaxValue = new MapPosition();
            string result = "";

            if (a < b)
            {
                if (b < c)
                {
                    result = "c";
                }
                else
                {
                    result = "b";
                }
            }
            else if (a > b)
            {
                if (a < c)
                {
                    result = "c";
                }
                else
                {
                    result = "a";
                }
            }

            switch (result)
            {
                case "a":
                    MaxValue = mapPositionAroundValues.Leftvalue;
                    break;

                case "b":
                    MaxValue = mapPositionAroundValues.DownValue;
                    break;
                case "c":
                    MaxValue = mapPositionAroundValues.RightValue;
                    break;
                default:
                    break;
            }

            return MaxValue;
        }

        /// <summary>
        /// Compare finding routes
        /// </summary>
        private void CompareRoutes()
        {
            int count = 0;

            foreach (List<int> route in RouteOptionList)
            {
                if (route.Count > count)
                {
                    count = route.Count;
                }

                if (count > BestRoute.Count)
                {
                    BestRoute = route;
                }
            }
        }

        /// <summary>
        /// Print the Best finding Route
        /// </summary>
        private void PrintBestRoute()
        {
            foreach (var item in BestRoute)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
    }
}
