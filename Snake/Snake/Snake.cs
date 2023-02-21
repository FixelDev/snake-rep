using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Snake
    {
        private List<Tile> body;
        private Vector2 currentDirection;

        public Snake(int x, int y)
        {
            body = new List<Tile>();
            Tile head = new Tile(x, y, TileType.Snake);

            body.Add(head);
        }

        public void AddBodySegment()
        {
            Tile previousBodySegment = body[body.Count - 1];
            Tile neighbour = FindBodySegmentNeighbour(previousBodySegment);
            Vector2 direction = new Vector2(PlayerInput.snakeMoveDirection.X, -PlayerInput.snakeMoveDirection.Y);
            Vector2 newBodySegmentPosition = new Vector2(previousBodySegment.X + direction.X, previousBodySegment.Y + direction.Y);

            if(neighbour != null)
            {
                direction = new Vector2(previousBodySegment.X - neighbour.X, previousBodySegment.Y - neighbour.Y);
                newBodySegmentPosition = new Vector2(previousBodySegment.X + direction.X, previousBodySegment.Y + direction.Y);
            }
            
            Tile bodySegment = new Tile((int)newBodySegmentPosition.X, (int)newBodySegmentPosition.Y, TileType.Snake);
            body.Add(bodySegment);

        }

        private Tile FindBodySegmentNeighbour(Tile tile)
        {

            Tile foundTile = Game.Instance.GetTileAt(tile.X - 1, tile.Y);
            if (foundTile.TileType == TileType.Snake)
                return foundTile;
            foundTile = Game.Instance.GetTileAt(tile.X + 1, tile.Y);
            if (foundTile.TileType == TileType.Snake)
                return foundTile;
            foundTile = Game.Instance.GetTileAt(tile.X, tile.Y - 1);
            if (foundTile.TileType == TileType.Snake)
                return foundTile;
            foundTile = Game.Instance.GetTileAt(tile.X, tile.Y + 1);
            if (foundTile.TileType == TileType.Snake)
                return foundTile;

            return null;

        }

        public List<Tile> GetBody()
        {
            return body;
        }

        public void MoveSnake(Vector2 direction)
        {
            

            int oldXDirection = body[0].X;
            int oldYDirection = body[0].Y;

            if (direction == -currentDirection)
                direction = currentDirection;

            //if (Game.Instance.GetTileAt(body[0].X + (int)direction.X, body[0].Y + (int)direction.Y).TileType == TileType.Snake)
            //{
            //    Game.Instance.InitGameOver();
            //}


            body[0].X += (int)direction.X;
            body[0].Y += (int)direction.Y;


            for (int i = 1; i < body.Count; i++)
            {
                int XTmp = body[i].X;
                int YTmp = body[i].Y;

                body[i].X = oldXDirection;
                body[i].Y = oldYDirection;

                oldXDirection = XTmp;
                oldYDirection = YTmp;
            }

            currentDirection = direction;
        }

        public Vector2 GetHeadPosition()
        {
            return new Vector2(body[0].X, body[0].Y);
        }

    }
}
