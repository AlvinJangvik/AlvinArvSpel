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
    class Map : Base
    {
        private int[,] map;
        public const int PADDING = 10; // i pixlar
        /* x*posimap+padding*posimap
         * * *
         ***
         ***
         */

        public Map(int width, int height, Texture2D tex)
        {
            skin = tex;
            map = new int[width, height];
            pos.X = width;
            pos.Y = height;
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
             
             for (int i = (int)pos.Y - 1; i >= 0; i--)
             {
                
                 for (int o = (int)pos.X - 1; o >= 0; o--)
                 {
                     if (map[i, o] == 1)
                     {
                         spritebatch.Draw(skin, new Rectangle(o * 10, i * 10, 50, 50), Color.Black);
                     }
                 }
             }
        }
    }
}
