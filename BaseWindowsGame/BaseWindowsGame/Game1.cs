using MitKillsEveryone.Entities;
using MitKillsEveryone.Entities.Backgrounds;
using MitKillsEveryone.Managers;
using MitKillsEveryone.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MitKillsEveryone
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public GameState GameState;  

        //TEXTURES
        private Texture2D playerSprite;

        //ENTITIES
        public Player player;
        public Background background;
        private SpriteFont spriteFont;

        //STATESTUFF
        public Sprite titleScreen;
        public Credits credits;
        public Intro introScreen;
        public bool gameStart { get; set; }
        public KeyboardState keyboardState { get; set; }
        public bool IntroDone { get; set; }

        //MANAGERS
        public SoundManager SoundManager;

        
        public int StoryCount;

        //keyboardstates for switching states
        public KeyboardState currentKeyboardState;
        public KeyboardState previousKeyboardState;
        public bool introStart;
        public bool creditsStart;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this) {PreferredBackBufferWidth = 1024, PreferredBackBufferHeight = 640};
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {            
            GameState = new TitleScreenState(this);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
             StoryCount = 0;            

            //TEXTURE INITS
            playerSprite = Content.Load<Texture2D>(@"gfx/player/player_still_l");
            spriteFont = Content.Load<SpriteFont>(@"MessageFont");
            titleScreen = new Sprite(Content.Load<Texture2D>(@"gfx/TitleScreen"), Vector2.Zero, graphics.GraphicsDevice.Viewport.Bounds);
            introScreen = new Intro(Content.Load<Texture2D>(@"gfx/scenes/introframe1"), Vector2.Zero, graphics.GraphicsDevice.Viewport.Bounds, Content);
            credits = new Credits(Content.Load<Texture2D>(@"gfx/scenes/credits"), new Vector2(390, 100), graphics.GraphicsDevice.Viewport.Bounds, Content);

            //ENTITY INITS
            var playerBounds = new Rectangle(0, graphics.GraphicsDevice.Viewport.Height - 410, graphics.GraphicsDevice.Viewport.Width , 275);
            player = new Player(playerSprite, new Vector2(800, 355.0f), playerBounds, Content);
            
            //MANAGERS
            SoundManager = new SoundManager(Content);
            SoundManager.PlayMenuMusic();

            background = new Background2();
            background.LoadTexture(Content, SoundManager, background.FileName, StoryCount);
          
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //holding previous state for switching states.
            currentKeyboardState = Keyboard.GetState();
            GameState.Update(gameTime);
            previousKeyboardState = currentKeyboardState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            GameState.Draw(spriteBatch);          
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void LoadContentFromCredits()
        {
            this.LoadContent();
        }

    }
}
