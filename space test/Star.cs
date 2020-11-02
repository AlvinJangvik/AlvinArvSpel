using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace space_test
{
    class Star : VisualBase
    {
        private static int STAR_NUM = 100;
        private static int star_speed = 1;
        private static int last_star_speed;
        private static int star_color = 1;
        private static float star_width = 1;
        private static float star_height = 1;
        private static int jump = 0;
        private int[] starsX = new int[STAR_NUM];
        private int[] starsY = new int[STAR_NUM];

        public Star(Texture2D tex, Vector2 vec)
        {
            skin = tex;
            pos = vec;

            for(int i = STAR_NUM - 1; i >= 0; i--)
            {
                starsX[i] = random(0, 820);
                starsY[i] = random(0, 480);
            }
        }

        public static int Star_speed
        {
            get { return star_speed; }
        }

        public static void Jump()
        {
            jump = 150;
        }

        private static int random(int min, int max)
        {
            Random rand = new Random();
            int r;

            return (r = rand.Next(min, max));
        }

        public void Update()
        {

            for (int i = STAR_NUM - 1; i >= 0; i--) // Stjärnornas rörelse
            {
                if(starsX[i] < 1)
                {
                    starsX[i] += 820;
                    starsY[i] = random(0, 480);
                }

                else 
                {
                    starsX[i] -= star_speed;
                }
            }

            if (jump > 0) // Jump sekvensen
            {
                star_speed++;
                star_color++;
                star_width += 0.5f;
                star_height += 0.01f;
                jump--;
            }
            else if(star_speed > 1)
            {
                star_speed--;
                star_color--;
                star_width -= 0.5f;
                star_height -= 0.01f;
            }

            if(star_speed == 1 && star_speed != last_star_speed)
            {
                HealthBar.reset();
            }

            last_star_speed = star_speed;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            for (int i = STAR_NUM - 1; i >= 0; i--)
            {
                if (star_color - i > 1)
                {
                    spritebatch.Draw(skin, new Rectangle(starsX[i], starsY[i], (int)star_width, (int)star_height), Color.SkyBlue);
                }
                else
                {
                    spritebatch.Draw(skin, new Rectangle(starsX[i], starsY[i], (int)star_width, (int)star_height), Color.White);
                }
            }
        }

    }
}
