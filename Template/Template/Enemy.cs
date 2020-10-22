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
    class Enemy : Base
    {

        public Enemy(Texture2D tex, Vector2 position)
        {
            skin = tex;
            pos = position;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            Rectangle rec = new Rectangle(pos.ToPoint(), new Point(10, 10));
            spritebatch.Draw(skin, rec, Color.Red);
        }
    }
}
