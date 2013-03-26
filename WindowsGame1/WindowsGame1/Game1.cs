using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        //Screen Size
        int screenHeight = 750;
        int screenWidth = 1000;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Initialize level
        Level level1 = new Level();

        //Initialize list for enemies
        List<Enemy> enemies = new List<Enemy>();
        Enemy makeEnemy = new Enemy();

        // Variable for menu status (paused, playing, ect)
        String gameStatus; 

        //Tiles
        Tiles tiles = new Tiles();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.PreferredBackBufferWidth = screenWidth;
        }

       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Starting game status
            gameStatus = "playing";

        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed )
                this.Exit();

            if (gameStatus == "playing")
            {

                //Setup Level 1
                level1 = level1.create(level1, screenWidth, screenHeight);
                level1.backgroundImage = Content.Load<Texture2D>("background");

                enemies.Add(makeEnemy.spawn(makeEnemy));

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].texture == "normal")
                    {
                        enemies[i].image = Content.Load<Texture2D>("enemy");
                    }
                }

                tiles.setupTiles(level1.x, level1.y, 100, 100, screenWidth, screenHeight);

                
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw Code
            spriteBatch.Begin();

            level1.draw(spriteBatch);

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
