using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoBomber.MacOS
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // link to your graphics device (lets you set various settings on how things
        // should be drawn, etc)
        GraphicsDeviceManager graphics;

        // tool to use when you want to draw sprites to the screen
        SpriteBatch spriteBatch;

        Player p1;

        public static Texture2D bombTex;
        public static Texture2D explodeTex;

        readonly int SPEED = 8;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            p1 = new Player(Content.Load<Texture2D>("Images/akash"), Vector2.Zero);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            bombTex = this.Content.Load<Texture2D>("Images/bomb");
            explodeTex = this.Content.Load<Texture2D>("Images/explode");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            p1.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.W)) 
            {
                if (p1.pos.Y > 0) 
                {
                    p1.pos.Y -= SPEED;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (p1.pos.X > 0)
                {
                    p1.pos.X -= SPEED;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (p1.pos.Y + p1.texture.Height < graphics.GraphicsDevice.Viewport.Height)
                {
                    p1.pos.Y += SPEED;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (p1.pos.X + p1.texture.Width < graphics.GraphicsDevice.Viewport.Width)
                {
                    p1.pos.X += SPEED;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                if (p1.pos.X + p1.texture.Width + bombTex.Width <= graphics.GraphicsDevice.Viewport.Width)
                {
                    p1.PlaceBomb(bombTex);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            p1.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
