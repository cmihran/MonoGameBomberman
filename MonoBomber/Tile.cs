using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS 
{
    public class Tile : Sprite 
    {
        private Bomb bomb;


        public Tile(MonoBomberGame game, Vector2 pos) : base(MonoBomberGame.tileTex, pos, Color.LightGray, game) 
        {
            
        }

        public void Update() {
            if (bomb != null)
            {
                bomb.Update();
                if (bomb.ShouldReap())
                {
                    bomb = null;
                }
            }
        }

        public new void Draw() {
            base.Draw();

            if(bomb != null) {
                bomb.Draw();
            }
        }

        public Boolean AttemptPlaceBomb(Player owner) {
            if(bomb != null) {
                return false;
            } else {
                bomb = new Bomb(owner, this.pos, owner.color, game);
                return true;
            }
        }

        public override string ToString()
        {
            return "[Tile: " + pos + "]";
        }
    }
}
