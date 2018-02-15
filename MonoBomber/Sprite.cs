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
        public Color color;

        public Sprite(Texture2D texture, Vector2 pos, Color color)
        {
            this.texture = texture;
            this.pos = pos;
            this.color = color;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, pos, color);
        }

        abstract public void Update();
    }
}
