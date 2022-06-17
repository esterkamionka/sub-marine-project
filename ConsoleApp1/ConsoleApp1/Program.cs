using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.print();
            Console.WriteLine();

            while (!board.Win())
            {
                Console.WriteLine("Select a row to attack");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Select column to attack");
                int col = Convert.ToInt32(Console.ReadLine());
                Point p = board.Points[board.Points.FindIndex(po => po.Row == row && po.Col == col)];
                if (p is Sea)
                    Console.WriteLine(message.bungling);
                else
                {
                    SubmarineCell cell = p as SubmarineCell;
                    if (cell != null)
                    {
                        if (cell.IsSunk)
                            Console.WriteLine(Convert.ToString(message.bungling));
                        else
                        {
                            cell.IsSunk = true;
                            board.SubMarines[board.SubMarines.FindIndex(s => s.Type == cell.Type)].NumOfHits += 1;
                            if (board.SubMarines[board.SubMarines.FindIndex(s => s.Type == cell.Type)].IsSunk)
                                Console.WriteLine(Convert.ToString(message.boom));
                            else Console.WriteLine(Convert.ToString(message.hit));
                        }
                    }
                }
            }
            Console.WriteLine("win!!!");
        }

    }
}
