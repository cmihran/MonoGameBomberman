using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS
{
    public class Sprite
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
    }
}
