using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace space_test
{
    class Internet : VisualBase
    {
        private static bool active = false;
        private SpriteFont text;

        private int[] cards = {0, 0, 0, 0, 0, 0 };

        private static int scene = 0; // 0 = startsida

        // MUSEN
        private int x;
        private int y;
        private MouseState oldMState;

        public Internet(Texture2D tex, SpriteFont sprf, Vector2 cords)
        {
            skin = tex;
            pos = cords;
            text = sprf;
        }

        public static bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public void Update()
        {
            MouseState mState = Mouse.GetState();
            x = mState.X;
            y = mState.Y;

            if(mState.LeftButton == ButtonState.Pressed && oldMState.LeftButton == ButtonState.Released && active == true)
            {
                if(x > 739 && x < 761 && y > 29 && y < 51) // Avstägning
                {
                    active = false;
                }
                else if (x > 59 && x < 226 && y > 59 && y < 311) // Avstägning
                {
                    cards = CardShower.Create();
                }
            }


            oldMState = mState;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            if (Star.Star_speed == 1)
            {
                if (active == true)
                {
                    spritebatch.Draw(skin, new Rectangle((int)pos.X, (int)pos.Y, 760, 440), Color.Gray); // Bakgrund
                    if (x > 739 && x < 761 && y > 29 && y < 51) // Avstägning
                    {
                        spritebatch.Draw(skin, new Rectangle(738, 28, 24, 24), Color.Red);
                        spritebatch.DrawString(text, "X", new Vector2(740, 10), Color.Black, 0f, new Vector2(0, 0), 2.5f, SpriteEffects.FlipVertically, 0f);
                    }
                    else
                    {
                        spritebatch.Draw(skin, new Rectangle(740, 30, 20, 20), Color.Red); // Avstägnings knapp
                        spritebatch.DrawString(text, "X", new Vector2(742, 15), Color.Black, 0f, new Vector2(0, 0), 2f, SpriteEffects.FlipVertically, 0f);
                    }

                    // ######## Start Meny ############
                    if(scene == 0)
                    {
                        CardShower.Show(spritebatch, new Vector2(60, 60), cards[0], cards[1], cards[2], cards[3], cards[4], cards[5]);
                    }
                }
            }
        }
    }
}
