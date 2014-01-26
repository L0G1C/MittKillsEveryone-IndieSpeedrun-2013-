using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.Entities.Backgrounds
{
    public class Background5 : Background
    {
        /// <summary>
        /// Attic
        /// </summary>
        private Item bathroomKey;

        public Background5()
        {
            FileName = "background5";
            
        }

        override public void LoadBackgrounds(int storyCount)
        {
            if (storyCount < 6)
            {
                bathroomKey = new Item(Content.Load<Texture2D>(@"gfx/items/key"), new Vector2(80, 320));
                iM.Items.Add(bathroomKey);
            }

            ExitDown = new Background4();
        }

        public override void CheckCollisions(GameTime gameTime, Player player, ref int storyCount)
        {
            if (iM.Items.Contains(bathroomKey) && bathroomKey.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount < 6)
                {
                    OutputText = "There is old key lying on the ground here\r\n[SPACE] to pick it up";
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        storyCount++;
                        iM.Items.Remove(bathroomKey);
                    }
                }
            }
        }

    }
}
