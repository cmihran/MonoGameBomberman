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
            if (state.IsKeyDown(upKey) && CanMoveUp()) {
                pos.Y -= SPEED;
            } else if (state.IsKeyDown(downKey) && CanMoveDown()) {
                pos.Y += SPEED;
            }

            // check left/right
            if (state.IsKeyDown(leftKey) && CanMoveLeft()) {
                pos.X -= SPEED;
            } else if (state.IsKeyDown(rightKey) && CanMoveRight()) {
                pos.X += SPEED;
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
