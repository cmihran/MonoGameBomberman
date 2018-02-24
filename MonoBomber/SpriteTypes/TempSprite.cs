using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoBomber.MacOS {
    public interface TempSprite : Sprite {

        bool ShouldReap();
    }
}
