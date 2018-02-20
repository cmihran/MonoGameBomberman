using System;
using Microsoft.Xna.Framework;

namespace MonoBomber.MacOS {
    public class Explosion : Sprite, TempSprite {
        Player owner;

        private int timer;

        public const int LINGER_TIME = 25;

        public Explosion(Player owner, Vector2 pos, Color color, MonoBomberGame game) : base(MonoBomberGame.explodeTex, pos, color, game) {
            this.owner = owner;
            this.timer = LINGER_TIME;
        }

        public override void Update() {
            if (timer > 0) {
                timer--;
            }
        }

        public bool ShouldReap() {
            return timer == 0;
        }
    }
}
