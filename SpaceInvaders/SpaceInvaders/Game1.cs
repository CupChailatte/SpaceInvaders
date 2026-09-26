using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Managers;
using System.Diagnostics;


namespace SpaceInvaders;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly DisplayManager _display;
    private InputManager _input;
    private EnemyManager _enemyManager;
    private Player _player;
    private SpriteFont _text; //TODO FLYTTA TILL UI MANAGER 
    Vector2 _textPosition; //TODO FLYTTA TILL UI MANAGER 

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _display = new DisplayManager(_graphics, 1080, 1300, false);

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _input = new InputManager();
        Window.Title = "SPACE INVADERS";
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        //--- ENEMY SPRITES --- 
        Texture2D _enemyFastTexture = Content.Load<Texture2D>("EnemySprites/alienFast_01_sprites");
        Texture2D _enemyHeavyTexture = Content.Load<Texture2D>("EnemySprites/alienHeavy_01_sprites");
        Texture2D _enemyMediumTexture = Content.Load<Texture2D>("EnemySprites/alienMedium01_sprites");
        // --- PLAYER SPRITES --- 
        Texture2D _playerSprite = Content.Load<Texture2D>("PlayerSprite/Ship_01-1");
        Texture2D _bulletSprite = Content.Load<Texture2D>("Bullets/bullet_SI");

        // --- TEXT --- //TODO FLYTTA TILL UI MANAGER
        _text = Content.Load<SpriteFont>("Text/TextHealth");
        _textPosition = new Vector2(60, 60);

        // --- ENEMY SPAWN ---
        //_enemy = new Enemy(_enemy03Texture, new Vector2(40,40), 100, 50f, false); //endast en enemy 
        _enemyManager = new EnemyManager(_enemyFastTexture, _enemyMediumTexture, _enemyHeavyTexture);
        _enemyManager.SpawnEnemyFleet(4, 7);


        // --- PLAYER ----

        float startX = (_display.Width / 2f - _playerSprite.Width / 2f);
        float startY = _display.Height - _playerSprite.Height - 20f;
        Vector2 playerStartPosition = new Vector2(startX, startY); // Player startar i mitten botten av skärmen
        _player = new Player(_playerSprite, playerStartPosition, _bulletSprite, _input, _display.Width, 750f, 3);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _input.Update();
        _player.Update(gameTime);
        //_enemy.Update(gameTime);
        _enemyManager.Update(gameTime);


        for (int i = _enemyManager.enemies.Count - 1; i >= 0; i--)
        {

        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        _player.Draw(_spriteBatch);
        string output = $"{_player} POINTS: 0"; // FLYTTA TILL UI MANAGER 
        _spriteBatch.DrawString(_text, output, _textPosition, Color.White, 0, new Vector2(50, 50), 1.0f, SpriteEffects.None, 0.5f); //FLYTTA TILL UI MANAGER 
        //_enemy.Draw(_spriteBatch);
        _enemyManager.Draw(_spriteBatch);
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
