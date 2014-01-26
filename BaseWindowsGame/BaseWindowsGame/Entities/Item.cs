using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MitKillsEveryone.Entities.Backgrounds
{
    public class Item : Sprite
    {
        private Texture2D texture;
        private Vector2 position;

        /// <summary>
        /// Adding a 2 parameter constructor for items since we don't care about movement bounds
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        public Item(Texture2D texture, Vector2 position)
            : this(texture, position, new Rectangle(0, 0, texture.Width, texture.Height))
        {
        }

        public Item(Texture2D texture, Vector2 position, Rectangle movementBounds) : base(texture, position, movementBounds)
        {
            this.texture = texture;
            this.position = position;
        }

        
    }
}
