using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS
{
    public class Bomb : Sprite
    {
        // who this bomb belongs to
        private Player owner;

        // time to explode
        private int timer;

        // amount of time bomb lingers after exploding
        public const int LINGER_TIME = -25;

        private List<Sprite> explosions;

        public Bomb(Player owner, Vector2 pos, Color color, MonoBomberGame game) : base(MonoBomberGame.bombTex, pos, color, game) {
            this.owner = owner;
            this.timer = Player.BOMB_COOLDOWN_TIME;
            this.explosions = new List<Sprite>();
        }

        public void Update() {
            if(timer == 0) {
                Explode();
            }
            timer--;
        }

        public new void Draw() {
            base.Draw();

            foreach(Sprite ex in explosions) {
                ex.Draw();
            }
        }

        public Boolean ShouldReap() {
            return timer <= LINGER_TIME;
        }


        private void Explode() {
            this.texture = MonoBomberGame.explodeTex;

            // going right
            int curX = (int) pos.X;
            while(curX < game.graphics.GraphicsDevice.Viewport.Width) {
                curX += MonoBomberGame.explodeTex.Width;
                explosions.Add(new Sprite(MonoBomberGame.explodeTex, 
                                          new Vector2(curX, pos.Y), color, game));
            }

            // going left
            curX = (int) pos.X;
            while (curX > 0) {
                curX -= MonoBomberGame.explodeTex.Width;
                explosions.Add(new Sprite(MonoBomberGame.explodeTex,
                                          new Vector2(curX, pos.Y), color, game));
            }

            // going down
            int curY = (int)pos.Y;
            while (curY < game.graphics.GraphicsDevice.Viewport.Height) {
                curY += MonoBomberGame.explodeTex.Width;
                explosions.Add(new Sprite(MonoBomberGame.explodeTex,
                                          new Vector2(pos.X, curY), color, game));
            }

            // going up
            curY = (int)pos.Y;
            while (curY > 0) {
                curY -= MonoBomberGame.explodeTex.Width;
                explosions.Add(new Sprite(MonoBomberGame.explodeTex,
                                          new Vector2(pos.X, curY), color, game));
            }
        }
    }
}
