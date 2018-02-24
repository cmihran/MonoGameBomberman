using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS {
    /// <summary>
    /// A Sprite is an game object with a texture and a position in 2D.
    /// It should not be instantiated on its own so it is abstract
    /// </summary>
    public interface Sprite {

        Texture2D Texture { get; }

        Color Color { get; }

        MonoBomberGame Game { get; }

        void Draw();

        void Update();

        //int TileXIndex();

        //int TileYIndex();

        Rectangle Bounding();

        //Tile TileLeft();

        //Tile TileRight();

        //Tile TileUp();

        //Tile TileDown();

    }
}
