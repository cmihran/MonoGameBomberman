using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoBomber.MacOS.SpriteTypes.Implementations {
    public class Human : Player {
        
        // keys the player uses
        private readonly Keys upKey;
        private readonly Keys leftKey;
        private readonly Keys downKey;
        private readonly Keys rightKey;
        private readonly Keys bombKey;

        public Human(Vector2 pos, Color color,
                      Keys up, Keys left, Keys down, Keys right, Keys bomb, MonoBomberGame game) : base(pos, color, game) {
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

        public new void Update() {
            base.Update();

            // movement
            KeyboardState state = Keyboard.GetState();

            // check up/down
            if (state.IsKeyDown(upKey)) {
                Tile up = EstimateTileUp();
                if (pos.Y > 0) {
                    if (up == null || !up.HasWall() || (up.HasWall() && pos.Y > up.pos.Y + up.Texture.Height)) {
                        pos.Y -= SPEED;
                    }
                }
            } else if (state.IsKeyDown(downKey)) {
                Tile down = EstimateTileDown();
                if (pos.Y + Texture.Height < Game.graphics.GraphicsDevice.Viewport.Height) {
                    if (down == null || !down.HasWall() || (down.HasWall() && pos.Y + Texture.Height < down.pos.Y)) {
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
    }
}
