using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoBomber.MacOS {
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MonoBomberGame : Game {

        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        Player p1;
        Player p2;

        public static Texture2D bombTex;
        public static Texture2D explodeTex;
        public static Texture2D playerTex;
        public static Texture2D tileTex;
        public static Texture2D wallTex;

        private const String IMG_DIR = "Images/";

        public static SpriteFont font;

        public const int NUM_TILES = 10;
        private const int TILE_LEN = 75;
        public Tile[,] tiles;

        private Random rnd;

        public MonoBomberGame() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            base.Initialize();

            ////////////////////////////

            p1 = new Player(new Vector2(TILE_LEN, TILE_LEN), Color.LightBlue,
                            Keys.W, Keys.A, Keys.S, Keys.D, Keys.X, this);
            p2 = new Player(new Vector2(TILE_LEN, TILE_LEN), Color.Pink,
                            Keys.Up, Keys.Left, Keys.Down, Keys.Right, Keys.L, this);

            tiles = new Tile[NUM_TILES, NUM_TILES];
            for (int x = 0; x < NUM_TILES; x++) {
                for (int y = 0; y < NUM_TILES; y++) {
                    tiles[x, y] = new Tile(x, y, new Vector2(x * TILE_LEN, y * TILE_LEN), this);
                    if (x == 0 || y == 0 || x == NUM_TILES - 1 || y == NUM_TILES - 1) {
                        tiles[x, y].PlaceWall();
                   }
                }
            }

            tiles[2, 2].PlaceWall();
            tiles[2, 3].PlaceWall();
            tiles[2, 4].PlaceWall();
            tiles[2, 5].PlaceWall();
            tiles[2, 6].PlaceWall();
            tiles[2, 7].PlaceWall();

            tiles[4, 2].PlaceWall();
            tiles[4, 3].PlaceWall();
            tiles[4, 4].PlaceWall();
            tiles[4, 5].PlaceWall();
            tiles[4, 6].PlaceWall();
            tiles[4, 7].PlaceWall();

            tiles[5, 2].PlaceWall();
            tiles[5, 3].PlaceWall();
            tiles[5, 4].PlaceWall();
            tiles[5, 5].PlaceWall();
            tiles[5, 6].PlaceWall();
            tiles[5, 7].PlaceWall();

            tiles[7, 2].PlaceWall();
            tiles[7, 3].PlaceWall();
            tiles[7, 4].PlaceWall();
            tiles[7, 5].PlaceWall();
            tiles[7, 6].PlaceWall();
            tiles[7, 7].PlaceWall();

            rnd = new Random();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ////////////////////////////

            tileTex = new Texture2D(GraphicsDevice, TILE_LEN, TILE_LEN);
            tileTex.CreateBorder(5, Color.SlateGray);

            wallTex = Content.Load<Texture2D>(IMG_DIR + "wall");

            graphics.PreferredBackBufferWidth = TILE_LEN * NUM_TILES;
            graphics.PreferredBackBufferHeight = TILE_LEN * NUM_TILES;
            graphics.ApplyChanges();

            font = Content.Load<SpriteFont>("fontScore");

            playerTex = this.Content.Load<Texture2D>(IMG_DIR + "player");
            bombTex = this.Content.Load<Texture2D>(IMG_DIR + "bomb");
            explodeTex = this.Content.Load<Texture2D>(IMG_DIR + "explode");

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ////////////////////////////

            // tiles
            foreach (Tile tile in tiles) {
                tile.Update();
            }

            // players
            p1.Update();
            p2.Update();

            //if(rnd.Next(50) == 0) {
            //    int x = rnd.Next(NUM_TILES);
            //    int y = rnd.Next(NUM_TILES);
            //    //while(tiles[x, y].isOccupied()) {
            //    //    x = rnd.Next(NUM_TILES);
            //    //    y = rnd.Next(NUM_TILES);
            //    //} 
            //    tiles[x, y].PlaceSprite(new Wall(tiles[x, y].pos, this));
            //}

            ////////////////////////////

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            graphics.GraphicsDevice.Clear(Color.ForestGreen);

            spriteBatch.Begin();

            ////////////////////////////

            // tiles
            foreach (Tile t in tiles) {
                t.Draw();
            }

            // players
            p1.Draw();
            p2.Draw();

            ////////////////////////////

            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
