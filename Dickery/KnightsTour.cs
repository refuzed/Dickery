using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickery
{
    public static class KnightsTour
    {
        public const int BoardSize = 8;

        public static void Run()
        {
            var step = 0;
            var position = new Position(0, 0);
            var bestMove = new Position(0, 0);

            while (bestMove != null)
            {
                position.Step = ++step;
                bestMove = position.GetBestMove();
                position = bestMove ?? position;
            }

            PrintBoard(position.Visited, step);
        }

        private static void PrintBoard(int[,] visited, int step)
        {
            for(int i = 0; i < BoardSize; i++)
            {
                for(int j = 0; j < BoardSize; j++)
                {
                    Console.Write(string.Format("{0,3}", visited[i, j]));
                }
                Console.WriteLine();
            }

            Console.WriteLine("Total Moves: " + step);
            Console.ReadKey();
        }
    }

    public class Position
    {
        private int _x;
        private int _y;
        private int[,] _visited;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int[,] Visited { get { return _visited; } }

        public int Step { set { _visited[_x, _y] = value; } }

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
            _visited = new int[KnightsTour.BoardSize, KnightsTour.BoardSize];
        }

        public Position(int x, int y, int[,] visited)
        {
            _x = x;
            _y = y;
            _visited = visited;
        }
    }

    public static class PositionExtensions
    {
        public static int CountAvailableMoves(this Position position)
        {
            return position.GetAvailableMoves().Count();
        }

        public static Position GetBestMove(this Position position)
        {
            return position.GetAvailableMoves().OrderBy(move => move.CountAvailableMoves()).FirstOrDefault();
        }

        public static List<Position> GetAvailableMoves(this Position position)
        {
            var potentialMoves = new List<Position> {
                    position.GetPositionOffset(1, 2),
                    position.GetPositionOffset(2, 1),
                    position.GetPositionOffset(2, -1),
                    position.GetPositionOffset(1, -2),
                    position.GetPositionOffset(-1, -2),
                    position.GetPositionOffset(-2, -1),
                    position.GetPositionOffset(-2, 1),
                    position.GetPositionOffset(-1, 2)
                };

            var validMoves = potentialMoves.Where(move => move.IsValid());
            var availableMoves = validMoves.Where(move => move.IsAvailable());
            return availableMoves.ToList();
        }

        public static Position GetPositionOffset(this Position position, int x, int y)
        {
            return new Position(position.X + x, position.Y + y, position.Visited);
        }

        public static bool IsValid(this Position position)
        {
            if (position.X < 0) return false;
            if (position.Y < 0) return false;
            if (position.X >= KnightsTour.BoardSize) return false;
            if (position.Y >= KnightsTour.BoardSize) return false;
            
            return true;
        }

        public static bool IsAvailable(this Position position)
        {
            if (position.Visited[position.X, position.Y] == 0) return true;
            return false;
        }
    }
}
