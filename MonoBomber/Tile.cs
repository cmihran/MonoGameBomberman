using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS 
{
    public class Tile : Sprite 
    {
        private Sprite occupant;


        public Tile(MonoBomberGame game, Vector2 pos) : base(MonoBomberGame.tileTex, pos, Color.LightGray, game)  {
        
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

            if(occupant != null) {
                occupant.Draw();
            }
        }

        public bool isOccupied() {
            return occupant != null;
        }

        public void PlaceSprite(Sprite sprite) {
            occupant = sprite;
        }

        public override string ToString()
        {
            return "[Tile: " + pos + "]";
        }

        public bool hasExplosion() {
            return occupant is Explosion;
        }
    }
}
