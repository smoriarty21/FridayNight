using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    class skill : Tiles
    {
        public string type;
        public int cost;
        List<skill> skillsChosen = new List<skill>();
        public Boolean removeActive;

        public void placeSkills(List<ui> listOfChosenSkills)
        {
            for (int i = 0; i < listOfChosenSkills.Count; i++)
            {
                skillsChosen.Add(new skill());

                if (i == 0)
                    skillsChosen[i].type = "right";
                if (i == 1)
                    skillsChosen[i].type = "up";
                if (i == 2)
                    skillsChosen[i].type = "down";
                if (i == 3)
                    skillsChosen[i].type = "coke";
                if (i == 4)
                    skillsChosen[i].type = "booze";
                if (i == 5)
                    skillsChosen[i].type = "bouncer";

                skillsChosen[i].x = listOfChosenSkills[i].x;
                skillsChosen[i].name = "skill";
                skillsChosen[i].y = listOfChosenSkills[i].y;
                skillsChosen[i].height = listOfChosenSkills[i].height;
                skillsChosen[i].width = listOfChosenSkills[i].width;
                skillsChosen[i].rectangle = new Rectangle(skillsChosen[i].x, skillsChosen[i].y, skillsChosen[i].width, skillsChosen[i].height);
                skillsChosen[i].drawRectangle = new Rectangle(0, 0, 100, 100);

                //Apply properties for chosen skill
                if (skillsChosen[i].type == "up")
                {
                    skillsChosen[i].drawRectangle = new Rectangle(0, 0, 100, 100);
                    skillsChosen[i].cost = 200;
                }

                if (skillsChosen[i].type == "down")
                {
                    skillsChosen[i].drawRectangle = new Rectangle(110, 0, 100, 100);
                    skillsChosen[i].cost = 200;
                }

                if (skillsChosen[i].type == "right")
                {
                    skillsChosen[i].drawRectangle = new Rectangle(220, 0, 100, 100);
                    skillsChosen[i].cost = 200;
                }

                if (skillsChosen[i].type == "booze")
                {
                    skillsChosen[i].drawRectangle = new Rectangle(0, 110, 100, 100);
                    skillsChosen[i].cost = 500;
                }

                if (skillsChosen[i].type == "coke")
                {
                    skillsChosen[i].drawRectangle = new Rectangle(110, 110, 100, 100);
                    skillsChosen[i].cost = 700;
                }

                if (skillsChosen[i].type == "bouncer")
                {
                    skillsChosen[i].drawRectangle = new Rectangle(220, 110, 100, 100);
                    skillsChosen[i].cost = 500;
                }
            }

            //Setup Remove Skill And add to end of list
            int x = skillsChosen.Count;

            skillsChosen.Add(new skill());
            skillsChosen[x].type = "remove";
            skillsChosen[x].name = "skill";
            skillsChosen[x].cost = 100;
            skillsChosen[x].removeActive = false;
        }

        public List<skill> getChosenSkillsList()
        {
            return skillsChosen;
        }

        public int getSkillCost(int skill)
        {
            int skillCost = skillsChosen[skill].cost;
            return skillCost;
        }

        public void draw(SpriteBatch sb)
        {
            if (name == "menuBkg" || name == "skill")
                sb.Draw(image, rectangle, drawRectangle, Color.White);
            else
                sb.Draw(image, rectangle, Color.White);
        }
    }
}
