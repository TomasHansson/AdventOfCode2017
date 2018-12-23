using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017
{
    class Day03
    {
        public static int FindDistance(int input)
        {
            List<Point> points = new List<Point>();
            int x = 0;
            int y = 0;
            int currentPoint = 1;
            int pointsToTurn = 1;
            int movesInPreviousDirection = 1;
            int direction = 1;
            while (currentPoint <= input)
            {
                points.Add(new Point(currentPoint++, x, y));
                if (direction == (int)Direction.right)
                    x++;
                else if (direction == (int)Direction.up)
                    y++;
                else if (direction == (int)Direction.left)
                    x--;
                else if (direction == (int)Direction.down)
                    y--;
                pointsToTurn--;
                if (pointsToTurn == 0 && (direction == (int)Direction.up || direction == (int)Direction.down))
                {
                    pointsToTurn = ++movesInPreviousDirection;
                    direction = direction == (int)Direction.up ? (int)Direction.left : (int)Direction.right;
                }
                else if (pointsToTurn == 0 && (direction == (int)Direction.right || direction == (int)Direction.left))
                {
                    pointsToTurn = movesInPreviousDirection;
                    direction = direction == (int)Direction.right ? (int)Direction.up : (int)Direction.down;
                }
            }
            Point firstPoint = points.First();
            Point lastPoint = points.Last();
            return Math.Abs(firstPoint._x - lastPoint._x) + Math.Abs(firstPoint._y - lastPoint._y);
        }

        // My solution to the first problem, using the struct Point, didn't lend itself very well for the second problem which is why I used a different approach here.
        public static int FindFirstLarger(int input)
        {
            int offset = (int)Math.Sqrt(input) + 1;
            int widthOfMatrix = offset * 2;
            int[,] matrix = new int[widthOfMatrix, widthOfMatrix];
            int x = 0;
            int y = 0;
            int currentValue = 0;
            int pointsToTurn = 1;
            int movesInPreviousDirection = 1;
            int direction = (int)Direction.right;
            while (currentValue <= input)
            {
                currentValue = 0;
                currentValue += matrix[x + offset + 1, y + offset - 1];
                currentValue += matrix[x + offset + 1, y + offset];
                currentValue += matrix[x + offset + 1, y + offset + 1];
                currentValue += matrix[x + offset - 1, y + offset - 1];
                currentValue += matrix[x + offset - 1, y + offset];
                currentValue += matrix[x + offset - 1, y + offset + 1];
                currentValue += matrix[x + offset, y + offset - 1];
                currentValue += matrix[x + offset, y + offset + 1];
                currentValue = currentValue == 0 ? 1 : currentValue;
                matrix[x + offset, y + offset] = currentValue;
                if (direction == (int)Direction.right)
                    x++;
                else if (direction == (int)Direction.up)
                    y++;
                else if (direction == (int)Direction.left)
                    x--;
                else if (direction == (int)Direction.down)
                    y--;
                pointsToTurn--;
                if (pointsToTurn == 0 && (direction == (int)Direction.up || direction == (int)Direction.down))
                {
                    pointsToTurn = ++movesInPreviousDirection;
                    direction = direction == (int)Direction.up ? (int)Direction.left : (int)Direction.right;
                }
                else if (pointsToTurn == 0 && (direction == (int)Direction.right || direction == (int)Direction.left))
                {
                    pointsToTurn = movesInPreviousDirection;
                    direction = direction == (int)Direction.right ? (int)Direction.up : (int)Direction.down;
                }
            }
            return currentValue;
        }
    }

    public enum Direction
    {
        right = 1,
        up = 2,
        left = 3,
        down = 4
    }

    public struct Point
    {
        public readonly int _id;
        public readonly int _x;
        public readonly int _y;

        public Point(int id, int x, int y)
        {
            _id = id;
            _x = x;
            _y = y;
        }
    }
}
