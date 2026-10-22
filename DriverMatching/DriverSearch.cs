using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverMatching
{

    public class DriverSearch
    {
        public static long GetDistance(Driver driver, int x, int y)
        {
            long dx = (long)driver.X - x;
            long dy = (long)driver.Y - y;

            return dx * dx + dy * dy;
        }

        public static List<Driver> FindNearestBySorting(DriverMap map, int x, int y)
        {
            if (map.IsInside(x, y) == false)
            {
                throw new Exception("Заказ вне карты");
            }

            List<Driver> drivers = map.GetDrivers();

            for (int i = 0; i < drivers.Count - 1; i++)
            {
                for (int j = 0; j < drivers.Count - 1 - i; j++)
                {
                    long d1 = GetDistance(drivers[j], x, y);
                    long d2 = GetDistance(drivers[j + 1], x, y);

                    if (d1 > d2 ||
                        (d1 == d2 && drivers[j].Id > drivers[j + 1].Id))
                    {
                        Driver temp = drivers[j];
                        drivers[j] = drivers[j + 1];
                        drivers[j + 1] = temp;
                    }
                }
            }

            List<Driver> result = new List<Driver>();

            for (int i = 0; i < drivers.Count && i < 5; i++)
            {
                result.Add(drivers[i]);
            }

            return result;
        }

        public static List<Driver> FindNearestBySearch(DriverMap map, int x, int y)
        {
            if (map.IsInside(x, y) == false)
            {
                throw new Exception("Заказ вне карты");
            }

            List<Driver> drivers = map.GetDrivers();
            List<Driver> result = new List<Driver>();

            bool[] used = new bool[drivers.Count];

            for (int k = 0; k < 5 && k < drivers.Count; k++)
            {
                int bestIndex = -1;
                long bestDistance = long.MaxValue;

                for (int i = 0; i < drivers.Count; i++)
                {
                    if (used[i] == false)
                    {
                        long distance = GetDistance(drivers[i], x, y);

                        if (bestIndex == -1 || distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestIndex = i;
                        }
                        else if (distance == bestDistance && drivers[i].Id < drivers[bestIndex].Id)
                        {
                            bestIndex = i;
                        }
                    }
                }

                used[bestIndex] = true;
                result.Add(drivers[bestIndex]);
            }

            return result;
        }

        public static List<Driver> FindNearestByQueue(DriverMap map, int x, int y)
        {
            if (map.IsInside(x, y) == false)
            {
                throw new Exception("Заказ вне карты");
            }

            List<Driver> drivers = map.GetDrivers();
            List<Driver> result = new List<Driver>();

            PriorityQueue<Driver, (long, int)> queue = new PriorityQueue<Driver, (long, int)>();

            for (int i = 0; i < drivers.Count; i++)
            {
                long distance = GetDistance(drivers[i], x, y);

                queue.Enqueue(drivers[i], (distance, drivers[i].Id));
            }

            for (int i = 0; i < 5; i++)
            {
                if (queue.Count > 0)
                {
                    Driver driver = queue.Dequeue();
                    result.Add(driver);
                }
            }

            return result;
        }
    }

}
