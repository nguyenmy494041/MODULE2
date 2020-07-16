using System;
using System.Collections.Generic;
using System.Text;

namespace BAi7_CleanCode
{
    class BaiatpRefactoring
    {
        static void Main(string[] args)
        {
            TennisGame vandau = new TennisGame();
            vandau.Show(5, 6);

        }
    }
    public class TennisGame
    {
        public String Point(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";

                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Fourty";
                default: return "Match point";
            }
        }
        public string Point_Point(int point1, int point2)
        {
            if (point1 == point2)
            {
                if (point2 == 4) return "Fourty-All";

                return Point(point2) + "-All";

            }
            return Point(point1) + " - " + Point(point2);
        }
        public void Score(int point1, int point2)
        {
            string score = "";
            int minusResult = point1 - point2;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else if (minusResult <= -2) score = "Win for player2";
            else score = "Fourty - All";
            Console.WriteLine(score);

        }
        public void Show(int point1, int point2)
        {
            if (point1 > 4 || point2 > 4) Score(point1, point2);
            if (point1 <= 4 && point1 >= 0 && point2 >= 0 && point2 <= 4)
                Console.WriteLine(Point_Point(point1, point2));
        }
    }
}
