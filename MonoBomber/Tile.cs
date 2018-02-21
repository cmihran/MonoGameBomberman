using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS {
    public class Tile : Sprite {
        private Sprite occupant;


        public Tile(MonoBomberGame game, Vector2 pos) : base(MonoBomberGame.tileTex, pos, Color.LightGray, game) {

        }

        public override void Update() {
            if (occupant != null) {
                // update occupant
                occupant.Update();

                // check for reaping
                if (this.occupant is TempSprite sprite && sprite.ShouldReap()) {
                    this.occupant = null;
                }
            }
        }

        public new void Draw() {
            base.Draw();

            if (occupant != null) {
                occupant.Draw();
            }
        }

        public bool isOccupied() {
            return occupant != null;
        }

        public void PlaceSprite(Sprite sprite) {
            occupant = sprite;
        }

        public override string ToString() {
            return "[Tile: " + pos + "]";
        }

        public bool hasExplosion() {
            return occupant is Explosion;
        }

        public bool nextToExplosion() {
            int myX = getTileXIndex();
            int myY = getTileYIndex();

            // check left
            if (myX - 1 >= 0 && game.tiles[myX - 1, myY].hasExplosion()) {
                return true;
            }
            // check right
            else if (myX + 1 < MonoBomberGame.NUM_TILES && game.tiles[myX + 1, myY].hasExplosion()) {
                return true;
            }
            // check up
            else if (myY - 1 >= 0 && game.tiles[myX, myY - 1].hasExplosion()) {
                return true;
            }
            // check down
            else if (myY + 1 < MonoBomberGame.NUM_TILES && game.tiles[myX, myY + 1].hasExplosion()) {
                return true;
            } else {
                return false;
            }
        }
    }
}
