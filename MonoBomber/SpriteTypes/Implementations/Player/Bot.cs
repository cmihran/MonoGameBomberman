using System;
using Microsoft.Xna.Framework;

namespace MonoBomber.MacOS.SpriteTypes.Implementations {
    public class Bot : Player {

        Human opponent;
        
        public Bot(Vector2 pos, Color color, Human opponent, MonoBomberGame game) : base(pos, color, game) {
            this.opponent = opponent;
        }

        public override int GetSpeed() {
            return 5;
        }

        public new void Update() {
            base.Update();

            // if my pos is to the left of opponent pos, go right
            if (this.pos.X < opponent.pos.X) {
                //Console.WriteLine("need go right");
                if(CanMoveRight()) MoveRight();
                //else if(CanMoveUp()) MoveUp();
                //else if(CanMoveDown()) MoveDown();
                //else if(CanMoveLeft()) MoveLeft();
            } 
            // if my pos is to the right of opoonent, go left
            else if (this.pos.X > opponent.pos.X) {
                //Console.WriteLine("need go left");
                if (CanMoveLeft()) MoveLeft();
                //else if (CanMoveUp()) MoveUp();
                //else if (CanMoveDown()) MoveDown();
                //else if (CanMoveRight()) MoveRight();
            } else {
                if (HasBomb()) PlaceBomb();
            }

            // need to go up
            if (this.pos.Y > opponent.pos.Y) {
                //Console.WriteLine("need go up");
                if (CanMoveUp()) MoveUp();
                //else if (CanMoveLeft()) MoveLeft();
                //else if (CanMoveRight()) MoveRight();
                //else if (CanMoveDown()) MoveDown();
            } 
            // need to go down
            else if(this.pos.Y < opponent.pos.Y) {
                //Console.WriteLine("need go down");
                if (CanMoveDown()) MoveDown();
                //else if (CanMoveLeft()) MoveLeft();
                //else if (CanMoveRight()) MoveRight();
                //else if (CanMoveUp()) MoveUp();
            } else {
                if (HasBomb()) PlaceBomb();
            }
        }
    }
}
