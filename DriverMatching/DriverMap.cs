using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverMatching
{
    public class DriverMap
    {
        public int Width;
        public int Height;

        private List<Driver> drivers = new List<Driver>();

        public DriverMap(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new Exception("Неверный размер карты");
            }

            Width = width;
            Height = height;
        }

        public void AddOrUpdateDriver(int id, int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                throw new Exception("Координаты вне карты");
            }

            for (int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].X == x && drivers[i].Y == y
                    && drivers[i].Id != id)
                {
                    throw new Exception("Место занято");
                }
            }

            for (int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].Id == id)
                {
                    drivers[i].X = x;
                    drivers[i].Y = y;
                    return;
                }
            }

            Driver driver = new Driver(id, x, y);
            drivers.Add(driver);
        }

        public List<Driver> GetDrivers()
        {
            return new List<Driver>(drivers);
        }

        public bool IsInside(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return false;
            }

            return true;
        }
    }
}
