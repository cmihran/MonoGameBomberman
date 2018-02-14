using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS
{
    public class Player : Sprite
    {
        private static readonly int BOMB_COOLDOWN = 50;

        private int cooldown;
        public List<Bomb> bombs;

        public Player(Texture2D texture, Vector2 pos) : base(texture, pos) {
            this.bombs = new List<Bomb>();
            this.cooldown = 0;
        }

        public new void Draw(SpriteBatch batch) {
            base.Draw(batch);
            foreach(Bomb b in bombs) {
                b.Draw(batch);
            }
        }

        public void Update() {
            if(cooldown > 0) {
                cooldown--;
            }
            foreach(Bomb b in bombs) {
                b.Update();
            }
        }

        public Boolean HasBomb() {
            return cooldown == 0;
        }

        public void PlaceBomb(Texture2D bombTex) {
            if(cooldown == 0) {
                cooldown = BOMB_COOLDOWN;
                bombs.Add(new Bomb(bombTex, new Vector2(pos.X + texture.Width, pos.Y)));
            }
        }
    }
}
