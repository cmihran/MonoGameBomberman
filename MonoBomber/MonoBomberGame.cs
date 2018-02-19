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
    public class MonoBomberGame : Game
    {
        // link to your graphics device (lets you set various settings on how things
        // should be drawn, etc)
        public GraphicsDeviceManager graphics;

        // tool to use when you want to draw sprites to the screen
        SpriteBatch spriteBatch;

        Player p1;
        Player p2;

        public static Texture2D bombTex;
        public static Texture2D explodeTex;
        public static Texture2D rec;

        private SpriteFont font;

        private int p1Score = 0;
        private int p2Score = 0;

        public MonoBomberGame()
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
            p1 = new Player(Content.Load<Texture2D>("Images/akash"), Vector2.Zero, Color.LightBlue,
                            Keys.W, Keys.A, Keys.S, Keys.D, Keys.X, this);
            p2 = new Player(Content.Load<Texture2D>("Images/akash"), new Vector2(100, 100), Color.Pink,
                            Keys.Up, Keys.Left, Keys.Down, Keys.Right, Keys.L, this);

            font = Content.Load<SpriteFont>("fontScore");


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

            p1.Update(Keyboard.GetState(), graphics.GraphicsDevice);
            p2.Update(Keyboard.GetState(), graphics.GraphicsDevice);

            foreach(Bomb b in p1.bombs) {
                if(p2.CollidesWith(b)) {
                    p1Score++;
                }
            }

            foreach(Bomb b in p2.bombs) {
                if(p1.CollidesWith(b)) {
                    p2Score++;
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

            ///////


            p1.Draw(spriteBatch);
            p2.Draw(spriteBatch);

            spriteBatch.DrawString(font, "P1 Score: " + p1Score, new Vector2(100, 100), Color.Black);
            spriteBatch.DrawString(font, "P2 Score: " + p2Score, new Vector2(500, 100), Color.Black);


            ///////

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
