using System;
using Microsoft.Xna.Framework;
using MonoBomber.MacOS.SpriteTypes;

namespace MonoBomber.MacOS {
    public class Wall : TiledSprite {
        
        private int health;
        private const int BASE_HEALTH = 20;

        public Wall(Tile tile, MonoBomberGame game) : base(MonoBomberGame.wallTex, tile, Color.White, game) {
            this.health = Wall.BASE_HEALTH;
        }

        public override void Update() {
            //if(getTileXIndex() == 5 && getTileYIndex() == 5) {
                //Console.WriteLine(getTile().nextToExplosion());

            //}
            if(Tile.NextToExplosion()) {
                if(health > 0) {
                    health--;
                }
            }
        }

        public bool ShouldReap() => (health == 0);

    }
}
