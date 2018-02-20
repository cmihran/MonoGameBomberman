using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoBomber.MacOS
{
    /// <summary>
    /// A player that is capable of placing bombs
    /// </summary>
    public class Player : Sprite
    {
        // how long it takes for bombs to recharge
        public const int BOMB_COOLDOWN_TIME = 50 - Bomb.LINGER_TIME;
        private const int SPEED = 8;


        // how long this player has left until it can bomb again
        private int bombCooldownLeft;

        // keys the player uses
        private readonly Keys up;
        private readonly Keys left;
        private readonly Keys down;
        private readonly Keys right;
        private readonly Keys bomb;

        public Player(Texture2D texture, Vector2 pos, Color color, 
                      Keys up, Keys left, Keys down, Keys right, Keys bomb, MonoBomberGame game) : base(texture, pos, color, game) {
            // bombs
            this.bombCooldownLeft = 0;

            // keys
            this.up = up;
            this.left = left;
            this.down = down;
            this.right = right;
            this.bomb = bomb;
        }

        public new void Draw() {
            // draw the player
            base.Draw();

            // go through player's bombs and either remove or draw them
            //for (int i = bombs.Count - 1; i >= 0; i--) {
            //    if(bombs[i].ShouldReap()) {
            //        bombs.RemoveAt(i); 
            //    } else {
            //        bombs[i].Draw();
            //    }
            //}
        }

        public void Update(KeyboardState keyboardState, GraphicsDevice graphics) {
            // lower the bomb cooldown
            if(bombCooldownLeft > 0) {
                bombCooldownLeft--;
            }

            // movement
            if (Keyboard.GetState().IsKeyDown(up)) {
                if (pos.Y > 0) {
                    pos.Y -= SPEED;
                }
            }
            if (Keyboard.GetState().IsKeyDown(left)) {
                if (pos.X > 0) {
                    pos.X -= SPEED;
                }
            }
            if (Keyboard.GetState().IsKeyDown(down)) {
                if (pos.Y + texture.Height < graphics.Viewport.Height) {
                    pos.Y += SPEED;
                }
            }
            if (Keyboard.GetState().IsKeyDown(right)) {
                if (pos.X + texture.Width < graphics.Viewport.Width) {
                    pos.X += SPEED;
                }
            }
            if (Keyboard.GetState().IsKeyDown(bomb)) {
                
                //if (pos.X + texture.Width + MonoBomberGame.bombTex.Width <= graphics.Viewport.Width) {
                    PlaceBomb(MonoBomberGame.bombTex);
                //}
            }

            // update the bombs that belong to this player
            //foreach(Bomb b in bombs) {
            //    b.Update();
            //}
        }

        // true if this player can place a bomb
        public Boolean HasBomb() {
            return bombCooldownLeft == 0;
        }

        // places a bomb to the right of this player
        public void PlaceBomb(Texture2D bombTex) {
            if(bombCooldownLeft == 0) {
                if(getTile().AttemptPlaceBomb(this)) {
                    bombCooldownLeft = BOMB_COOLDOWN_TIME;
                }
                //bombCooldownLeft = BOMB_COOLDOWN_TIME;
                //Point tile = this.getTile();
                //Vector2 bombPos = new Vector2(tile.X * MonoBomberGame.tile.Width, tile.Y * MonoBomberGame.tile.Height);
                //bombs.Add(new Bomb(bombTex, bombPos, color, game));
            }
        }

    }
}
