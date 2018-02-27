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

        public override int GetSpeed() {
            return 8;
        }

        public new void Update() {
            base.Update();

            // movement
            KeyboardState state = Keyboard.GetState();

            // check up/down
            if (state.IsKeyDown(upKey) && CanMoveUp()) {
                MoveUp();
            } else if (state.IsKeyDown(downKey) && CanMoveDown()) {
                MoveDown();
            }

            // check left/right
            if (state.IsKeyDown(leftKey) && CanMoveLeft()) {
                MoveLeft();
            } else if (state.IsKeyDown(rightKey) && CanMoveRight()) {
                MoveRight();
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
