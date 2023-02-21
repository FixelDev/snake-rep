using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Input;
using System.Threading;
using System.Timers;

namespace Snake
{
    class Game
    {
        private int width = 20, height = 20;
        private Tile[,] tileGrid;
        private Snake snake;
        public Vector2 snakeMoveDirection;
        public static Game Instance;
        private int fruitsCount = 0;
        public Game()
        {
            tileGrid = new Tile[width, height];
            snakeMoveDirection = new Vector2(1, 0);
            Instance = this;
        }

        public void GameLoop()
        {
            DrawFrame();
        }

        


        public void GenerateMap()
        {
            for (int x = 0; x < width; x++)
            {
                if(x > 0)
                    Console.WriteLine();
                for (int y = 0; y < height; y++)
                {
                    TileType tileType;

                    if ((x == 0 || y == 0) || (y == height - 1 || x == width - 1))
                    {
                        tileType = TileType.Border;
                        Console.Write("X");
                    }
                    else
                    {
                        tileType = TileType.Empty;
                        Console.Write(" ");
                    }

                    tileGrid[x, y] = new Tile(x, y, tileType);

                }
            }

            Console.SetCursorPosition(width, height);
            Console.WriteLine("\n ");
            Console.Write("SNAKE!");

        }

        private void DrawFrame()
        {
            GenerateFruit();
            UpdateSnake();
            CheckIfSnakeHitSomething();
            DrawMap();
           
            Thread.Sleep(230);
        }


        private void UpdateSnake()
        {
            snake.MoveSnake(PlayerInput.snakeMoveDirection);
        }

        private void DrawMap()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (tileGrid[x, y].TileType == TileType.Snake)
                    {
                        Console.SetCursorPosition(x, y);
                        tileGrid[x, y].TileType = TileType.Empty;
                        Console.Write(" ");
                    }
                    else if(tileGrid[x, y].TileType == TileType.Fruit)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("#");
                    }
                }
            }

            foreach (Tile bodySegment in snake.GetBody())
            {
                Console.SetCursorPosition(bodySegment.X, bodySegment.Y);
                tileGrid[bodySegment.X, bodySegment.Y].TileType = TileType.Snake;
                Console.Write("0");
            }
            
        }

        private void CheckIfSnakeHitSomething()
        {
            Vector2 headPosition = snake.GetHeadPosition();
            Tile hitTile = GetTileAt((int)headPosition.X, (int)headPosition.Y);

            if(hitTile.TileType == TileType.Border)
            {
                InitGameOver();
            }
             
            if(hitTile.TileType == TileType.Fruit)
            {
                AddBodySegmentToSnake();
            }


        }

        private void GenerateFruit()
        {
            if (fruitsCount > 0)
                return;

            Random random = new Random();
            int randomNumber = random.Next(6);

            if (randomNumber != 2)
                return;

            List<Tile> availableTiles = new List<Tile>();

            for (int x = 2; x < width - 2; x++)
            {
                for (int y = 2; y < height - 2; y++)
                {
                    Tile tile = GetTileAt(x, y);
                    if (tile.TileType == TileType.Empty)
                        availableTiles.Add(tile);
                }
            }

            int randomIndex = random.Next(availableTiles.Count - 1);
            Tile randomTile = availableTiles[randomIndex];

            tileGrid[randomTile.X, randomTile.Y].TileType = TileType.Fruit;
            fruitsCount++;
        }

        public void InitGameOver()
        {
            Console.SetCursorPosition(width, height);
            Console.WriteLine("\n \n \n GAME OVER");

            Thread.Sleep(460);

            Environment.Exit(0);


        }

        public void InitSnake()
        {
            snake = new Snake(width / 2, height / 2);
        }

        public Tile GetTileAt(int x, int y)
        {
            if(((tileGrid.GetLength(0) - 1) - x < 0) || (tileGrid.GetLength(1) - 1) - y < 0)
                return null;

            return tileGrid[x, y];
        }

        public void AddBodySegmentToSnake()
        {
            snake.AddBodySegment();
            fruitsCount--;
        }
    }
}
