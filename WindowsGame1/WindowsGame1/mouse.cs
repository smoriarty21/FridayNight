using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class mouse : Entity
    {
        public Vector2 location;
        public int tileColumn, tileRow; 
        int pointerWidth = 12;
        int pointerHeight = 18;

        //Set and Get info
        public void setLocation(int mouseX, int mouseY)
        {
            location = new Vector2(mouseX, mouseY);
            rectangle = new Rectangle(mouseX, mouseY, pointerWidth, pointerHeight);
        }
        public Vector2 getLocation()
        {
            return location;
        }

        //Tile Mouse is inside of
        public void setTile()
        {
            tileColumn = 0;
            tileRow = 0;
        }

        public void draw(SpriteBatch sb)
        {
            sb.Draw(image, rectangle, Color.White);
        }

    }
}
