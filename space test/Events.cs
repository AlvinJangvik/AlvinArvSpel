using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace space_test
{
    class Events : VisualBase
    {
        private static int status = 2; // 0 = weapon base, 1 = enemy, 2 = health station, 3 = Casino
        private Texture2D healthP;
        private SpriteFont text;

        private static int priceChange = 0; // price change
        private static int eDMG = 0; // price change
        private static int bet = 2; // Times bet
        private int sum; // Final price

        private float wobble = 0; // Wobble
        private static int num = 50;
        private int change = num;
        private int Achange = 0;

        public Events(Texture2D tex, Texture2D Health_Planet, Vector2 cords, SpriteFont sprf)
        {
            skin = tex;
            healthP = Health_Planet;
            pos = cords;
            text = sprf;
        }

        public static int Status
        {
            get { return status; }
        }

        public static int PriceChange
        {
            get { return priceChange; }
        }

        public static int EnemyDMG
        {
            get { return eDMG; }
        }

        public static int Bet
        {
            get { return bet; }
        }

        public static void Jump() // Destination -------------------------------------------
        {
            priceChange = random(-15, 16);
            eDMG = random(-10, 16);
            bet = random(2, 6);
            status = random(0, 6);
            if(status == 4)
            {
                status = 1;
            }
            else if (status == 5)
            {
                status = 0;
            }
        }

        public void Update()
        {
            if (change > 0)
            {
                wobble -= 0.1f;
                change--;
            }
            else
            {
                wobble += 0.1f;
                Achange++;
            }

            if (change == 0 && Achange == num)
            {
                change = num;
                Achange = 0;
            }
        }

        private static int random(int min, int max)
        {
            Random rand = new Random();
            int r;

            return (r = rand.Next(min, max));
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            if (status == 0)
            {
                if (Star.Star_speed == 1)
                {
                    sum = 50 + priceChange;
                    spritebatch.DrawString(text,  sum + "$ for Weapon upgrade", new Vector2(600, 10), Color.Green);
                    spritebatch.Draw(skin, new Rectangle((int)pos.X + 100, (int)pos.Y - 50 + (int)wobble, 75, 200), Color.White);
                }
            }
            if (status == 2)
            {
                if (Star.Star_speed == 1)
                {
                    sum = 30 + priceChange;
                    spritebatch.DrawString(text, sum + "$ for heal", new Vector2(600, 10), Color.Green);
                    spritebatch.Draw(healthP, new Rectangle((int)pos.X + 50, (int)pos.Y - 50 + (int)wobble, 250, 250), Color.LightGreen);
                }
            }
            if (status == 3)
            {
                if (Star.Star_speed == 1)
                {
                    sum = 20 + priceChange;
                    spritebatch.DrawString(text, sum + "$ for " + bet +"X Bett", new Vector2(600, 10), Color.Purple);
                    spritebatch.Draw(healthP, new Rectangle((int)pos.X + 50, (int)pos.Y - 50 + (int)wobble, 250, 250), Color.MediumOrchid);
                }
            }
        }
    }
}
