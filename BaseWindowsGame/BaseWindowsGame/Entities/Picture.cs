using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MitKillsEveryone.Entities
{
    public class Picture : Sprite
    {
        private bool playAnim;
        private float delay = 8.0f;
        private float count = 0;

        public Picture(Texture2D texture, Vector2 position)
            : base(texture, position, new Rectangle((int)position.X, (int)position.Y, 60, 112), 1, 3, 1)
        {
        }

        public override void Update(GameTime gameTime)
        {
            count += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (count > delay)
                base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(count > delay)
                base.Draw(spriteBatch);
        }
    }
}
