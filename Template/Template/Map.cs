using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Map
    {
        private Texture2D house;
        private int[,] map;
        private int x;
        private int y;
        public const int PADDING = 10; // i pixlar
        /* x*posimap+padding*posimap
         * * *
         ***
         ***
         */

        public Map(int width, int height, Texture2D skin)
        {
            house = skin;
            map = new int[width, height];
            x = width;
            y = height;
        }

        public int[,] Get
        {
            get { return map; }
        }

        public void Creat()
        {
            for (int i = 5; i>=0; i--)
            {
                for(int o = 20; o >= 0; o--)
                {
                    map[o, i] = 0;
                }
            }

            for (int i = 10; i >= 0; i--)
            {
                for (int o = 20; o >= 0; o--)
                {
                    map[PADDING * o + o,i + PADDING * i] = 1;
                }
            }
        }



        public void Draw(SpriteBatch spritebatch)
        {
             
             for (int i = y - 1; i >= 0; i--)
             {
                
                 for (int o = x - 1; o >= 0; o--)
                 {
                     if (map[i, o] == 1)
                     {
                         spritebatch.Draw(house, new Rectangle(o * 10, i * 10, 50, 50), Color.Black);
                     }
                 }
             }
        }
    }
}
