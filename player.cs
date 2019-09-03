using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class player
    {
        public Vector2 position;
        public Vector2 velocity;
        public int collideBlock;
        public int collideIndex;
        public SpriteEffects flip = SpriteEffects.None;
        public AnimationPlayer sprite;

        public player(Vector2 playerPosition)
        {
            position = playerPosition;
        }

        public bool IsColliding(Vector2 nextPosition, Board Board)
        {
            float rightX = nextPosition.X + 32 * 3 / 2;
            float leftX = nextPosition.X;
            float bottomY = nextPosition.Y + 32 * 3 / 2;
            float topY = nextPosition.Y;
            for (int i = 0; i < Board.Blocks.Count; i++)
            {
                float rightEdge = (320 + Board.Blocks[i].X * 32 + 32) * 3 / 2;
                float leftEdge = (320 + Board.Blocks[i].X * 32) * 3 / 2;
                float bottomEdge = (20 - Board.Blocks[i].Y) * 32 * 3 / 2;
                float topEdge = (20 - Board.Blocks[i].Y - 1) * 32 * 3 / 2;
                if (rightX <= leftEdge || leftX >= rightEdge || bottomY <= topEdge || topY >= bottomEdge)
                {
                    int check = i + 1;
                }
                else
                {
                    collideBlock = i;
                    return true;
                }
            }
            return false;
        }

        public bool TopColliding(float playerX, float playerY, Board Board)
        {
            for (int i = 0; i < Board.Blocks.Count; i++)
            {
                float topY = playerY;
                float leftX = playerX;
                float rightX = playerX + 32 * 3 / 2;
                float rightEdge = (320 + Board.Blocks[i].X * 32 + 32) * 3 / 2;
                float leftEdge = (320 + Board.Blocks[i].X * 32) * 3 / 2;
                float bottomEdge = (20 - Board.Blocks[i].Y - 1) * 32 * 3 / 2;
                // Console.WriteLine("{0},{1}", playerY, bottomEdge);
                if ((topY == bottomEdge && leftX > leftEdge && leftX < rightEdge) || (topY == bottomEdge && rightX > leftEdge && rightX < rightEdge) || (topY == bottomEdge && leftX == leftEdge && rightX == rightEdge))
                {
                    collideIndex = i;
                    return true;
                }
            }
            return false;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Flip the sprite to face the way we are moving.
            if (velocity.X >= 0)
                flip = SpriteEffects.FlipHorizontally;
            else if (velocity.X < 0)
                flip = SpriteEffects.None;

            // Draw that sprite.
            sprite.Draw(gameTime, spriteBatch, position, flip);
        }

    }
}

