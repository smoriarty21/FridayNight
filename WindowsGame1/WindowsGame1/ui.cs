using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    class ui : skill
    {
        //Money info
        private int moneySignWidth, moneySignHeight;

        //Skill Info
        private int padding, skillTileLength;
        private List<ui> skillList = new List<ui>();
        
        //Location for draw
        private Vector2 location;

        //Text For hotkey and hotkey value
        private List<ui> skillHotkeys = new List<ui>();
        public string hotkeyText;
        public string imageString;
        public string hotkey;

        public static int text;

        //Setup menu background
        public ui setupMenu(int backgroundX, int backgroundY, int backgroundWidth, int backgroundHeight)
        {
            ui menuBkg = new ui();

            menuBkg.rectangle.X = backgroundX;
            menuBkg.rectangle.Y = backgroundY + backgroundHeight;
            menuBkg.rectangle = new Rectangle(menuBkg.rectangle.X, menuBkg.rectangle.Y + 25, backgroundWidth, 200);
            menuBkg.drawRectangle = new Rectangle(0, 0, 900, 250);
            menuBkg.name = "menuBkg";

            return menuBkg;
        }

        //setup topbar where money value is located
        public ui setupTopBar(int backgroundX, int backgroundY, int backgroundWidth, int backgroundHeight)
        {
            ui topBar = new ui();

            topBar.rectangle.X = backgroundX;
            topBar.rectangle.Y = backgroundY + backgroundHeight;
            topBar.rectangle = new Rectangle(topBar.rectangle.X, topBar.rectangle.Y, backgroundWidth, 25);
            topBar.name = "topBar";

            return topBar;

        }

        //Setup money sign before money value
        public ui setupMoneySign(int topBarX, int topBarY, int topBarHeight)
        {
            ui moneySign = new ui();

            moneySignWidth = 8;
            moneySignHeight = 12;

            moneySign.rectangle.X = topBarX + 15;
            moneySign.rectangle.Y = topBarY + ((26 - moneySignHeight) / 2);
            moneySign.rectangle = new Rectangle(moneySign.rectangle.X, moneySign.rectangle.Y, moneySignWidth, moneySignHeight);
            moneySign.name = "moneySign";

            return moneySign;

        }

        //Setup locations for skills chosen by user
        public void setupSkills(int menuBkgX, int menuBkgY, int menuBkgHeight, int menuBkgWidth)
        {
            padding = 10;
            skillTileLength = 3;

            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    skillList.Add(new ui());
                    skillList[i].height = 65;
                    skillList[i].width = 65;
                    skillList[i].x = menuBkgX + (skillList[i].width * i) + padding + 50;
                    skillList[i].y = menuBkgY + padding + ((menuBkgHeight - ((skillList[i].height * 2) + padding * 3)) / 2);
                }
                else
                {
                    skillList.Add(new ui());
                    skillList[i].height = 65;
                    skillList[i].width = 65;

                    if (i > 0 && i <= 2)
                    {
                        skillList[i].y = menuBkgY + padding + ((menuBkgHeight - ((skillList[i].height * 2) + padding * 3)) / 2);
                        skillList[i].x = menuBkgX + padding + (skillList[i].width * i) + (i * padding) + 50;
                    }
                    else if (i > 2 && i <= 5)
                    {
                        skillList[i].y = menuBkgY + (skillList[i].height + (padding * 2)) + ((menuBkgHeight - ((skillList[i].height * 2) + padding * 3)) / 2);
                        skillList[i].x = skillList[i - skillTileLength].x;
                    }
                }
            }
        }

        public List<ui> getSkillsList()
        {
            return skillList;
        }

        //Setup location and text for skill hotkeys
        public void setupSkillHotkeys(List<ui> skillsList)
        {
            for (int i = 0; i < skillsList.Count; i++)
            {
                skillHotkeys.Add(new ui());
                skillHotkeys[i].height = 18;
                skillHotkeys[i].width = 12;
                skillHotkeys[i].x = ((skillsList[i].x + skillsList[i].width) - skillHotkeys[i].width);
                skillHotkeys[i].y = ((skillsList[i].y + skillsList[i].height) - skillHotkeys[i].height);
                skillHotkeys[i].location = new Vector2(skillHotkeys[i].x, skillHotkeys[i].y);
                skillHotkeys[i].hotkeyText = (i + 1).ToString();
                skillHotkeys[i].hotkey = (i + 1).ToString();
            }
        }

        public List<ui> getSkillHotkeys()
        {
            return skillHotkeys;
        }

        //Draw skill hotkeys 
        public void drawHotkeys(SpriteBatch sb, SpriteFont font)
        {
            sb.DrawString(font, hotkeyText, location, Color.Silver);
        }
    }
}
