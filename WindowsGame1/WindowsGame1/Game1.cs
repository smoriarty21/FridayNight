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
        string skillSelected;

        //Hotkeys **replace with user config**
        List<hotkeys> hotkeys = new List<hotkeys>();
        hotkeys setupHotkey = new hotkeys();


        //List for dropped skills
        List<ui> skillsPlacedOnBoard = new List<ui>();

        //Mouse Info and object
        public MouseState mouseStatus;
        public MouseState oldMouseState;
        public Vector2 mouseLocation;
        mouse mouse = new mouse();
        

        //Screen Size
        int screenHeight = 750;
        int screenWidth = 1400;

        //Game Time
        float gameTimer = 0f;
        int actualGameTime;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Initialize level
        Level level1 = new Level();

        //Menu
        ui menu = new ui();
        ui topBar = new ui();
        ui moneySign = new ui();
        ui setupSkills = new ui();
        List<ui> skills = new List<ui>();
        List<skill> chosenSkills = new List<skill>();
        List<ui> skillHotkeys = new List<ui>();
        int setSkill;

        //Initialize list for enemies
        List<Enemy> enemies = new List<Enemy>();
        Enemy makeEnemy = new Enemy();
        Tiles[,] tileArray =  new Tiles[9, 5];
        int tileRows, tileColumns, tileRow, tileColumn;

        // Variable for menu status (paused, playing, ect)
        String gameStatus; 

        //Money
        money cash = new money();

        //Tiles
        Tiles tiles = new Tiles();
        Boolean tileRowSet;

        //Fonts
        SpriteFont Font;
        SpriteFont skillHotkeysFont;

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
            //Old mouse state 
            oldMouseState = Mouse.GetState();

            //Initial selected skill **move or replace**
            skillSelected = "right";
            setSkill = 1;

            //Row and column of tiles
            tileRows = 5;
            tileColumns = 9;
            tileRowSet = false;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Fonts
            Font = Content.Load<SpriteFont>("Font");
            skillHotkeysFont = Content.Load<SpriteFont>("skillHotkeysFont");

            //Starting game status
            gameStatus = "playing";

            //Level 1
            level1 = level1.create(level1, screenWidth, screenHeight);

            //Setup UI
            menu = menu.setupMenu(level1.rectangle.X, level1.rectangle.Y, level1.bkgWidth, level1.bkgHeight);
            menu.image = Content.Load<Texture2D>("ui");

            topBar = topBar.setupTopBar(level1.rectangle.X, level1.rectangle.Y, level1.bkgWidth, level1.bkgHeight);
            topBar.image = Content.Load<Texture2D>("topBar");

            moneySign = moneySign.setupMoneySign(topBar.rectangle.X, topBar.rectangle.Y, level1.bkgWidth);
            moneySign.image = Content.Load<Texture2D>("dollarSign");
            cash.setLocation(moneySign.rectangle.X, moneySign.rectangle.Y);

            mouse.image = Content.Load<Texture2D>("arrowPointer");

            //Setup Tiles
            tiles.setupTiles(250, 10, 100, 100, screenWidth, screenHeight);
            tileArray = tiles.get();
            tiles.image = Content.Load<Texture2D>("skillOverlay");

            //Setup Skills
            setupSkills.setupSkills(menu.rectangle.X, menu.rectangle.Y, menu.rectangle.Height, menu.rectangle.Width);
            skills = setupSkills.getSkillsList();
            setupSkills.placeSkills(skills);
            chosenSkills = setupSkills.getChosenSkillsList();
            setupSkills.setupSkillHotkeys(skills);
            skillHotkeys = setupSkills.getSkillHotkeys();

            //Setup Hotkeys **change when adding user input for settings**
            setupHotkey.setupHotkeys();
            hotkeys = setupHotkey.getHotkeys();


            //Setup Skill Images
            for (int i = 0; i < chosenSkills.Count; i++)
            {
                chosenSkills[i].image = Content.Load<Texture2D>("skillButtons");
            }
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
                //Testing Stuff

                //Update Hotkey Selected Skill
                hotkeys[0].update();
                setSkill = hotkeys[0].getSkillSelected();

                //Mouse Click
                if (mouseStatus.LeftButton == ButtonState.Pressed && Mouse.GetState() != oldMouseState)
                {
                    setSkill -= 1;
                    for (int i = 0; i < 1; i++)
                    {
                        if (!tileArray[Convert.ToInt32(tiles.tileMouseOver.X), Convert.ToInt32(tiles.tileMouseOver.Y)].skillOnTile && chosenSkills[setSkill].type != "remove")
                        {
                            if ((cash.getTotalMoney() - chosenSkills[setSkill].cost) >= 0)
                            {
                                skillsPlacedOnBoard.Add(tiles.placeSkillOnTile(Convert.ToInt32(tiles.tileMouseOver.X), Convert.ToInt32(tiles.tileMouseOver.Y), setSkill + 1));
                                cash.removeCash(chosenSkills[setSkill].cost);

                                for (int j = 0; j < skillsPlacedOnBoard.Count; j++)
                                {
                                    if (skillsPlacedOnBoard[j].image == null)
                                        skillsPlacedOnBoard[j].image = Content.Load<Texture2D>("skillOverlay");
                                }
                            }
                        }
                        if (chosenSkills[setSkill].type == "remove" && ((cash.getTotalMoney() - chosenSkills[setSkill].cost) >= 0))
                        {
                            cash.removeCash(chosenSkills[setSkill].cost);
                        }
                    }
                }

                //Update List for tiles with skills on them
                tileArray = tiles.get();
                   
                //Set Mouse Location
                mouseStatus = Mouse.GetState();
                mouse.setLocation(mouseStatus.X, mouseStatus.Y);
                mouseLocation = new Vector2(mouse.rectangle.X, mouse.rectangle.Y);

                //Calculate tile mouse is over
                tiles.placeOverlay(mouseLocation);
                tiles.setRectangle(Convert.ToInt32(tiles.tileMouseOver.X), Convert.ToInt32(tiles.tileMouseOver.Y), 90, 90);
                tiles.setDrawRectangle(setSkill);
                
                //Setup Level 1
                level1.backgroundImage = Content.Load<Texture2D>("background");

                //Money
                cash.update(actualGameTime);

                //Spawn Enemies
                if (actualGameTime == 15)
                {
                    enemies.Add(makeEnemy.spawn(makeEnemy, tiles.tileArray[0, 2].x, tiles.tileArray[0, 2].y, actualGameTime));
                }

                //Add images to enemies
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].texture == "normal")
                    {
                        enemies[i].image = Content.Load<Texture2D>("enemy");
                    }
                }

                //Enemey starts walking after short pause(after spawn)
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].status == "spawn")
                    {
                        if (enemies[i].spawnTime + 15 < actualGameTime)
                        {
                            enemies[i].status = "moving";
                            enemies[i].xVelocity = 1;
                        }
                    }
                }
                
            }

            //Update Enemies
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].update(actualGameTime);
            }
           
            //Adjust Game Timer
            gameTimer += .000001f;
            actualGameTime = (int)(gameTimer * 100000f);
            base.Update(gameTime);

            //Update old mouse status
            oldMouseState = Mouse.GetState();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw Code
            spriteBatch.Begin();

            //Draw Menu
            menu.draw(spriteBatch);
            topBar.draw(spriteBatch);
            moneySign.draw(spriteBatch);

            //Draw Skills
            for (int i = 0; i < chosenSkills.Count; i++)
            {
                chosenSkills[i].draw(spriteBatch);
            }

            //Skill Hotkeys
            for (int i = 0; i < skillHotkeys.Count; i++)
            {
                skillHotkeys[i].drawHotkeys(spriteBatch, skillHotkeysFont);
            }

            //Draw Money
            cash.draw(spriteBatch, Font);

            //Draw Level
            level1.draw(spriteBatch);

            //Draw Image Overlay For tile mouse is over
            tiles.drawOverlay(spriteBatch);

            //Draw tiles placed
            for (int i = 0; i < skillsPlacedOnBoard.Count; i++)
            {
                skillsPlacedOnBoard[i].draw(spriteBatch);
            }

            //Draw Enemies
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].draw(spriteBatch);
            }

            //Draw Mouse Pointer
            mouse.draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
