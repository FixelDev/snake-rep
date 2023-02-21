using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum TileType
    {
        Empty,
        Border,
        Snake,
        Fruit
    }


    class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileType TileType { get; set; }

        public Tile(int x, int y, TileType tileType)
        {
            X = x;
            Y = y;
            TileType = tileType;
        }

    }
}
