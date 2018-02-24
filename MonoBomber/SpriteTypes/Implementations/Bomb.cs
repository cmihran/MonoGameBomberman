using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoBomber.MacOS.SpriteTypes;

namespace MonoBomber.MacOS {
    public class Bomb : TiledSprite {
        // who this bomb belongs to
        public Player owner;

        // time to explode
        private int timer;

        // amount of time bomb lingers after exploding

        public Bomb(Player owner, Tile tile, MonoBomberGame game) : base(MonoBomberGame.bombTex, tile, owner.Color, game) {
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
            Game.tiles[TileXIndex, TileYIndex].PlaceExplosion(owner);

            // going right
            int xCur = TileXIndex + 1;
            while (xCur < MonoBomberGame.NUM_TILES && !Game.tiles[xCur, TileYIndex].IsOccupied()) {
                Game.tiles[xCur, TileYIndex].PlaceExplosion(owner);
                xCur++;
            }

            // going left
            xCur = TileXIndex - 1;
            while (xCur >= 0 && !Game.tiles[xCur, TileYIndex].IsOccupied()) {
                Game.tiles[xCur, TileYIndex].PlaceExplosion(owner);
                xCur--;
            }

            // going down
            int yCur = TileYIndex + 1; ;
            while (yCur < MonoBomberGame.NUM_TILES && !Game.tiles[TileXIndex, yCur].IsOccupied()) {
                Game.tiles[TileXIndex, yCur].PlaceExplosion(owner);
                yCur++;
            }

            // going up
            yCur = TileYIndex - 1; ;
            while (yCur >= 0 && !Game.tiles[TileXIndex, yCur].IsOccupied()) {
                Game.tiles[TileXIndex, yCur].PlaceExplosion(owner);
                yCur--;
            }
        }
    }
}
