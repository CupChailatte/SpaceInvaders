using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Managers; 
using System.Reflection.Metadata;


namespace SpaceInvaders;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly DisplayManager _display; 
    private InputManager _input; 
    private Player _player; 
    private Enemy _enemy; 

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _display = new DisplayManager(_graphics, 720, 1080, false); 

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _input = new InputManager(); 
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        Texture2D _enemy03Texture = Content.Load<Texture2D>("EnemySprites/alien03_01_sprites"); 

        // --- ENEMY ---
        _enemy = new Enemy(_enemy03Texture, new Vector2(40,40), 100, 50f, false); 

        // --- PLAYER ----
        Texture2D _playerSprite = Content.Load<Texture2D>("PlayerSprite/Ship_01-1"); 
        Texture2D _bulletSprite = Content.Load<Texture2D>("Bullets/bullet_SI"); 
        float startX =(_display.Width /2f - _playerSprite.Width /2f); 
        float startY = _display.Height  - _playerSprite.Height - 20f; 
        Vector2 playerStartPosition = new Vector2(startX, startY); // Player startar i mitten botten av skärmen
        _player = new Player(_playerSprite, playerStartPosition,_bulletSprite,_input, _display.Width, 750f); 
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _input.Update(); 
        _player.Update(gameTime); 
        _enemy.Update(gameTime); 

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin(); 
        _player.Draw(_spriteBatch); 
        _enemy.Draw(_spriteBatch);
        _spriteBatch.End(); 
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
