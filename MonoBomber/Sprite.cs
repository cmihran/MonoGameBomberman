using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS {
    /// <summary>
    /// A Sprite is an game object with a texture and a position in 2D.
    /// It should not be instantiated on its own so it is abstract
    /// </summary>
    public abstract class Sprite {
        public Texture2D texture;
        public Vector2 pos;
        public Color color;

        public MonoBomberGame game;

        public Sprite(Texture2D texture, Vector2 pos, Color color, MonoBomberGame game) {
            this.texture = texture;
            this.pos = pos;
            this.color = color;
            this.game = game;
        }

        public Vector2 getCenter() {
            return new Vector2(pos.X + (texture.Width / 2), pos.Y + (texture.Height / 2));
        }

        public Tile getTile() {
            return game.tiles[getTileXIndex(), getTileYIndex()];
        }

        public int getTileXIndex() {
            return (int)Math.Floor(this.getCenter().X / MonoBomberGame.tileTex.Width);
        }

        public int getTileYIndex() {
            return (int)Math.Floor(this.getCenter().Y / MonoBomberGame.tileTex.Height); ;
        }

        public void Draw() {
            //Texture2D rec = new Texture2D(game.graphics.GraphicsDevice, 1, 1);
            //rec.SetData(new[] { Color.White });

            //batch.Draw(rec, MakeBounding(), color);

            game.spriteBatch.Draw(texture, pos, color);
        }

        abstract public void Update();

        public Boolean CollidesWith(Sprite other) {
            return this.MakeBounding().Intersects(other.MakeBounding());
        }

        private Rectangle MakeBounding() {
            return new Rectangle(
                new Point((int)pos.X, (int)pos.Y),
                new Point(texture.Width, texture.Height)
            );
        }

    }
}
