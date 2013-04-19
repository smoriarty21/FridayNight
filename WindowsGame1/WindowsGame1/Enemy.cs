using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class Enemy : Entity
    {

        public String status;
        public int spawnTime, currentTime, lastMoveTime;
        private int moveSpeed = 1;
        public Vector2 currentTile;

        public Enemy spawn(Enemy enemy, int x, int y, int gameTime)
        {

            enemy.width = 40;
            enemy.height = 115;
            enemy.spawnTime = gameTime;
            enemy.x = x;
            enemy.y = y - enemy.height;
            enemy.texture = "normal";
            enemy.status = "spawn";
            enemy.rectangle = new Rectangle(enemy.x, enemy.y, enemy.width, enemy.height);
            enemy.currentTile = new Vector2(0, 2);
            enemy.lastMoveTime = gameTime;

            return enemy;
        }

        public void update(int gameTime)
        {
            //Move Enemy
            if (status == "moving")
            {
                if (gameTime >= lastMoveTime + moveSpeed)
                {
                    x += xVelocity;
                    y += yVelocity;
                    rectangle.X = x;
                    rectangle.Y = y;

                    lastMoveTime = gameTime;
                    moveSpeed = getRandom(0, 2);
                }
            }
        }

        public void draw(SpriteBatch sb)
        {

            sb.Draw(image, rectangle, Color.White);

        }

    }
}
