using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace space_test
{
    class HealthBar : VisualBase
    {
        private static float health = 150;
        private static float Ehealth = 150;
        private Texture2D healthBar;
        private SpriteFont text;

        public HealthBar(Texture2D tex, Texture2D tex2, Vector2 vec, SpriteFont spr)
        {
            skin = tex;
            healthBar = tex2;
            pos = vec;
            text = spr;
        }

        public float Health
        {
            get { return health; }
        }

        public static void Heal()
        {
            health = 150;
        }

        public static float EHealth
        {
            get { return Ehealth; }
        }

        public static void reset()
        {
            Ehealth = 150;
        }

        public static void Loss(float dmg)
        {
            health -= dmg;
        }

        public static void ELoss(float dmg)
        {
            Ehealth -= dmg;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            // Player
            spritebatch.DrawString(text, "Health", new Vector2(10, 440), Color.White);
            spritebatch.Draw(healthBar, new Rectangle((int)pos.X-4, (int)pos.Y-4, 159, 24), Color.White);
            if (health > 75)
            {
                spritebatch.Draw(skin, new Rectangle((int)pos.X, (int)pos.Y, (int)health, 15), Color.Green);
            }
            else if (health > 50)
            {
                spritebatch.Draw(skin, new Rectangle((int)pos.X, (int)pos.Y, (int)health, 15), Color.Chartreuse);
            }
            else if (health > 25)
            {
                spritebatch.Draw(skin, new Rectangle((int)pos.X, (int)pos.Y, (int)health, 15), Color.Orange);
            }
            else
            {
                spritebatch.Draw(skin, new Rectangle((int)pos.X, (int)pos.Y, (int)health, 15), Color.Red);
            }

            // ENEMY
            if (Events.Status == 1)
            {
                if (Events.EnemyDMG < -3)
                {
                    spritebatch.DrawString(text, "Enemy Health", new Vector2(600, 25), Color.Green);
                }
                else if (Events.EnemyDMG >= -3 && Events.EnemyDMG < 6)
                {
                    spritebatch.DrawString(text, "Enemy Health", new Vector2(600, 25), Color.Yellow);
                }
                if (Events.EnemyDMG >= 6)
                {
                    spritebatch.DrawString(text, "Enemy Health", new Vector2(600, 25), Color.Red);
                }

                spritebatch.Draw(healthBar, new Rectangle(596, 10 - 4, 159, 24), Color.White);
                if (Ehealth > 75)
                {
                    spritebatch.Draw(skin, new Rectangle(600, 10, (int)Ehealth, 15), Color.Green);
                }
                else if (Ehealth > 50)
                {
                    spritebatch.Draw(skin, new Rectangle(600, 10, (int)Ehealth, 15), Color.Chartreuse);
                }
                else if (Ehealth > 25)
                {
                    spritebatch.Draw(skin, new Rectangle(600, 10, (int)Ehealth, 15), Color.Orange);
                }
                else
                {
                    spritebatch.Draw(skin, new Rectangle(600, 10, (int)Ehealth, 15), Color.Red);
                }
            }
        }
    }
}
