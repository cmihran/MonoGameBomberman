using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS
{
    /// <summary>
    /// A player that is capable of placing bombs
    /// </summary>
    public class Player : Sprite
    {
        // how long it takes for bombs to recharge
        private static readonly int BOMB_COOLDOWN_TIME = 0;

        // how long this player has left until it can bomb again
        private int bombCooldownLeft;

        // list of bombs that belong to this player
        public List<Bomb> bombs;

        public Player(Texture2D texture, Vector2 pos) : base(texture, pos) {
            this.bombs = new List<Bomb>();
            this.bombCooldownLeft = 0;
        }

        public new void Draw(SpriteBatch batch) {
            // draw the player
            base.Draw(batch);

            // go through player's bombs and either remove or draw them
            for (int i = bombs.Count - 1; i >= 0; i--) {
                if(bombs[i].ShouldReap()) {
                    bombs.RemoveAt(i); 
                } else {
                    bombs[i].Draw(batch);
                }
            }
        }

        public override void Update() {
            // lower the bomb cooldown
            if(bombCooldownLeft > 0) {
                bombCooldownLeft--;
            }

            // update the bombs that belong to this player
            foreach(Bomb b in bombs) {
                b.Update();
            }
        }

        // true if this player can place a bomb
        public Boolean HasBomb() {
            return bombCooldownLeft == 0;
        }

        // places a bomb to the right of this player
        public void PlaceBomb(Texture2D bombTex) {
            if(bombCooldownLeft == 0) {
                bombCooldownLeft = BOMB_COOLDOWN_TIME;
                bombs.Add(new Bomb(bombTex, new Vector2(pos.X + texture.Width, pos.Y)));
            }
        }

    }
}
