using System;
using System.Linq;

namespace YandexCup.ShareThemAll
{
    class Program
    {
        static void Main(string[] args)
        {
            var itemsCount = int.Parse(Console.ReadLine());
            var items = new int[itemsCount][];
            for (int i = 0; i < itemsCount; i++)
            {
                items[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            var checker = new PokemonChecker();
            Console.WriteLine(checker.CanCachThemAll(items) ? "Yes" : "No");
        }
    }

    public class PokemonChecker
    {
        public bool CanCachThemAll(int[][] numbers)
        {
            if (numbers.Length == 1)
                return true;
            if (numbers.Length == 2 && numbers.All(x => x[0] == 0))
                return true;

            var circles = numbers.Where(x => x[0] == 0)
                .Select(x => new Circle(x[1], x[2], x[3]).Center)
                .ToArray();

            if (circles.Any() && !IsPointsOnSingleLine(circles))
                return false;

            var squars = numbers.Where(x => x[0] == 1)
                .Select(x => new Square(new[] {x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8]}))
                .ToArray();

            if (!squars.Any())
                return true;
            
            var squarePoints = new Point[0];
            var firstSquare = squars.First();
            var firstCirles = circles.Take(2).ToArray();
            
            if (circles.Any())
            {
                squarePoints = firstCirles.Concat(new[] {firstSquare.Points[0], firstSquare.Points[2]})
                    .ToArray();
                if (!IsPointsOnSingleLine(squarePoints))
                    return false;
            
                squarePoints = firstCirles.Concat(new[] {firstSquare.Points[1], firstSquare.Points[3]})
                    .ToArray();
                if (!IsPointsOnSingleLine(squarePoints))
                    return false;

                squarePoints = firstCirles.Concat(GetSquareXsidePoint(firstSquare)).ToArray();
                if (!IsPointsOnSingleLine(squarePoints))
                    return false;
            
                squarePoints = firstCirles.Concat(GetSquareYsidePoint(firstSquare)).ToArray();
                if (!IsPointsOnSingleLine(squarePoints))
                    return false;
            }

            squarePoints = squars.SelectMany(x => new Point[] {x.Points[0], x.Points[2]})
                .Concat(firstCirles)
                .ToArray();

            if (IsPointsOnSingleLine(squarePoints))
                return true;

            squarePoints = squars.SelectMany(x => new Point[] {x.Points[1], x.Points[3]})
                .Concat(firstCirles)
                .ToArray();

            if (IsPointsOnSingleLine(squarePoints))
                return true;
            
            squarePoints = squars.SelectMany(GetSquareXsidePoint)
                .Concat(firstCirles)
                .ToArray();

            if (IsPointsOnSingleLine(squarePoints))
                return true;

            squarePoints = squars.SelectMany(GetSquareYsidePoint)
                .Concat(firstCirles)
                .ToArray();

            if (IsPointsOnSingleLine(squarePoints))
                return true;
            
            return false;
        }

        private Point[] GetSquareXsidePoint(Square square)
        {
            return new[]
            {
                new Point
                {
                    XAxis = (square.Points[0].XAxis + square.Points[2].XAxis) / 2,
                    YAxis = (square.Points[0].YAxis + square.Points[2].YAxis) / 2
                },
                new Point
                {
                    XAxis = (square.Points[1].XAxis + square.Points[3].XAxis) / 2,
                    YAxis = (square.Points[1].YAxis + square.Points[3].YAxis) / 2
                }
            };
        }
        
        private Point[] GetSquareYsidePoint(Square square)
        {
            return new[]
            {
                new Point
                {
                    XAxis = (square.Points[0].XAxis + square.Points[1].XAxis) / 2,
                    YAxis = (square.Points[0].YAxis + square.Points[1].YAxis) / 2
                },
                new Point
                {
                    XAxis = (square.Points[2].XAxis + square.Points[3].XAxis) / 2,
                    YAxis = (square.Points[2].YAxis + square.Points[3].YAxis) / 2
                }
            };
        }

        private bool IsPointsOnSingleLine(Point[] circles)
        {
            var firstCircle = circles[0];
            var secondCircle = circles[1];
            var mainCoef = GetPointCoeficient(firstCircle, secondCircle);

            for (int i = 2; i < circles.Length; i++)
            {
                var coef = GetPointCoeficient(firstCircle, circles[i]);
                if (coef != mainCoef)
                {
                    return false;
                }
            }

            return true;
        }

        private int GetPointCoeficient(Point firstPoint, Point secondPoint)
        {
            if (firstPoint.XAxis - secondPoint.XAxis == 0)
                return 0;
            
            return (firstPoint.YAxis - secondPoint.YAxis) / (firstPoint.XAxis - secondPoint.XAxis);
        }

        private struct Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
            public Circle(int xAxis, int yAxis, int radius)
            {
                Center = new Point(xAxis, yAxis);
                Radius = radius;
            }
        }

        private struct Point
        {
            public int XAxis { get; set; }
            public int YAxis { get; set; }
        
            public Point(int xAxis, int yAxis)
            {
                XAxis = xAxis;
                YAxis = yAxis;
            }
        }
    
        private struct Square
        {
            public Point[] Points { get; set; }

            public Square(int[] points)
            {
                if (points.Length != 8)
                    throw new ArgumentException(nameof(points));
                Points = new Point[4];
                for (var i = 0; i < 4; i++)
                {
                    Points[i] = new Point(points[i * 2], points[i * 2 + 1]);
                }
            }
        }
    }
}