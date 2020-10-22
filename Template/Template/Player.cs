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
    class Player : Base
    {
        private int direction;
        private bool block = false;

        public Player(Texture2D s, Vector2 p)
        {
            skin = s;
            pos = p;
        }

        /*
         * b = 10
         * * * * * * *
         * * 0 0 * * *
         * * 0 0 1 * *
         * * * * 1 * *
         * * * * * * *
         * * * * * * *
         * 
         * 
         * 
         * 
         * 
         */

        public void Block(int[,] map)
        {
            if (direction == 0)
            {
                for(int i = -4; i < 2; i++)
                {
                    if (map[(int)pos.X / 10 + 1, (int)pos.Y / 10 + i] == 1)
                    {
                        block = true;
                        pos.X--;
                    }
                }
            }
            else if (direction == 1)
            {
                for (int i = -4; i < 2; i++)
                {
                    if (map[(int)pos.X / 10 - 4, (int)pos.Y / 10 + i] == 1)
                    {
                        Console.WriteLine((int)pos.Y / 10);
                        block = true;
                        pos.X++;
                    }
                }
            }
            else if (direction == 2)
            {
                for (int i = -4; i < 2; i++)
                {
                    if (map[(int)pos.X / 10 + i, (int)pos.Y / 10 - 4] == 1)
                    {
                        Console.WriteLine((int)pos.Y / 10);
                        block = true;
                        pos.Y++;
                    }
                }

            }
            else if (direction == 3)
            {
                for (int i = -1; i < 5; i++)
                {
                    if (map[(int)pos.X / 10 - i, (int)pos.Y / 10 + 1] == 1)
                    {
                        Console.WriteLine((int)pos.Y / 10);
                        block = true;
                        pos.Y--;
                    }
                }

            }
            else { block = false; }
        }

        public void Update()
        {
            Console.WriteLine(pos.X + " " + pos.Y);
            Console.WriteLine(block);
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Right))
            {
                if (!block)
                {
                    if (pos.X < 790)
                    {
                        pos.X += 1;
                        direction = 0;
                    }
                }
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                if (!block)
                {
                    if (pos.X > 11)
                    {
                        pos.X -= 1;
                        direction = 1;
                    }
                }
            }
            if (kstate.IsKeyDown(Keys.Up))
            {
                if (!block)
                {
                    if (pos.Y > 11)
                    {
                        pos.Y -= 1;
                        direction = 2;
                    }
                }
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                if (!block)
                {
                    if (pos.Y < 470)
                    {
                        pos.Y += 1;
                        direction = 3;
                    }
                }
            }
            block = false;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            Rectangle rec = new Rectangle(pos.ToPoint(), new Point(10, 10));
            spritebatch.Draw(skin, rec, Color.White);
        }
    }
}
