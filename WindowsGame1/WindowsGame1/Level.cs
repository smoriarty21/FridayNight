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
    class Level
    {

        public int x, y, bkgHeight, bkgWidth;
        public Rectangle rectangle;
        public Texture2D backgroundImage;
        public int[,] tiles = new int[,] 
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public Level create(Level lvl, int screenWidth, int screenHeight)
        {

            lvl.bkgHeight = 500;
            lvl.bkgWidth = 900;
            lvl.x = (screenWidth - lvl.bkgWidth) / 2;
            lvl.y = 10;
            lvl.rectangle = new Rectangle(x, y, 900, 500); 
            return lvl;

        }


        public void draw(SpriteBatch sb)
        {
            sb.Draw(backgroundImage, rectangle, Color.White);
        }

    }
}
