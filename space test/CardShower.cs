using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace space_test
{
    class CardShower
    {
        private static int cardCol = 1; // 1 = grön; 2 = röd; 3 = Blå;
        private static string[] nameParts = {"sho", "ra", "ro", "le", "op", "wa", "af", "gu", "it", "te", "kr", "ii", "sc", "ys", "tyk", "a", "j", "red", "oto", "pepi", "dago", "eri", "nav", "vop",
                                             "q", "m", "t", "mer", "eda", "pass"};
        private static string name;
        private static int wFig;
        private static int rare; // 1 - 4 = normal; 5 - 7 = uncommon;  8 - 9 = rare; 10 = god;

        private static SpriteFont text;
        private static Texture2D skin;
        private static Texture2D figure1;
        private static Texture2D figure2;

        private static Vector2 pos;

        public CardShower(Texture2D tex, SpriteFont sprf, Vector2 cords)
        {
            skin = tex;
            text = sprf;
            pos = cords;
        }

        public void LoadFigures(Texture2D fig1, Texture2D fig2)
        {
            figure1 = fig1;
            figure2 = fig2;
        }

        public static int[] Create()
        {
            Random rand = new Random();
            int[] card = { 0, 0, 0, 0, 0, 0}; /// 0 = color; 1-3 = name; 4 = figure; 5 = rarity
            card[0] = rand.Next(1, 4);
            for(int i = 1; i < 4; i++)
            {
                card[i] = rand.Next(1, nameParts.Length - 1);
            }
            card[4] = rand.Next(1, 3);
            card[5] = rand.Next(1, 11);

            return card;
        }

        public static void Show(SpriteBatch spritebatch, Vector2 cords, int col, int n1, int n2, int n3, int fig, int rarity)
        {
            pos = cords;
            cardCol = col;
            name = nameParts[n1] + nameParts[n2] + nameParts[n3];
            wFig = fig;
            rare = rarity;

            if (Star.Star_speed == 1)
            {
                /// ################## Card Color ###################################
                if (cardCol == 1)
                {
                    spritebatch.Draw(skin, new Rectangle((int)pos.X, (int)pos.Y, 165, 250), Color.Green);
                }
                else if (cardCol == 2)
                {
                    spritebatch.Draw(skin, new Rectangle((int)pos.X, (int)pos.Y, 165, 250), Color.Red);
                }
                else if (cardCol == 3)
                {
                    spritebatch.Draw(skin, new Rectangle((int)pos.X, (int)pos.Y, 165, 250), Color.Blue);
                }

                /// ################# Card Monster #####################################
                if (wFig == 1)
                {
                    spritebatch.Draw(figure1, new Rectangle((int)pos.X + 45, (int)pos.Y + 30, 16 * 4, 16 * 4), Color.White);
                }
                else if (wFig == 2)
                {
                    spritebatch.Draw(figure2, new Rectangle((int)pos.X + 45, (int)pos.Y + 30, 16 * 4, 16 * 4), Color.White);
                }

                /// ################# Card Name #####################################
                spritebatch.Draw(skin, new Rectangle((int)pos.X + 10, (int)pos.Y + 120, 120, 120), Color.Black);
                if (rare > 0 && rare < 5)
                {
                    spritebatch.DrawString(text, name, new Vector2((int)pos.X + 15, (int)pos.Y + 119), Color.White);
                }
                else if (rare > 4 && rare < 8)
                {
                    spritebatch.DrawString(text, name, new Vector2((int)pos.X + 15, (int)pos.Y + 119), Color.Yellow);
                }
                else if (rare > 7 && rare < 10)
                {
                    spritebatch.DrawString(text, name, new Vector2((int)pos.X + 15, (int)pos.Y + 119), Color.DarkOrange);
                }
                else if (rare == 10)
                {
                    spritebatch.DrawString(text, name, new Vector2((int)pos.X + 15, (int)pos.Y + 119), Color.Purple);
                }
            }
        }
    }
}
