using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS.SpriteTypes {
    
    public abstract class FreeMovingSprite : Sprite {

        Texture2D texture;
        Color color;
        MonoBomberGame game;
        public Vector2 pos;

        protected FreeMovingSprite(Texture2D texture, Vector2 pos, Color color, MonoBomberGame game) {
            this.texture = texture;
            this.pos = pos;
            this.color = color;
            this.game = game;
        }

        public Texture2D Texture => texture;
        public Color Color => color; 
        public MonoBomberGame Game => game;

        public abstract void Update();

        public void Draw() {
            //Texture2D rec = new Texture2D(game.graphics.GraphicsDevice, 1, 1);
            //rec.SetData(new[] { Color.White });
            //batch.Draw(rec, MakeBounding(), color);

            game.spriteBatch.Draw(texture, pos, color);
        }

        public bool CollidesWith(Sprite other) => (this.Bounding().Intersects(other.Bounding()));

        public Tile EstimateTileLeft() {
            int myX = EstimateTileXIndex();
            int myY = EstimateTileYIndex();
            if(myX - 1 < 0) {
                return null;
            } else {
                return game.tiles[myX - 1, myY];
            }
        } 

        public Tile EstimateTileRight() {
            int myX = EstimateTileXIndex();
            int myY = EstimateTileYIndex();
            if(myX + 1 >= MonoBomberGame.NUM_TILES) {
                return null;
            } else {
                return game.tiles[myX + 1, myY];
            }
        } 

        public Tile EstimateTileUp() {
            int myX = EstimateTileXIndex();
            int myY = EstimateTileYIndex();
            if(myY - 1 < 0) {
                return null;
            } else {
                return game.tiles[myX, myY - 1];
            }
        } 

        public Tile EstimateTileDown() {
            int myX = EstimateTileXIndex();
            int myY = EstimateTileYIndex();
            if(myY + 1 >= MonoBomberGame.NUM_TILES) {
                return null;
            } else {
                return game.tiles[myX, myY + 1];
            }
        }

        public Tile EstimateTile() {
            int myX = EstimateTileXIndex();
            int myY = EstimateTileYIndex();
            return game.tiles[EstimateTileXIndex(), EstimateTileYIndex()];
        }

        public Vector2 Center() {
            return new Vector2(pos.X + (texture.Width / 2), pos.Y + (texture.Height / 2));
        }

        public int EstimateTileXIndex() {
            return (int)Math.Floor(this.Center().X / MonoBomberGame.tileTex.Width);
        }

        public int EstimateTileYIndex() {
            return (int)Math.Floor(this.Center().Y / MonoBomberGame.tileTex.Height); ;
        }

        public Rectangle Bounding() {
            return new Rectangle(
                new Point((int)pos.X, (int)pos.Y),
                new Point(texture.Width, texture.Height)
            );
        }
    }
}
