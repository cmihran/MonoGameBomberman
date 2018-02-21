using System;
using Microsoft.Xna.Framework;

namespace MonoBomber.MacOS {
    public class Wall : Sprite, TempSprite {
        
        private int health;

        private const int BASE_HEALTH = 20;

        public Wall(Vector2 pos, MonoBomberGame game) : base(MonoBomberGame.wallTex, pos, Color.White, game) {
            this.health = Wall.BASE_HEALTH;
        }

        public override void Update() {
            //if(getTileXIndex() == 5 && getTileYIndex() == 5) {
                //Console.WriteLine(getTile().nextToExplosion());

            //}
            if(getTile().nextToExplosion()) {
                if(health > 0) {
                    health--;
                }
            }
        }

        public bool ShouldReap() => (health == 0);

    }
}
