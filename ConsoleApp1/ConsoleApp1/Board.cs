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
        }//הדפסה
        public void randomSubMarines(SubMarine subMarine)//מיקום רנדומלי של הצוללת
        {
            Random random = new Random();
            int row = random.Next(1, 6);
            int col = random.Next(1, 6);
            int direction = random.Next(1, 3);
            SubmarineCell position = new SubmarineCell(row, col, subMarine.Type);
            if (direction == 1 && col <= 6 - subMarine.Length)//מיקום אופקי 
            {
                subMarine.Build_Horizontal(position);
                if (chek_Position(position, subMarine))
                    pootSubMarineCell(subMarine);
                else
                {
                    subMarine.SubmarineCells.Clear();
                    randomSubMarines(subMarine);
                }
            }
            else if (direction == 2 && row <= 6 - subMarine.Length)//מיקום אנכי
            {
                subMarine.Build_Vertical(position);
                if (chek_Position(position, subMarine))
                    pootSubMarineCell(subMarine);
                else
                {
                    subMarine.SubmarineCells.Clear();
                    randomSubMarines(subMarine);
                }
            }
            else randomSubMarines(subMarine);
        }

     public void pootSubMarineCell(SubMarine subMarine)//מיקום הצוללות
        {
            for (int i = 0; i < subMarine.SubmarineCells.Count; i++)
                points[points.FindIndex(p => p.Row == subMarine.SubmarineCells[i].Row &&
                p.Col == subMarine.SubmarineCells[i].Col)] = subMarine.SubmarineCells[i];
        }
        public bool chek_Position(SubmarineCell position, SubMarine subMarine)//בדיקה שאין צוללות בטווח הדרוש
        {
            for (int i = 0; i < subMarine.SubmarineCells.Count; i++)
                if (points[points.FindIndex(p => p.Row == subMarine.SubmarineCells[i].Row &&
                 p.Col == subMarine.SubmarineCells[i].Col)] is SubmarineCell)
                    return false;
            return true;
        }



        public bool Win()//האם נצחתי?
        {
            for (int i = 0; i < subMarines.Count; i++)
                if (!(subMarines[i].IsSunk))
                    return false;
            return true;
        }
    }


}
