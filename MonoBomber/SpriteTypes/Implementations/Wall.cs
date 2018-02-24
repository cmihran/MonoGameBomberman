using System;
using Microsoft.Xna.Framework;
using MonoBomber.MacOS.SpriteTypes;

namespace MonoBomber.MacOS {
    public class Wall : TiledSprite, TempSprite {
        
        private int health;
        private const int BASE_HEALTH = 20;

        public Wall(Tile tile, MonoBomberGame game) : base(MonoBomberGame.wallTex, tile, Color.White, game) {
            this.health = Wall.BASE_HEALTH;
        }

        public override void Update() {
            //if(Tile.X == 5 && Tile.Y == 5) {
            //    //Console.WriteLine(Tile.NextToExplosion());
            //    //Console.WriteLine(health);
            //    Console.WriteLine(ShouldReap());
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
