using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class Tiles :Entity
    {

        public int currentTileX, currentTileY;
        public const int tileArraySize = 45;
        public Tiles[,] tileArray = new Tiles[9,5];
        public List<ui> skillsPlacedOnBoard = new List<ui>();
        public int count = 1;
        Boolean overlayRowSet, overlayColumSet, mouseTileSet, mouseInsideTiles;
        public Vector2 tileMouseOver;
        public String imageString;
        private string skillToDraw;
        public Boolean skillOnTile;

        //test
        Rectangle testrectangle = new Rectangle(0,0,100,100);

        private int arrayColum = 0;
        private int row = 0;

        public void setupTiles(int backgroundX, int backgroundY, int tileWidth, int tileHeigh, int screenWidth, int screenHeight)
        {
            for (int i = 0; i < tileArraySize; i++)
            {
                if (i == 0 || count == 0)
                {
                    if (i == 0)
                    {
                        //Plus 5 is to spawn a little off the edge of the tile
                        currentTileX = backgroundX + 5;
                        currentTileY = backgroundY + (tileWidth - 5);
                    }

                    Tiles tile = new Tiles();
                    tile.height = 100;
                    tile.width = 100;
                    tile.x = currentTileX;
                    tile.y = currentTileY;
                    tileArray[row, arrayColum] = tile;

                    row += 1;
                    count += 1;
                }
                else if (row < 8)
                {
                    currentTileX += tileWidth;

                    Tiles tile = new Tiles();
                    tile.height = 100;
                    tile.width = 100;
                    tile.x = currentTileX;
                    tile.y = currentTileY;
                    tileArray[row, arrayColum] = tile;

                    row += 1;
                    count += 1;
                }

                else if (row == 8)
                {

                    currentTileX += tileWidth;

                    Tiles tile = new Tiles();
                    tile.height = 100;
                    tile.width = 100;
                    tile.x = currentTileX;
                    tile.y = currentTileY;
                    tileArray[row, arrayColum] = tile;

                    row = 0;
                    arrayColum += 1;

                    currentTileY += tileHeigh;
                    currentTileX = backgroundX;
                    count = 0;
                }
            }
                
        }

        public Tiles[,] get()
        {
            return tileArray;
        }

        //Calculate Tile mouse is over and place selected overlay there
        public void placeOverlay(Vector2 mouseLocation)
        {
            //Get size of 2d array
            int topBound = tileArray.GetLength(0);
            int lowBound = tileArray.GetLength(1);

            //Reset mouse tile for overlay
            mouseTileSet = false;
            mouseInsideTiles = false;
            overlayRowSet = false;
            overlayColumSet = false;

            //Check if mouse is inside tile array bounds
            if (mouseLocation.X < tileArray[0, 0].x || mouseLocation.X > tileArray[(topBound - 1), 0].x || mouseLocation.Y < (tileArray[0, 0].y - tileArray[0, 0].height) || mouseLocation.Y > tileArray[0, (lowBound - 1)].y)
                mouseInsideTiles = false;
            else
                mouseInsideTiles = true;

            //Set Initial Mouse Location
            if (mouseTileSet == false && mouseInsideTiles == true)
            {
                //If tile cursor is over variable is not set find curser mouse is over
                for (int i = 0; i < lowBound; i++)
                {
                    //Find row mouse is over
                    if (overlayRowSet == false && mouseLocation.Y > tileArray[0, i].y - (tileArray[0, i].height) && mouseLocation.Y < tileArray[0, i].y)
                    {
                        row = i;
                        overlayRowSet = true;
                    }
                }

                //Find colum mouse is over after row is set
                for (int i = 0; i < topBound; i++)
                {
                    if (overlayColumSet == false && overlayRowSet == true && mouseLocation.X > tileArray[i, row].x && mouseLocation.X < (tileArray[i, row].x + tileArray[i, row].width))
                    {
                        arrayColum = i;
                        overlayColumSet = true;
                    }
                }

                if (overlayColumSet == true && overlayRowSet == true)
                {
                    tileMouseOver = new Vector2(arrayColum, row);
                    mouseTileSet = true;
                }
            }
        }

        //Draw Rectangle and rectangle
        public void setDrawRectangle(int skill)
        {
            if (skill == 1)
                drawRectangle = new Rectangle(10,10,100,100);
            else if (skill == 2)
                drawRectangle = new Rectangle(120, 10, 100, 100);
            else if (skill == 4)
                drawRectangle = new Rectangle(230, 10, 100, 100);
            else if (skill == 3)
                drawRectangle = new Rectangle(10, 120, 100, 100);
            else if (skill == 5)
                drawRectangle = new Rectangle(120, 120, 100, 100);
            else if (skill == 6)
                drawRectangle = new Rectangle(230, 120, 100, 100);
            else if (skill == 7 )
                drawRectangle = new Rectangle(0, 220, 100, 100);
        }

        public void setRectangle(int column, int row, int width, int height)
        {
            int padding = 11;
            //System.Console.WriteLine(column);
            if (row == 0)
                rectangle = new Rectangle((tileArray[column, row].x + 1), (tileArray[column, row].y - tileArray[column, row].height + padding), width, height);
            else
                rectangle = new Rectangle((tileArray[column, row].x + 5), (tileArray[column, row].y - tileArray[column, row].height + padding - 1), width, height);
        }

        //Place Skill On Tile
        public ui placeSkillOnTile(int column, int row, int skillChosen)
        {
            tileArray[column, row].skillOnTile = true;

            ui skills = new ui();
            if (row > 0)
                skills.rectangle = new Rectangle(tileArray[column, row].x + 7, tileArray[column, row].y + 10 - tileArray[column, row].height, tileArray[column, row].width - 10, tileArray[column, row].height - 10);
            else
                skills.rectangle = new Rectangle(tileArray[column, row].x, tileArray[column, row].y - tileArray[column, row].height + 11, tileArray[column, row].width - 10, tileArray[column, row].height - 10);

            skills.setDrawRectangle(skillChosen);
            skills.name = "skill";
            skillsPlacedOnBoard.Add(skills);

            return skills;
        }

        //Change Enemy Tile 
        public Vector2 enemyTileChangeCheck(Enemy enemy)
        {
            if (enemy.currentTile.Y > 0 && enemy.currentTile.Y < 8)
            {
                if (enemy.currentTile.X == 0)
                {

                }
            }
            return enemy.currentTile;
        }
        
        //Draw overlay image in tile mouse is over
        public void drawOverlay(SpriteBatch sb)
        {
            sb.Draw(image, rectangle, drawRectangle, Color.White);
        }
    }
}
