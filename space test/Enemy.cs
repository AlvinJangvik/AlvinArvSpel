using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace space_test
{
    class Enemy : VisualBase
    {
        private float wobble = 0; // Wobble
        private static int num = 50;
        private int change = num;
        private int Achange = 0;

        public Enemy(Texture2D tex, Vector2 vec)
        {
            pos = vec;
            skin = tex;
        }

        public void Update()
        {
            if(change > 0)
            {
                wobble -= 0.1f;
                change--;
            }
            else
            {
                wobble += 0.1f;
                Achange++;
            }

            if(change == 0 && Achange == num)
            {
                change = num;
                Achange = 0;
            }
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            if (HealthBar.EHealth > 0)
            {
                if (Star.Star_speed == 1)
                {
                    spritebatch.Draw(skin, new Rectangle((int)pos.X, (int)pos.Y + (int)wobble, 150, 50), Color.White);
                }
            }
        }
    }
}
