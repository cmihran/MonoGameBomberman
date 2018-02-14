using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS
{
    public class Bomb : Sprite
    {

        // time to explode
        int timer;

        // amount of time bomb lingers after exploding
        private readonly int LINGER_TIME = -25;

        public Bomb(Texture2D texture, Vector2 pos) : base(texture, pos) {
            this.timer = 50;
        }

        public override void Update() {
            if(timer == 0) {
                this.texture = Game1.explodeTex;
            }
            timer--;
        }

        public Boolean ShouldReap() {
            return timer <= LINGER_TIME;
        }
    }
}
