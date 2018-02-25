using System;
using Microsoft.Xna.Framework;

namespace MonoBomber.MacOS.SpriteTypes.Implementations {
    public class Bot : Player {

        Human opponent;
        
        public Bot(Vector2 pos, Color color, Human opponent, MonoBomberGame game) : base(pos, color, game) {
            this.opponent = opponent;
        }

        public new void Update() {
            base.Update();

            if (pos.X < opponent.pos.X) {
                pos.X++;
            } else {
                pos.X--;
            }

            if (pos.Y < opponent.pos.Y) {
                pos.Y++;
            } else {
                pos.Y--;
            }
        }
    }
}
