using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoBomber.MacOS {
    /// <summary>
    /// A player that is capable of placing bombs
    /// </summary>
    public class Player : Sprite {
        // how long it takes for bombs to recharge
        public const int BOMB_COOLDOWN_TIME = 50 + Explosion.LINGER_TIME;

        // stats
        private const int SPEED = 8;
        public const int BASE_HEALTH = 100;

        // how long this player has left until it can bomb again
        private int bombCooldownLeft;

        public int health;

        public int deaths;

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

            game.spriteBatch.DrawString(MonoBomberGame.font, "Health: " + health, pos, Color.White);
            game.spriteBatch.DrawString(MonoBomberGame.font, "Deaths: " + deaths, new Vector2(pos.X,20 + pos.Y), Color.White);

        }

        public override void Update() {
            if (getTile().hasExplosion() && health > 0) {
                health--;
            }

            if(health <= 0) {
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
                Tile up = getTileUp();
                if (pos.Y > 0 && (up == null || (up != null && !up.hasWall()))) {
                    pos.Y -= SPEED;
                }
            } else if (state.IsKeyDown(downKey)) {
                Tile down = getTileDown();
                if (pos.Y + texture.Height < game.graphics.GraphicsDevice.Viewport.Height && (down == null || (down != null && !down.hasWall()))) {
                    pos.Y += SPEED;
                }
            }

            // check left/right
            if (state.IsKeyDown(leftKey)) {
                Tile left = getTileLeft();
                if (pos.X > 0 && (left == null || (left != null && !left.hasWall()))) {
                    pos.X -= SPEED;
                }
            } else if (state.IsKeyDown(rightKey)) {
                Tile right = getTileRight();
                if (pos.X + texture.Width < game.graphics.GraphicsDevice.Viewport.Width && (right == null || (right != null && !right.hasWall()))) {
                    pos.X += SPEED;
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
                Tile tile = getTile();
                if (!tile.isOccupied()) {
                    tile.PlaceSprite(new Bomb(this, tile.pos, color, game));
                    bombCooldownLeft = BOMB_COOLDOWN_TIME;
                }
            }
        }

    }
}
