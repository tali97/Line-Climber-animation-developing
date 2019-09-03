using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameObject
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Velocity;
        public int Width;
        public int Height;
        public Boolean Disabled = false;

        public Rectangle BoundingBox
        {
            get
            {
                if (!Disabled)
                {
                    return new Rectangle
                        (
                            (int)Position.X,
                            (int)Position.Y,
                            Texture.Width,
                            Texture.Height
                        );
                }
                return new Rectangle();
            }
        }
        
        public GameObject(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }

        public GameObject(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            this.Texture = texture;
            this.Position = position;
            this.Velocity = velocity;
        }

        public void Draw(SpriteBatch spriteBatch, Color? color = null)
        {
            Color c = color ?? Color.White;
            spriteBatch.Draw(Texture, BoundingBox, c);
        }


        // Returns the GameObject to the interactive world
        public void Enable(SpriteBatch spriteBatch)
        {
            Disabled = false;
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, BoundingBox, Color.White);
            spriteBatch.End();
        }


        // Hides the GameObject from any interactions
        public void Disable(SpriteBatch spriteBatch)
        {
            Disabled = true;
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, BoundingBox, new Color(0, 0, 0, 0));
            spriteBatch.End();
        }
    }
}
