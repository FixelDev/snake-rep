using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using System.Numerics;

namespace Snake
{
    class Program
    {
        private const float TICK_RATE = 300;
        private static float curr;

        [STAThread]
        static void Main(string[] args)
        {
            Game game = new Game();
            curr = TICK_RATE;
            game.GenerateMap();
            game.InitSnake();

            Console.CursorVisible = false;


            while (true)
            {
                PlayerInput.HandlePlayerInput();
                game.GameLoop();        
            }
            

        }



    }



}
