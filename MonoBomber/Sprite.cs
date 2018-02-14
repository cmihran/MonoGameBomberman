using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS
{
    /// <summary>
    /// A Sprite is an game object with a texture and a position in 2D.
    /// It should not be instantiated on its own so it is abstract
    /// </summary>
    abstract public class Sprite
    {
        public Texture2D texture;
        public Vector2 pos;

        public Sprite(Texture2D texture, Vector2 pos)
        {
            this.texture = texture;
            this.pos = pos;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, pos, Color.White);
        }

        abstract public void Update();
    }
}
