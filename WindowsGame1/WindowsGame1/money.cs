using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class money 
    {
        //Set Starting Money
        int totalMoney = 100;

        //Variable to track gametime passed
        int lastGameTime, currentTime;
        Boolean gameTimeSet = false;
        private int updateSpeed = 15;

        //Location to draw total cash amount
        Vector2 location;

        //Spacers for drawing money
        private int xSpace = 11;
        private int ySpace = 3;

        //Set and get location for total amount of money
        public void setLocation(int dollarSignX, int dollarSignY)
        {
            dollarSignX += xSpace;
            dollarSignY -= ySpace;
            location = new Vector2(dollarSignX, dollarSignY);
        }

        public Vector2 getLocation()
        {
            return location;
        }

        //Add set ammount of money every x seconds
        public void update(int gameTime)
        {
            if (!gameTimeSet)
            {
                lastGameTime = gameTime;
                gameTimeSet = true;
            }
            else if (gameTimeSet)
            {
                currentTime = gameTime;

                if (currentTime >= lastGameTime + updateSpeed)
                {
                    totalMoney += 100;
                    gameTimeSet = false;
                }
            }
        }

        public int getTotalMoney()
        {
            return totalMoney;
        }

        public void removeCash(int amount)
        {
            totalMoney -= amount;
        }

        //Draw Method
        public void draw(SpriteBatch sb, SpriteFont font)
        {
            sb.DrawString(font, totalMoney.ToString(), location, Color.Yellow);
        }

    }
}
