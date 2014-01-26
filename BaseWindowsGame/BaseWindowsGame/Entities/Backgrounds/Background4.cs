using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MitKillsEveryone.Managers;
using Microsoft.Xna.Framework.Input;
using MitKillsEveryone.Constant;

namespace MitKillsEveryone.Entities.Backgrounds
{
    public class Background4 : Background
    {
        /// <summary>
        /// Break Room
        /// </summary>
        private Item watercooler;
        private Item vent;
        private Item freezerDoor;
        private Item guninWater;
        
        public Background4()
        {
            FileName = "background4";
            XSpawnPosition = 280;
        }

        override public void LoadBackgrounds(int storyCount)
        {
            watercooler = new Item(Content.Load<Texture2D>(@"gfx/items/watercooler"), new Vector2(680, 180));
            iM.Items.Add(watercooler);
            vent = new Item(Content.Load<Texture2D>(@"gfx/items/nothing"), new Vector2(280, 180));
            iM.Items.Add(vent);
            freezerDoor = new Item(Content.Load<Texture2D>(@"gfx/items/nothing"), new Vector2(20, 300));
            iM.Items.Add(freezerDoor);


            if (storyCount < 3)
            {
                guninWater = new Item(Content.Load<Texture2D>(@"gfx/items/guninwater"), new Vector2(750, 180));
                iM.Items.Add(guninWater);
            }

            ExitRight = new Background1();
            if (storyCount == 9)
            {
                ExitLeft = new Background6();
            }
            else
            {
                ExitLeft = null;
            }
            ExitUp = null;
        }

        public override void CheckCollisions(GameTime gameTime, Player player, ref int storyCount)
        {
            if (iM.Items.Contains(watercooler) && watercooler.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount == 2)
                {
                    OutputText = "There is a watercooler here.. Hey.. is there something hidden behind it?\r\n[SPACE] to search";
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        storyCount++;
                        iM.Items.Remove(guninWater);
                    }
                }
                else
                {
                    OutputText = "There is a watercooler here that dispenses cold refreshing water\r\nfor the employees of pizza shack";
                }
            }
            else if (iM.Items.Contains(vent) && vent.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount < 5)
                {
                    OutputText = "There is an air vent here\r\nIf you had a wrench, you might be able to\r\npry off the cover and crawl inside";
                }
                else
                {
                    ExitUp = new Background5();
                    OutputText = "[SPACE] to crawl inside air vent";
                }
            }
            else if (iM.Items.Contains(freezerDoor) && freezerDoor.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount < 9)
                {
                    OutputText = "This is the door to the freezer room\r\nbut somebody has placed a large lock on the door\r\nIf you had something very sharp, you\r\nmight be able to slice off the lock";
                }
                else
                {
                    OutputText = "You can slice off the lock with\r\nyour samurai sword";
                }
            }
        }
    }
}
