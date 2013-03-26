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

        public Enemy spawn(Enemy enemy)
        {

            enemy.width = 40;
            enemy.height = 115;
            enemy.x = 10;
            enemy.y = 290 - enemy.height;
            enemy.texture = "normal";
            enemy.rectangle = new Rectangle(enemy.x, enemy.y, enemy.width, enemy.height); 

            return enemy;
        }

        public void draw(SpriteBatch sb)
        {

            sb.Draw(image, rectangle, Color.White);

        }

    }
}
