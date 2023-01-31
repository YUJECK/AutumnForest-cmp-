using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest.Pathfinding
{
    public sealed class Pathfinder : MonoBehaviour
    {
        private enum GCostDefining
        {
            Distance,
            Random
        }
        private sealed class Point
        {
            //position
            public int X { get; private set; }
            public int Y { get; private set; }

            //costs
            public float G { get; private set; }
            public float H { get; private set; }
            public float F => G + H;

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public Point PreviosPoint { get; set; }

            public void SetCosts(float g, float h) { this.G = g; this.H = h; }
        }
        private sealed class PointComparer : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                if (x.F > y.F) return 1;
                else if (x.F < y.F) return -1;
                return 0;
            }
        }

        [SerializeField] private GCostDefining gCostDefining;

        public List<Vector2> FindPath(Vector2 start, Vector2 end)
        {
            if (GlobalServiceLocator.GetService<GridManager>().GetPoint(end) == 1)
            {
                Debug.LogWarning("End point is obstacle");
                return new List<Vector2>();
            }

            List<Point> nextPoints = new List<Point>();
            bool[,] visitedPoints = new bool[GlobalServiceLocator.GetService<GridManager>().GridWidth, GlobalServiceLocator.GetService<GridManager>().GridHeight];
            Point startPoint = new Point((int)start.x, (int)start.y);
            Point endPoint = new Point((int)end.x, (int)end.y);

            Point currentPoint = startPoint;

            while (true)
            {
                if (currentPoint.X == endPoint.X && currentPoint.Y == endPoint.Y)
                    return RestorePath(currentPoint);

                List<Point> neibhourPoints = GetNeibhourPoints(currentPoint, visitedPoints);

                foreach (Point point in neibhourPoints)
                {
                    point.SetCosts(currentPoint.G + DefineGCost(currentPoint, point), Heuristic(point, endPoint));
                    point.PreviosPoint = currentPoint;
                    nextPoints.Add(point);

                    visitedPoints[point.X, point.Y] = true;
                }
                nextPoints.Sort(new PointComparer());

                currentPoint = nextPoints[0];
                nextPoints.Remove(currentPoint);
            }
        }

        private float DefineGCost(Point startPoint, Point endPoint)
        {
            switch (gCostDefining)
            {
                case GCostDefining.Distance:
                    return Vector2.Distance(new Vector2(startPoint.X, startPoint.Y), new Vector2(endPoint.X, endPoint.Y));
                case GCostDefining.Random:
                    return Random.Range(0, 5);
            }
            return 1;
        }
        private int Heuristic(Point first, Point second) => Mathf.Abs(first.X - second.X) + Mathf.Abs(first.Y - second.Y);
        private bool CheckPointCollider(Point point)
        {
            if (GlobalServiceLocator.GetService<GridManager>().GetPoint(new Vector2Int(point.X, point.Y)) == 0) return true;
            else return false;
        }

        private List<Point> GetNeibhourPoints(Point point, bool[,] ignoredPoints)
        {
            List<Point> neibhourPoints = new List<Point>();
            List<Point> pointsToCheck = new List<Point>
            {
                new Point(point.X, point.Y + 1),
                new Point(point.X, point.Y - 1),
                new Point(point.X + 1, point.Y),
                new Point(point.X - 1, point.Y),
                new Point(point.X + 1, point.Y + 1),
                new Point(point.X - 1, point.Y - 1),
                new Point(point.X + 1, point.Y - 1),
                new Point(point.X - 1, point.Y + 1)
            };

            for (int i = 0; i < pointsToCheck.Count; i++)
            {
                if (CheckPointCollider(pointsToCheck[i]) && !ignoredPoints[pointsToCheck[i].X, pointsToCheck[i].Y])
                    neibhourPoints.Add(pointsToCheck[i]);
            }
            return neibhourPoints;
        }
        private List<Vector2> RestorePath(Point endPoint)
        {
            Point current = endPoint;
            List<Vector2> path = new List<Vector2>();

            while (current.PreviosPoint != null)
            {
                path.Add(new Vector2(current.X, current.Y));
                current = current.PreviosPoint;
            }

            path.Reverse();
            return path;
        }
    }
}