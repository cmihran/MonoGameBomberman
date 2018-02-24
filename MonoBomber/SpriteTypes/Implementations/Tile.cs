using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoBomber.MacOS.SpriteTypes;

namespace MonoBomber.MacOS {
    public class Tile : FreeMovingSprite {
        private TiledSprite occupant;

        private readonly int x, y;

        public Tile(int x, int y, Vector2 pos, MonoBomberGame game) : base(MonoBomberGame.tileTex, pos, Color.LightGray, game) {
            this.x = x;
            this.y = y;
        }

        public int X => x;
        public int Y => y;

        public override void Update() {
            if (occupant != null) {
                // update occupant
                occupant.Update();

                // check for reaping
                if (occupant is TempSprite sprite && sprite.ShouldReap()) {
                    occupant = null;
                }
            }
        }

        public new void Draw() {
            base.Draw();
            if (occupant != null) {
                occupant.Draw();
            }
        }

        public void PlaceWall() {
            occupant = new Wall(this, Game);
        }

        public void PlaceBomb(Player owner) {
            occupant = new Bomb(owner, this, Game);
        }

        public void PlaceExplosion(Player owner) {
            occupant = new Explosion(owner, this, Game);
        }

        public override string ToString() => "[Tile: " + pos + "]";

        public bool IsOccupied() => occupant != null;
        public bool HasExplosion() => occupant is Explosion;
        public bool HasWall() => occupant is Wall;

        public bool NextToExplosion() {
            // check left
            Tile left =  TileLeft();
            if (left != null && left.HasExplosion()) {
                return true;
            }
            // check right
            else if (x + 1 < MonoBomberGame.NUM_TILES && Game.tiles[x + 1, y].HasExplosion()) {
                return true;
            }
            // check up
            else if (y - 1 >= 0 && Game.tiles[x, y - 1].HasExplosion()) {
                return true;
            }
            // check down
            else if (y + 1 < MonoBomberGame.NUM_TILES && Game.tiles[x, y + 1].HasExplosion()) {
                return true;
            } else {
                return false;
            }
        }

        public Tile TileUp() {
            if (y == 0) {
                return null;
            } else {
                return Game.tiles[x, y - 1];
            }
        }

        public Tile TileDown() {
            if(y == MonoBomberGame.NUM_TILES) {
                return null;
            } else {
                return Game.tiles[x, y + 1];
            }
        }

        public Tile TileLeft() {
            if (x == 0) {
                return null;
            } else {
                return Game.tiles[x - 1, y];
            }
        }

        public Tile TileRight() {
            if (x == MonoBomberGame.NUM_TILES) {
                return null;
            } else {
                return Game.tiles[x + 1, y];
            }
        }
    }
}
