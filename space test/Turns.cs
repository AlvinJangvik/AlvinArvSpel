using System;
using System.Collections.Generic;
using System.Text;

namespace space_test
{
    class Turns
    {
        private static int turn = 1; // 1 = player turn; 2 = enemy turn;
        private static int atc = 0; // if enemy has attacked
        private static int last_move = 0;

        private static int random(int min, int max)
        {
            Random rand = new Random();
            int r;

            return (r = rand.Next(min, max));
        }

        public static int Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        public static void Update()
        {
            if(Laser.LaserMoving == 0 && turn == 2 && HealthBar.EHealth > 0)
            {
                Laser.shoot(random(5 + Events.EnemyDMG / 2 + (Controlls.Dmg / 11), 10 + Events.EnemyDMG + (Controlls.Dmg / 11)));
                atc = 1;
            }
            if(turn == 2 && last_move == 1 && atc == 1)
            {
                turn = 1;
                atc = 0;
            }

            last_move = Laser.LaserMoving;
        }
    }
}
