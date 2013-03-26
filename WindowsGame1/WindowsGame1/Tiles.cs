using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class Tiles
    {

        public int x, y, width, height, currentTileX, currentTileY;
        public List<Tiles> tileList = new List<Tiles>();
        public Boolean enemyOnTile;
        public Rectangle rectangle = new Rectangle();

        public void setupTiles(int backgroundX, int backgroundY, int tileWidth, int tileHeigh, int screenWidth, int screenHeight)
        {
            Tiles newTile = new Tiles();

            for (int i = 0; i < 45; i++)
            {
                if (i == 0)
                {
                    newTile.currentTileX = backgroundX;
                    newTile.currentTileY = backgroundY;

                    newTile.x = newTile.currentTileX;
                    newTile.y = newTile.currentTileY;

                    tileList.Add(newTile);

                    newTile.currentTileX += tileWidth;
                }
                else if (i > 0 && i < 8 || i > 9 && i < 17 || i > 18 && i < 26 || i > 27 && i < 35 || i > 36 && i < 44)
                {
                    newTile.x = newTile.currentTileX;
                    newTile.y = newTile.currentTileY;

                    tileList.Add(newTile);

                    newTile.currentTileX += tileWidth;
                }
                else if ( i == 8 || i == 17 || i == 26 || i == 35 || i == 44)
                {
                    newTile.x = newTile.currentTileX;
                    newTile.y = newTile.currentTileY;

                    tileList.Add(newTile);

                    newTile.currentTileX = backgroundX;
                    newTile.currentTileY += tileHeigh;
                }
            }
                
        }


    }
}
