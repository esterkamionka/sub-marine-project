using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Board
    {

        private List<Point> points;
        private List<SubMarine> subMarines;


        public List<Point> Points { get { return points; } }
        public List<SubMarine> SubMarines { get { return subMarines; } }

        public Board()
        {
            points = new List<Point>();
            for (int row = 1; row <= 5; row++)
                for (int col = 1; col <= 5; col++)
                    points.Add(new Sea(row, col));
            subMarines = new List<SubMarine>();
            subMarines.Add(new Submarine4());
            subMarines.Add(new Submarine3());
            subMarines.Add(new Submarine2());
            subMarines.Add(new SubMarine1());
            for (int i = 0; i < subMarines.Count; i++)
                randomSubMarines(subMarines[i]);
        }

        public void print()
        {
            Console.Write(points[0]);
            for (int i = 1; i < this.points.Count; i++)
            {
                if (points[i].Col < points[i - 1].Col)
                    Console.WriteLine();
                Console.Write(points[i].ToString());

            }
            Console.WriteLine();
            Console.WriteLine();

        }
        public void randomSubMarines(SubMarine subMarine)//מיקום רנדומלי של הצוללת
        {
            Random random = new Random();
            int row = random.Next(1, 6);
            int col = random.Next(1, 6);
            int direction = random.Next(1, 3);
            Point position = new SubmarineCell(row, col, subMarine.Type);
            if (direction == 1)
                position_Horizontal(position, subMarine);//אופקי
            else position_Vertical(position, subMarine);//אנכי


        }
        public void position_Vertical(Point position, SubMarine subMarine)//אנכי
        {
            int endRow = position.Row;
            if (position.Row + subMarine.Length <= 5)
                endRow = position.Row + subMarine.Length;
            if (endRow > position.Row)
            {
                if (chek_Position_Vertical(position, endRow, subMarine))//בדיקה שאין צוללות בטווח הדרוש
                {
                    for (int i = position.Row; i < endRow; i++)
                    {
                        points[points.FindIndex(p => p.Row == i && p.Col == position.Col)]
                            = new SubmarineCell(i, position.Col, subMarine.Type);
                    }
                }
                else randomSubMarines(subMarine);
            }
            else randomSubMarines(subMarine);
        }
        public bool chek_Position_Vertical(Point position, int endRow, SubMarine subMarine)//בדיקה שאין צוללות בטווח הדרוש
        {
            for (int i = position.Row; i < endRow; i++)
            {
                if (points[points.FindIndex(p => p.Row == i && p.Col == position.Col)] is SubmarineCell)
                    return false;
            }
            return true;
        }
        public void position_Horizontal(Point position, SubMarine subMarine)//מיקום אופקי
        {
            int endCol = position.Col;
            if (position.Col + subMarine.Length <= 6)
                endCol = position.Col + subMarine.Length;
            if (position.Col < endCol)
            {
                if (chek_Position_Horizontal(position, endCol, subMarine))
                {
                    for (int i = position.Col; i < endCol; i++)
                        points[points.FindIndex(p => p.Row == position.Row && p.Col == i)]
                            = new SubmarineCell(position.Row, i, subMarine.Type);
                }
                else randomSubMarines(subMarine);
            }
            else randomSubMarines(subMarine);
        }
        public bool chek_Position_Horizontal(Point position, int endCol, SubMarine subMarine)//בדיקה שאין צוללות בטווח הדרוש
        {
            for (int i = position.Col; i < endCol; i++)
            {
                if (points[points.FindIndex(p => p.Row == position.Row && p.Col == i)] is SubmarineCell)
                    return false;
            }
            return true;
        }



        public bool Win()
        {
            for (int i = 0; i < subMarines.Count; i++)
                if (!(subMarines[i].IsSunk))
                    return false;
            return true;
        }
    }


}
