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
        int sum = 0;

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
        public void randomSubMarines(SubMarine subMarine)
        {
            //בחירת מיקום רנדומלי על הלוח
            Random rand = new Random();
            int row = rand.Next(1, 6);
            int col = rand.Next(1, 6);
            int direction = new Random().Next(1, 3);
            Point p = new SubmarineCell(row, col, subMarine.Type);
            //בחירה רנדומלית באיזה כיוון למקם את הצוללת: אנכית או אופקית
            if (direction == 1)
                cell_Position_Horizontal(p, subMarine);//אופקי
            else cell_Position_Vertical(p, subMarine);//אנכי
        }//סידור אקראי של צוללות
        public void cell_Position_Horizontal(Point pos, SubMarine subMarine)//מיקום אופקי
        {
            int endCol = pos.Col;
            if (pos.Col + subMarine.Length <= 5)
                endCol = pos.Col + subMarine.Length;
            if (pos.Col < endCol)
            {
                //בדיקה אם אין צוללות בטווח הדרוש
                if (checkCellPositionCol(pos.Col, endCol, pos))
                {
                    for (int i = pos.Col; i < endCol; i++)
                    {
                        points[points.FindIndex(p => p.Col == i && p.Row == pos.Row)] = new SubmarineCell(pos.Row, i, subMarine.Type);


                    }
                  
                }
                else randomSubMarines(subMarine);
            }
            else randomSubMarines(subMarine);
        }
        public void cell_Position_Vertical(Point pos, SubMarine subMarine)//מיקום אנכי
        {
            int endRow = pos.Row;
            if (pos.Row + subMarine.Length <= 5)
                endRow = pos.Row + subMarine.Length;
            if (pos.Row < endRow)
            {
                //בדיקה אם אין צוללות בטווח הדרוש
                if (checkCellPositionRow(pos.Row, endRow, pos))
                {
                    for (int i = pos.Row; i < endRow; i++)
                    {
                        points[points.FindIndex(p => p.Col == pos.Col && p.Row == i)] = new SubmarineCell(i, pos.Col, subMarine.Type);

                    }
                }
                else randomSubMarines(subMarine);
            }
            else randomSubMarines(subMarine);
        }
        public bool checkCellPositionRow(int row, int endRow, Point pos)//בדיקה שאין צוללות בטווח הדרוש
        {

            while (row < endRow)
            {
                if (points[points.FindIndex(p => p.Col == pos.Col && p.Row == row)] is SubmarineCell)
                    return false;
                row++;
            }
            return true;
        }
        public bool checkCellPositionCol(int col, int endCol, Point pos)//בדיקה שאין צוללות בטווח הדרוש
        {

            while (col < endCol)
            {
                if (points[points.FindIndex(p => p.Col == col && p.Row == p.Row)] is SubmarineCell)
                    return false;
                col++;
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
