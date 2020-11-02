using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace space_test
{
    class Controlls
    {
        KeyboardState kprev;
        private static int money = 0;
        private static int dmg = 25;
        private static int score = 0;
        private int lastHealth;

        SpriteFont text;
        public Controlls(SpriteFont sprf)
        {
            text = sprf;
        }

        public static int Money
        {
            get { return money; }
        }

        public static int Score
        {
            get { return score; }
        }

        public static int Dmg
        {
            get { return dmg; }
        }

        public void Update(ref bool fps, ref int game)
        {
            KeyboardState kstate = Keyboard.GetState();
            
            if(game == 2) // menu
            {
                if (kstate.IsKeyDown(Keys.A)) { game = 1; }
            }


            // ########################################## Gameplay #############################################################################
            else if (game == 1)
            {
                if(HealthBar.EHealth < 1 && lastHealth != (int)HealthBar.EHealth) // Earning money
                {
                    money += random(10 + Events.EnemyDMG + (Controlls.Dmg / 11), 51 + Events.EnemyDMG + (Controlls.Dmg / 11));
                    score += random(10 + Events.EnemyDMG + (Controlls.Dmg / 11), 51 + Events.EnemyDMG + (Controlls.Dmg / 11));
                }
                if (Star.Star_speed == 1) // Laser
                {
                    if (Events.Status == 1)
                    {
                        if (kstate.IsKeyDown(Keys.Q) && Laser.LaserMoving == 0 && Turns.Turn == 1) // Laser attack mot fienden
                        {
                            Turns.Turn = 2;
                            Laser.Eshoot(random(dmg - 20, dmg + 1));
                            //Laser.shoot((float)random(170, 330));
                        }
                    }
                }

                // ####################################### Köpa #######################################################################
                if (Star.Star_speed == 1)
                {
                    if (Events.Status == 0)
                    {
                        if (kstate.IsKeyDown(Keys.E) && !kprev.IsKeyDown(Keys.E) && money >= 50 + Events.PriceChange) // Köpa vapen
                        {
                            dmg += 10;
                            score += 10;
                            money -= 50 + Events.PriceChange;
                        }
                    }
                    if (Events.Status == 2)
                    {
                        if (kstate.IsKeyDown(Keys.E) && !kprev.IsKeyDown(Keys.E) && money >= 30 + Events.PriceChange) // Köpa Liv
                        {
                            HealthBar.Heal();
                            money -= 30 + Events.PriceChange;
                        }
                    }
                    if (Events.Status == 3)
                    {
                        if (kstate.IsKeyDown(Keys.E) && !kprev.IsKeyDown(Keys.E) && money >= 20 + Events.PriceChange) // Betting
                        {
                            if (random(1, Events.Bet + 1) == 1)
                            {
                                money += (20 + Events.PriceChange) * (Events.Bet - 1);
                            }

                            else
                            {
                                money -= 20 + Events.PriceChange;
                            }
                        }
                    }
                }

                // ################################### Internet #############################################################
                if(Star.Star_speed == 1)
                {
                    if (kstate.IsKeyDown(Keys.I) && !kprev.IsKeyDown(Keys.I))
                    {
                        if(Internet.Active == true)
                        {
                            Internet.Active = false;
                        }
                        else
                        {
                            Internet.Active = true;
                        }
                    }
                }

                // ################################ FTL Jump ###############################################################
                if (PlayerShip.Jump == false) 
                {
                    if (kstate.IsKeyDown(Keys.Space))
                    {
                        if (Events.Status != 1 || Events.Status == 1 && HealthBar.EHealth < 1)
                        {
                            Star.Jump();
                            Turns.Turn = 1;
                            PlayerShip.Jump = true;
                            Events.Jump();
                        }
                    }
                }
            }

            if (kstate.IsKeyDown(Keys.P) && fps == false && !kprev.IsKeyDown(Keys.P)) // show fps
            {
                fps = true;
            }
            else if (kstate.IsKeyDown(Keys.P) && fps == true && !kprev.IsKeyDown(Keys.P))
            {
                fps = false;
            }

            if (kstate.IsKeyDown(Keys.N) && !kprev.IsKeyDown(Keys.N))
            {
                End.SetQ();
            }

            kprev = kstate;
            lastHealth = (int)HealthBar.EHealth;

            /*if (kstate.IsKeyDown(Keys.K) && Laser.LaserMoving == 0) // Test mot spelar skeppet
            {
                Laser.shoot((float)random(170, 330));
                End.SetQ();
            }*/

            
        }

        private static int random(int min, int max)
        {
            Random rand = new Random();
            int r;

            return (r = rand.Next(min, max));
        }
        public void Draw(SpriteBatch spritebatch)
        {
            // Stats
            spritebatch.DrawString(text, "Money: " + money + "$", new Vector2(80, 10), Color.Gold);
            spritebatch.DrawString(text, "DMG: " + dmg, new Vector2(210, 10), Color.Gold);


            // Attacks
            spritebatch.DrawString(text, "Q for laser", new Vector2(200, 448), Color.White);

            // Options
            spritebatch.DrawString(text, "P for FPS", new Vector2(400, 460), Color.White);
            spritebatch.DrawString(text, "Space for ftl", new Vector2(200, 460), Color.White);
            spritebatch.DrawString(text, "E to interact", new Vector2(200, 436), Color.White);
        }
    }
}
