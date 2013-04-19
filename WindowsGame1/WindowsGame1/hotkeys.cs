using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    class hotkeys
    {
        KeyboardState oldState;

        public int value;
        private List<hotkeys> hotkeyList = new List<hotkeys>();
        public int setSkill;
        public Boolean remove = false;

        public void setupHotkeys()
        {
            for (int i = 0; i < 6; i++)
            {
                hotkeyList.Add(new hotkeys());
                hotkeyList[i].value = i + 1;
            }

            oldState = Keyboard.GetState();
        }

        public List<hotkeys> getHotkeys()
        {
            return hotkeyList;
        }

        public void update()
        {
            //Check user input
            if (Keyboard.GetState().IsKeyDown(Keys.D1) && Keyboard.GetState() != oldState)
            {
                setSkill = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2) && Keyboard.GetState() != oldState)
            {
                setSkill = 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D3) && Keyboard.GetState() != oldState)
            {
                setSkill = 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D4) && Keyboard.GetState() != oldState)
            {
                setSkill = 4;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D5) && Keyboard.GetState() != oldState)
            {
                setSkill = 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D6) && Keyboard.GetState() != oldState)
            {
                setSkill = 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D7) && Keyboard.GetState() != oldState)
            {
                setSkill = 7;
            }

            //Update old State of keyboard
            oldState = Keyboard.GetState();
        }

        public Boolean getRemove()
        {
            return remove;
        }

        public int getSkillSelected()
        {
            return setSkill;
        }
            
    }
}
