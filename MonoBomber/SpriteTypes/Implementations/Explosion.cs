using System;
using Microsoft.Xna.Framework;
using MonoBomber.MacOS.SpriteTypes;

namespace MonoBomber.MacOS {
    public class Explosion : TiledSprite, TempSprite {

        Player owner;
        private int timer;
        public const int LINGER_TIME = 25;

        public Explosion(Player owner, Tile tile, MonoBomberGame game) : base(MonoBomberGame.explodeTex, tile, owner.Color, game) {
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
