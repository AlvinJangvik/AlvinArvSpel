using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace space_test
{
    class VisualBase
    {
        protected Texture2D skin;
        protected Vector2 pos;

        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(skin, pos, new Rectangle(new Point(10), new Point(10)), Color.White);
        }

    }
}
