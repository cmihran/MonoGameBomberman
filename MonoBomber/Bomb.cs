using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS
{
    public class Bomb : Sprite
    {
        int timer;
        private Boolean reap;

        private readonly int LINGER_TIME = -25;

        public Bomb(Texture2D texture, Vector2 pos) : base(texture, pos) {
            this.timer = 50;
            this.reap = false;
        }

        public void Update() {
            if(timer <= LINGER_TIME) {
                this.reap = true;
            } else if(timer == 0) {
                this.texture = Game1.explodeTex;
            }
            timer--;
        }

        public Boolean ShouldReap() {
            return reap;
        }
    }
}
