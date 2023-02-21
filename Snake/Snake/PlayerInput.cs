using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Input;

namespace Snake
{
    class PlayerInput
    {
        public static Vector2 snakeMoveDirection = new Vector2(1,0);

        public static void HandlePlayerInput()
        {

            if (Keyboard.IsKeyDown(Key.W))
            {
                snakeMoveDirection = new Vector2(0, -1);
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                snakeMoveDirection = new Vector2(0, 1);
            }
            else if (Keyboard.IsKeyDown(Key.A))
            {
                snakeMoveDirection = new Vector2(-1, 0);
            }
            else if (Keyboard.IsKeyDown(Key.D))
            {
                snakeMoveDirection = new Vector2(1, 0);
            }


        }
    }
}
