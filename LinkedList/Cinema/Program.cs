using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema = new Cinema();

            Console.WriteLine("Всего залов");
            cinema.Count = int.Parse(Console.ReadLine());

            cinema.Creator(840);

            cinema.Write();
        }
    }
}
