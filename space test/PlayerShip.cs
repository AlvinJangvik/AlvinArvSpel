using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace space_test
{
    class PlayerShip : VisualBase
    {
        private static bool jump = false;

        // wobble
        private float wobble = 0;
        private static int num = 55;
        private int change = num;
        private int Achange = 0;

        public PlayerShip(Texture2D tex, Vector2 vec)
        {
            skin = tex;
            pos = vec;
        }

        public void Update()
        {
            KeyboardState kstate = Keyboard.GetState();

            /*if (jump == false)
            {
                if (kstate.IsKeyDown(Keys.Space))
                {
                    Star.Jump();
                    jump = true;
                }
            }*/

            if(jump == true)
            {
                if(Star.Star_speed == 1)
                {
                    jump = false;
                }
            }

            //Wobble
            if (change > 0)
            {
                wobble -= 0.09f;
                change--;
            }
            else
            {
                wobble += 0.09f;
                Achange++;
            }

            if (change == 0 && Achange == num)
            {
                change = num;
                Achange = 0;
            }
        }

        public static bool Jump
        {
            get { return jump; }
            set { jump = value; }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            for (int i = Star.Star_speed / 2 + 1; i > 0; i--)
            {
                if(i == 1)
                {
                    spritebatch.Draw(skin, new Rectangle((int)pos.X - i, (int)pos.Y + (int)wobble, 512, 256), Color.White);
                }
                else if (i > 1 && i < 15)
                {
                    spritebatch.Draw(skin, new Rectangle((int)pos.X - i, (int)pos.Y + (int)wobble, 512, 256), Color.RoyalBlue); 
                }
                else if (i >= 15 && i < 35)
                {
                    spritebatch.Draw(skin, new Rectangle((int)pos.X - i, (int)pos.Y + (int)wobble, 512, 256), Color.Blue);
                }
                else
                {
                    spritebatch.Draw(skin, new Rectangle((int)pos.X - i, (int)pos.Y + (int)wobble, 512, 256), Color.DarkBlue);
                }
            }
        }
    }
}
