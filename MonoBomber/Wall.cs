using System;
using Microsoft.Xna.Framework;

namespace MonoBomber.MacOS {
    public class Wall : Sprite, TempSprite {
        private int health;

        public Wall(Vector2 pos, MonoBomberGame game) : base(MonoBomberGame.wallTex, pos, Color.Gray, game) {
        }

        public bool ShouldReap() {
            throw new NotImplementedException();
        }

        public override void Update() {
            throw new NotImplementedException();
        }
    }
}
