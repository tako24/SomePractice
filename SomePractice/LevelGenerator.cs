using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePractice
{
    class LevelGenerator
    {
        const float chanceWalkerSpawn = 0.05f;

        const int maxWalkers = 10;
        const int percentOfFloor = 3500; // нужное колличество пола
        int floorCount;
        public  Map map = new Map(150, 80);
        List<Walker> walkers;
        public LevelGenerator()
        {
            SetMap();
            CreateFloors();
            map.CreateWalls();


        }
        public  void SetMap()
        {
            Random rnd = new Random();
            walkers = new List<Walker>();
            Walker newWalker = new Walker();
            newWalker.SetRandomDirection(rnd);
            //точку спавна делаю в центре сетки
            Vector2d spawnPos = new Vector2d((int)Math.Round(map.CellWidth / 2.0),
                                             (int)Math.Round(map.CellHeight / 2.0));
            newWalker.Position = spawnPos;
            walkers.Add(newWalker);
        }

        private void CreateFloorOnWalkerPosition()
        {
            //Создаю пол на позиции каждого walker'а
            foreach (Walker myWalker in walkers)
            {
                if (map.Grid[myWalker.Position.X, myWalker.Position.Y] == GridObject.floor)
                    continue;
                map.Grid[myWalker.Position.X, myWalker.Position.Y] = GridObject.floor;
                floorCount++;
            }
        }
        private void DeleteWalkers(Random rnd)
        {
            if (walkers.Count <= 1)
                return;
            foreach (var walker in walkers)
            {
                if (walker.Destroy(rnd) && walkers.Count>1)
                {
                    walkers.Remove(walker);
                    break; // За итерацию можно удалить только одного walker'а
                }
            }

        }
        private void ChangeDirection(Random rnd)
        {
            if (walkers.Count <= 1)
                return;
            foreach (var walker in walkers)
            {
                walker.ChangeDirection(rnd);
            }
        }
        private void SpawnWalker(Random rnd)
        {
            for (int i = 0; i < walkers.Count; i++)
            {
                if (rnd.NextDouble() < chanceWalkerSpawn && walkers.Count < maxWalkers)
                {
                    Walker newWalker = new Walker();
                    newWalker.SetRandomDirection(rnd);
                    newWalker.Position = walkers[i].Position;
                    walkers.Add(newWalker);
                }
            }
        }
        private void MoveWalkers(Random rnd)
        {
            for (int i = 0; i < walkers.Count; i++)
            {
                Walker thisWalker = walkers[i];
                thisWalker.SetRandomDirection(rnd);
                thisWalker.Position += thisWalker.Direction;
                walkers[i] = thisWalker;

            }
        }
        private void AvoidBorders()
        {
            for (int i = 0; i < walkers.Count; i++)
            {
                Walker thisWalker = walkers[i];
                thisWalker.Position.X = Clamp(thisWalker.Position.X, 1, map.CellWidth - 2);
                thisWalker.Position.Y = Clamp(thisWalker.Position.Y, 1, map.CellHeight - 2);
                walkers[i] = thisWalker;
            }
        }
        private  void CreateFloors()
        {
            Random rnd = new Random();
            int iterations = 0;
            do
            {
                CreateFloorOnWalkerPosition();

                DeleteWalkers(rnd);

                ChangeDirection(rnd);

                SpawnWalker(rnd);

                MoveWalkers(rnd);

                AvoidBorders();

                if (floorCount>=percentOfFloor)
                {
                    break;
                }
                iterations++;
            } while (iterations < 1000);
        }

        private int Clamp(int value, int min, int max) // Не нашел втроенного метода, пришлось оставить его тут
        {
            return (value < min) ? min : (value > max) ? max : value;
        }
        //private int NumberOfFloors() // убрать метод и считать колличство пола сразу в методе по созданию пола
        //{
        //    int count = 0;
        //    foreach (GridObject space in map.Grid)
        //    {
        //        if (space == GridObject.floor)
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}

    }
}
