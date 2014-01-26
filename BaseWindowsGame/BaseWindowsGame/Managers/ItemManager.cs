using System.Collections.Generic;
using MitKillsEveryone.Entities.Backgrounds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MitKillsEveryone.Managers
{
    public class ItemManager
    {
        private List<Item> items = new List<Item>(); 

        public IList<Item> Items {
            get { return items; }            
        } 
        public ItemManager(ContentManager content)
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in Items)
            {
                spriteBatch.Draw(item.Texture, item.Position, Color.White);    
            }
            
        }
    }
}
