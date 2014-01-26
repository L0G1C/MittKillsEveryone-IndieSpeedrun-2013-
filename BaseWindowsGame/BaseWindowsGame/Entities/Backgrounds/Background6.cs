using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MitKillsEveryone.Constant;

namespace MitKillsEveryone.Entities.Backgrounds
{
    /// <summary>
    /// Freezer
    /// </summary>
    public class Background6 : Background
    {
        private Item dude4;        

        public Background6()
        {
            FileName = "background6";
        }

        override public void LoadBackgrounds(int storyCount)
        {
            if (storyCount < 10)
            {
                dude4 = new Item(Content.Load<Texture2D>(@"gfx/dudes/dude4"), new Vector2(180, 300));
            }
            else
            {
                dude4 = new Item(Content.Load<Texture2D>(@"gfx/dudes/dude4dead"), new Vector2(180, 320)); 
                
            }
            iM.Items.Add(dude4);

            
            //ExitRight = new Background4();
        }

        public override void CheckCollisions(GameTime gameTime, Player player, ref int storyCount)
        {
            if (iM.Items.Contains(dude4) && dude4.BoundingBox.Intersects(player.BoundingBox))
            {
                if (storyCount == 9)
                {
                    OutputText = "[SPACE] to thrust samurai sword through " + Constants.Dude4Name;
                    if (keyboardState.IsKeyDown(Keys.Space))
                    {
                        //Voicework and scene here?
                        SoundManager.PlayDeath4();
                        dude4.Texture = Content.Load<Texture2D>(@"gfx/Dudes/dude4dead");
                        picture = new Picture(Content.Load<Texture2D>(@"gfx/dudes/picture-floating"), new Vector2(170, 350));
                        storyCount++;
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, int storyCount)
        {

            base.Draw(spriteBatch, storyCount);

            if (storyCount == 10)
               picture.Draw(spriteBatch);
        }
    }
}
