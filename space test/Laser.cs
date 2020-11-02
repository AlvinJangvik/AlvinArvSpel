using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace space_test
{
    class Laser : VisualBase
    {
        private static int laserMoving = 0; // 0 = not moving
        private static int last_move = 0;
        private static int target = 1; // 1 = player, 2 = enemy
        private static int stop = 359;
        private static float dmg = 20;
        private static Vector2 cords;

        public Laser(Texture2D tex, Vector2 p)
        {
            skin = tex;
            cords = p;
            
        }

        public static void shoot(float d)
        {
            dmg = d;
            target = 1;
            cords = new Vector2(650, 420);
            laserMoving = 2;
        }

        public static void Eshoot(float d)
        {
            dmg = d;
            target = 2;
            cords = new Vector2(560, 280);
            laserMoving = 2;
        }

        public static int LaserMoving
        {
            get { return laserMoving; }
        }

        public void Update()
        {
            if (Star.Star_speed == 1)
            {
                if (target == 1) // player ship
                {
                    stop = 400;
                }
                else // enemy
                {
                    stop = 630;
                }

                // åker höger
                if (laserMoving == 2)
                {
                    if (cords.X < 821)
                    {
                        cords.X += 15;
                    }
                    else
                    {
                        if (target == 1)
                        {
                            cords.Y = 270; // Y mot spelar skäpp
                        }
                        else
                        {
                            cords.Y = 400; // y mot fiende skäpp
                        }
                        laserMoving = 1;
                    }
                }

                if (LaserMoving == 1) // åker vänster
                {
                    if (cords.X > stop)
                    {
                        cords.X -= 15;
                    }
                    else
                    {
                        laserMoving = 0;
                    }
                }

                // DAMAGE CHECK
                if (last_move == 1 && laserMoving == 0 && target == 1)
                {
                    HealthBar.Loss(dmg);
                }
                else if (last_move == 1 && laserMoving == 0 && target == 2)
                {
                    HealthBar.ELoss(dmg);
                }

                last_move = laserMoving;
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
            if (laserMoving != 0)
            {
                spritebatch.Draw(skin, new Rectangle((int)cords.X, (int)cords.Y, 50, 3), Color.Red);
            }
        }
    }
}
