using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS
{
    public class Bomb : Sprite
    {
        int timer;

        public Bomb(Texture2D texture, Vector2 pos) : base(texture, pos) {
            timer = 50;
        }

        public void Update() {
            if(timer == 0) {
                this.texture = Game1.explodeTex;
            } else {
                timer--;
            }
        }
    }
}
