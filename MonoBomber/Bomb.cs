using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS {
    public class Bomb : Sprite {
        // who this bomb belongs to
        public Player owner;

        // time to explode
        private int timer;

        // amount of time bomb lingers after exploding

        public Bomb(Player owner, Vector2 pos, Color color, MonoBomberGame game) : base(MonoBomberGame.bombTex, pos, color, game) {
            this.owner = owner;
            this.timer = Player.BOMB_COOLDOWN_TIME;
        }

        public override void Update() {
            if (timer == 0) {
                Explode();
            }
            timer--;
        }

        private void Explode() {
            //this.texture = MonoBomberGame.explodeTex;
            int xIndex = this.getTileXIndex();
            int yIndex = this.getTileYIndex();
            game.tiles[xIndex, yIndex].PlaceSprite(new Explosion(owner, pos, color, game));

            // going right
            int xCur = xIndex + 1;
            while (xCur < MonoBomberGame.NUM_TILES && !game.tiles[xCur, yIndex].isOccupied()) {
                game.tiles[xCur, yIndex].PlaceSprite(new Explosion(owner, game.tiles[xCur, yIndex].pos, color, game));
                xCur++;
            }

            // going left
            xCur = xIndex - 1;
            while (xCur >= 0 && !game.tiles[xCur, yIndex].isOccupied()) {
                game.tiles[xCur, yIndex].PlaceSprite(new Explosion(owner, game.tiles[xCur, yIndex].pos, color, game));
                xCur--;
            }

            // going down
            int yCur = yIndex + 1; ;
            while (yCur < MonoBomberGame.NUM_TILES && !game.tiles[xIndex, yCur].isOccupied()) {
                game.tiles[xIndex, yCur].PlaceSprite(new Explosion(owner, game.tiles[xIndex, yCur].pos, color, game));
                yCur++;
            }

            // going up
            yCur = yIndex - 1; ;
            while (yCur >= 0 && !game.tiles[xIndex, yCur].isOccupied()) {
                game.tiles[xIndex, yCur].PlaceSprite(new Explosion(owner, game.tiles[xIndex, yCur].pos, color, game));
                yCur--;
            }
        }
    }
}
