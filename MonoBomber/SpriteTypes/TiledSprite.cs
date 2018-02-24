using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS.SpriteTypes {
    public abstract class TiledSprite : Sprite {

        Texture2D texture;
        Color color;
        MonoBomberGame game;
        Tile tile;

        protected TiledSprite(Texture2D texture, Tile tile, Color color, MonoBomberGame game) {
            this.texture = texture;
            this.color = color;
            this.game = game;
            this.tile = tile ?? throw new ArgumentNullException();
        }

        // Sprite Properties
        public Texture2D Texture => texture;
        public Color Color => color;
        public MonoBomberGame Game => game;
        public Tile Tile { get { return tile; } set { tile = value; }}

        // Game Loop
        public abstract void Update();
        public void Draw() {
            if(tile != null) {
                game.spriteBatch.Draw(texture, tile.pos, color);
            }
        }

        public Rectangle Bounding() {
            throw new NotImplementedException();
        }

        // Tile Properties
        public Tile TileDown => tile.TileDown();
        public Tile TileLeft => tile.TileLeft();
        public Tile TileRight => tile.TileRight();
        public Tile TileUp => tile.TileUp();
        public int TileXIndex => tile.X;
        public int TileYIndex => tile.Y;
    }
}
