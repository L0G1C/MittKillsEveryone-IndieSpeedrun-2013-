using MitKillsEveryone.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone.Entities
{
    public class Background
    {
        public string FileName { get; set; }
        public Background ExitLeft { get; set; }
        public Background ExitRight { get; set; }
        public Background ExitUp { get; set; }
        public Background ExitDown { get; set; }
        protected ContentManager Content { get; set; }
        protected SoundManager SoundManager { get; set; }
        public ItemManager iM;
        public string OutputText { get; set; }
        public KeyboardState keyboardState { get; set; }
        public int XSpawnPosition { get; set; }
        protected Picture picture;

        private Vector2 position;
        private Texture2D texture;
        private Texture2D itemBar;
        private Texture2D portrait1;
        private Texture2D portrait1dead;
        private Texture2D portrait2;
        private Texture2D portrait2dead;
        private Texture2D portrait3;
        private Texture2D portrait3dead;
        private Texture2D portrait4;
        private Texture2D portrait4dead;
        private SpriteFont font;
        private Texture2D knifeItem;
        private Texture2D gunItem;
        private Texture2D wrenchItem;
        private Texture2D keyItem;
        private Texture2D grenadeItem;
        private Texture2D swordItem;

        public Background()
        {
            iM = new ItemManager(Content);
        }

        public void LoadTexture(ContentManager Content, SoundManager sound ,string fileName, int storyCount)
        {
            position = new Vector2();
            texture = Content.Load<Texture2D>(@"gfx/backgrounds/" + fileName);
            itemBar = Content.Load<Texture2D>(@"gfx/hud/ItemBar");
            portrait1 = Content.Load<Texture2D>(@"gfx/hud/Portrait1");
            portrait1dead = Content.Load<Texture2D>(@"gfx/hud/Portrait1Dead");
            portrait2 = Content.Load<Texture2D>(@"gfx/hud/Portrait2");
            portrait2dead = Content.Load<Texture2D>(@"gfx/hud/Portrait2Dead");
            portrait3 = Content.Load<Texture2D>(@"gfx/hud/Portrait3");
            portrait3dead = Content.Load<Texture2D>(@"gfx/hud/Portrait3Dead");
            portrait4 = Content.Load<Texture2D>(@"gfx/hud/Portrait4");
            portrait4dead = Content.Load<Texture2D>(@"gfx/hud/Portrait4Dead");
            knifeItem = Content.Load<Texture2D>(@"gfx/items/knife");
            gunItem = Content.Load<Texture2D>(@"gfx/items/gun");
            font = Content.Load<SpriteFont>("MessageFont");
            keyItem = Content.Load<Texture2D>(@"gfx/items/key");
            wrenchItem = Content.Load<Texture2D>(@"gfx/items/wrench");
            grenadeItem = Content.Load<Texture2D>(@"gfx/items/grenade");
            swordItem = Content.Load<Texture2D>(@"gfx/items/sword");

            this.Content = Content;
            this.SoundManager = sound;
            LoadBackgrounds(storyCount);
        }

        virtual public void LoadBackgrounds(int storyCount)
        {

        }

        public void Update(GameTime gameTime, int storyCount)
        {
            OutputText = string.Empty;
            keyboardState = Keyboard.GetState();
            if(storyCount == 10)
                picture.Update(gameTime);
        }

        virtual public void CheckCollisions(GameTime gameTime, Player player, ref int storyCount)
        {

        }

        virtual public void Draw(SpriteBatch spriteBatch, int storyCount)
        {
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.Draw(itemBar, position, Color.White);

            if (storyCount < 2)
            {
                spriteBatch.Draw(portrait1, new Rectangle(10, 20, portrait1.Width, portrait1.Height), Color.White);
            }
            else
            {
                spriteBatch.Draw(portrait1dead, new Rectangle(10, 20, portrait1dead.Width, portrait1dead.Height), Color.White);
            }
            if (storyCount < 4)
            {
                spriteBatch.Draw(portrait2, new Rectangle(66, 20, portrait2.Width, portrait2.Height), Color.White);
            }
            else
            {
                spriteBatch.Draw(portrait2dead, new Rectangle(66, 20, portrait2dead.Width, portrait2dead.Height), Color.White);
            }

            if (storyCount < 8)
            {
                spriteBatch.Draw(portrait3, new Rectangle(122, 20, portrait3.Width, portrait3.Height), Color.White);
            }
            else
            {
                spriteBatch.Draw(portrait3dead, new Rectangle(122, 20, portrait3dead.Width, portrait3dead.Height), Color.White);
            }
            if (storyCount < 10)
            {
                spriteBatch.Draw(portrait4, new Rectangle(178, 20, portrait4.Width, portrait4.Height), Color.White);
            }
            else
            {
                spriteBatch.Draw(portrait4dead, new Rectangle(178, 20, portrait4dead.Width, portrait4dead.Height), Color.White);
            }

            if (!string.IsNullOrEmpty(OutputText))
            {
                Vector2 FontOrigin = font.MeasureString(OutputText) / 2;
                spriteBatch.DrawString(font, OutputText, new Vector2(700, 50), Color.White, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
            }

            if (storyCount == 1)
            {
                spriteBatch.Draw(knifeItem, new Rectangle(240, 30, 50, 50), Color.White);
            }

            if (storyCount == 3)
            {
                spriteBatch.Draw(gunItem, new Rectangle(240, 30, 50, 50), Color.White);
            }
            if (storyCount >= 5)
            {
                spriteBatch.Draw(wrenchItem, new Rectangle(240, 30, 50, 50), Color.White);
            }
            if (storyCount >= 6)
            {
                spriteBatch.Draw(keyItem, new Rectangle(270, 30, 50, 50), Color.White);
            }
            if (storyCount == 7)
            {
                spriteBatch.Draw(grenadeItem, new Rectangle(315, 30, 50, 50), Color.White);
            }
            if (storyCount == 9)
            {
                spriteBatch.Draw(swordItem, new Rectangle(315, 30, 50, 50), Color.White);
            }

            iM.Draw(spriteBatch);
        }
    }
}
