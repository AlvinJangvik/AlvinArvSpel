using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace space_test
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private int game = 2; // 2 = meny; 1 = spelet; 0 = game over

        private bool show_fps = false; // alla fps variabler
        private double test;
        private double temp = 1;
        private double fps;
        private double fpsS;

        Laser laser;
        Star stars;
        PlayerShip player;
        HealthBar health;
        SpriteFont Alvin;
        Controlls controll;
        Enemy enemy;
        Events events;
        Internet internet;
        CardShower cards;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            End.SetQ();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            stars = new Star(Content.Load<Texture2D>("WhiteP"), new Vector2(150, 150));
            laser = new Laser(Content.Load<Texture2D>("WhiteP"), new Vector2(-100, 900));
            internet = new Internet(Content.Load<Texture2D>("WhiteP"), Content.Load<SpriteFont>("Controll"),new Vector2(20, 20));
            health = new HealthBar(Content.Load<Texture2D>("LongWhite"), Content.Load<Texture2D>("HealthBar"), new Vector2(10, 460), Content.Load<SpriteFont>("Controll"));
            player = new PlayerShip(Content.Load<Texture2D>("SapceShip"), new Vector2(100, 150));
            events = new Events(Content.Load<Texture2D>("SpaceStation"), Content.Load<Texture2D>("Planet"), new Vector2(600, 380), Content.Load<SpriteFont>("Controll"));
            enemy = new Enemy(Content.Load<Texture2D>("LucasShip"), new Vector2(600, 380));
            Alvin = Content.Load<SpriteFont>("Controll");
            controll = new Controlls(Content.Load<SpriteFont>("Controll"));
            cards = new CardShower(Content.Load<Texture2D>("CardBase"), Content.Load<SpriteFont>("Controll"), new Vector2(10, 10));

            cards.LoadFigures(Content.Load<Texture2D>("GreenSlime"), Content.Load<Texture2D>("Snake"));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(health.Health < 1) { game = 0; }

            fps++;
            controll.Update(ref show_fps, ref game);

            if (game == 1)
            {
                internet.Update();
                if (Internet.Active == false)
                {
                    Turns.Update();
                    if (Events.Status == 1)
                    {
                        enemy.Update();
                    }
                    events.Update();
                    laser.Update();
                    player.Update();
                }
            }


            stars.Update();

            test = gameTime.TotalGameTime.TotalSeconds;
            if(test >= temp) { fpsS = fps;  test --; temp++; fps = 0; }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            /*_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();*/

            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            stars.Draw(_spriteBatch);

            if(game == 2)
            {
                _spriteBatch.DrawString(Alvin, "Press A to start", new Vector2(GraphicsDevice.Viewport.Width / 2 - 90, 220), Color.White);
            }
            else if (game == 1)
            {
                laser.Draw(_spriteBatch);
                player.Draw(_spriteBatch);
                if (Star.Star_speed == 1)
                {
                    events.Draw(_spriteBatch);
                    if (Events.Status == 1)
                    {
                        enemy.Draw(_spriteBatch);
                    }
                    health.Draw(_spriteBatch);
                    controll.Draw(_spriteBatch);
                    internet.Draw(_spriteBatch);
                }
            }
            else
            {
                _spriteBatch.DrawString(Alvin, End.Qoute(), new Vector2(GraphicsDevice.Viewport.Width / 2 - End.Qoute().Length * 4, 220), Color.White);
                _spriteBatch.DrawString(Alvin, "Score: " + Controlls.Score, new Vector2(GraphicsDevice.Viewport.Width / 2 - (20 + Controlls.Score / 10), 200), Color.White);
            }
            if (show_fps)
            {
                _spriteBatch.DrawString(Alvin, fpsS.ToString("fps 0"), new Vector2(5, 5), Color.White);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
