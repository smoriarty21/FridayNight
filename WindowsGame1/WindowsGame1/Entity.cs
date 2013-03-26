using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class Entity
    {

        public int x, y, xVelocity, Yvelocity, height, width;
        public string name, texture;
        public Rectangle rectangle;
        public Boolean visible;
        public Texture2D image;

    }
}
