namespace DriverMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DriverMap map = new DriverMap(10, 10);

            //Добавление водителей
            map.AddOrUpdateDriver(1, 1, 1);
            map.AddOrUpdateDriver(2, 4, 4);
            map.AddOrUpdateDriver(3, 8, 8);
            map.AddOrUpdateDriver(4, 4, 6);
            map.AddOrUpdateDriver(5, 3, 5);
            map.AddOrUpdateDriver(6, 7, 5);
            map.AddOrUpdateDriver(7, 9, 0);

            //Кординаты заказа
            int orderX = 4;
            int orderY = 5;

            Console.WriteLine("Заказ находится в точке:");
            Console.WriteLine("X = " + orderX + ", Y = " + orderY);
            Console.WriteLine();

            Console.WriteLine("Первый алгоритм (сортировка):");

            List<Driver> result1 = DriverSearch.FindNearestBySorting(map, orderX, orderY);

            for (int i = 0; i < result1.Count; i++)
            {
                Console.WriteLine(
                    "Водитель ID: " + result1[i].Id +
                    " X: " + result1[i].X +
                    " Y: " + result1[i].Y);
            }

            Console.WriteLine();

            Console.WriteLine("Второй алгоритм (поиск ближайших):");

            List<Driver> result2 = DriverSearch.FindNearestBySearch(map, orderX, orderY);

            for (int i = 0; i < result2.Count; i++)
            {
                Console.WriteLine(
                    "Водитель ID: " + result2[i].Id +
                    " X: " + result2[i].X +
                    " Y: " + result2[i].Y);
            }

            Console.WriteLine();

            Console.WriteLine("Третий алгоритм (очередь):");

            List<Driver> result3 = DriverSearch.FindNearestByQueue(map, orderX, orderY);

            for (int i = 0; i < result3.Count; i++)
            {
                Console.WriteLine(
                    "Водитель ID: " + result3[i].Id +
                    " X: " + result3[i].X +
                    " Y: " + result3[i].Y);
            }
        }
    }
}
