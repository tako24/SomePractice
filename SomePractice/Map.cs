using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomePractice
{
    public enum GridObject
    {
        emptySpace,
        floor,
        wall
    }
    class Map
    {
        public GridObject[,] Grid { get; set; }
        public int CellHeight {  get; private set; } 
        public int CellWidth { get; private set; } 
        public Map(int width, int height)
        {
            Grid = new GridObject[width, height];
            CellHeight = height;
            CellWidth = width;
            for (int i = 0; i < CellWidth; i++)
            {
                for (int y = 0; y < CellHeight; y++)
                {
                    Grid[i, y] = GridObject.emptySpace;
                }
            }
        }
        public void CreateWalls()
        {
            for (int x = 0; x < Grid.GetLength(0) - 1; x++)
            {
                for (int y = 0; y < Grid.GetLength(1) - 1; y++)
                {
                    if (Grid[x, y] == GridObject.floor)
                    {
                        if (Grid[x, y + 1] == GridObject.emptySpace)
                        {
                            Grid[x, y + 1] = GridObject.wall;
                        }
                        if (Grid[x, y - 1] == GridObject.emptySpace)
                        {
                            Grid[x, y - 1] = GridObject.wall;
                        }
                        if (Grid[x + 1, y] == GridObject.emptySpace)
                        {
                            Grid[x + 1, y] = GridObject.wall;
                        }
                        if (Grid[x - 1, y] == GridObject.emptySpace)
                        {
                            Grid[x - 1, y] = GridObject.wall;
                        }
                    }
                }
            }
        }

    }
}
