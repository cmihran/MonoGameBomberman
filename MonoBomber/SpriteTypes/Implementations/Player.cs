using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoBomber.MacOS.SpriteTypes;

namespace MonoBomber.MacOS {
    /// <summary>
    /// A player that is capable of placing bombs
    /// </summary>
    public class Player : FreeMovingSprite {

        // how long it takes for bombs to recharge
        public const int BOMB_COOLDOWN_TIME = 50 + Explosion.LINGER_TIME;

        // base stats
        private const int SPEED = 8;
        public const int BASE_HEALTH = 100;

        // stats
        public int health;
        public int deaths;

        // how long this player has left until it can bomb again
        private int bombCooldownLeft;

        // keys the player uses
        private readonly Keys upKey;
        private readonly Keys leftKey;
        private readonly Keys downKey;
        private readonly Keys rightKey;
        private readonly Keys bombKey;

        public Player(Vector2 pos, Color color,
                      Keys up, Keys left, Keys down, Keys right, Keys bomb, MonoBomberGame game) : base(MonoBomberGame.playerTex, pos, color, game) {
            // bombs
            this.bombCooldownLeft = 0;

            this.health = BASE_HEALTH;
            this.deaths = 0;

            // keys
            this.upKey = up;
            this.leftKey = left;
            this.downKey = down;
            this.rightKey = right;
            this.bombKey = bomb;
        }

        public new void Draw() {
            base.Draw();

            Game.spriteBatch.DrawString(MonoBomberGame.font, "Health: " + health, pos, Color.White);
            Game.spriteBatch.DrawString(MonoBomberGame.font, "Deaths: " + deaths, new Vector2(pos.X, 20 + pos.Y), Color.White);
        }

        public override void Update() {
            if (EstimateTile().HasExplosion() && health > 0) {
                health--;
            }

            if (health <= 0) {
                health = BASE_HEALTH;
                deaths++;
            }

            // lower the bomb cooldown
            if (bombCooldownLeft > 0) {
                bombCooldownLeft--;
            }

            // movement
            KeyboardState state = Keyboard.GetState();

            // check up/down
            if (state.IsKeyDown(upKey)) {
                Tile up = EstimateTileUp();
                if (pos.Y > 0) {
                    if(up == null || !up.HasWall() || (up.HasWall() && pos.Y > up.pos.Y + up.Texture.Height)){
                        pos.Y -= SPEED;
                    }
                }
            } else if (state.IsKeyDown(downKey)) {
                Tile down = EstimateTileDown();
                if (pos.Y + Texture.Height < Game.graphics.GraphicsDevice.Viewport.Height) {
                    if(down == null || !down.HasWall() || (down.HasWall() && pos.Y + Texture.Height < down.pos.Y)) {
                        pos.Y += SPEED;
                    }
                }
            }

            // check left/right
            if (state.IsKeyDown(leftKey)) {
                Tile left = EstimateTileLeft();
                if (pos.X > 0) {
                    if (left == null || !left.HasWall() || (left.HasWall() && pos.X > left.pos.X + left.Texture.Height)) {
                        pos.X -= SPEED;
                    }
                }
            } else if (state.IsKeyDown(rightKey)) {
                Tile right = EstimateTileRight();
                if (pos.X + Texture.Width < Game.graphics.GraphicsDevice.Viewport.Width) {
                    if (right == null || !right.HasWall() || (right.HasWall() && pos.X + Texture.Width < right.pos.X)) {
                        pos.X += SPEED;
                    }
                }
            }

            // check bomb
            if (state.IsKeyDown(bombKey)) {
                if (HasBomb()) {
                    PlaceBomb();
                }
            }
        }

        // true if this player can place a bomb
        public bool HasBomb() => (bombCooldownLeft == 0);

        // places a bomb to the right of this player
        public void PlaceBomb() {
            if (bombCooldownLeft == 0) {
                Tile tile = EstimateTile();
                if (!tile.IsOccupied()) {
                    tile.PlaceBomb(this);
                    bombCooldownLeft = BOMB_COOLDOWN_TIME;
                }
            }
        }

    }
}
