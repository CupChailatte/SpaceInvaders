using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CoreClassLibrary.Entities;
using CoreClassLibrary.Managers;

namespace CoreClassLibrary.Entities;

public class Player : Entity
{
    private float _speed = 400f;
    //  private float _fireRate;
    private InputManager _input;
<<<<<<< HEAD
    private int _windowWidth;
    private BulletManager _bulletManager;
    private int _health = 3;


    public Player(Texture2D texture, Vector2 position, Texture2D bulletTexture
     , InputManager inputManager, int windowWidth, float speed, int health)
=======
    private int _windowWidth; 
    private BulletManager _bulletManager; 
    public int Health; 


    public Player(Texture2D texture, Vector2 position,Texture2D bulletTexture ,InputManager inputManager,int windowWidth, float speed, int health)
>>>>>>> 3f595c1bb89844ad92e6269ca976ead6a89ca9ab
    : base(texture, position)
    {
        _input = inputManager;
        _windowWidth = windowWidth;
        _bulletManager = new BulletManager(bulletTexture);
        _speed = speed;
<<<<<<< HEAD
        _health = health;
=======
        _bulletManager = new BulletManager(bulletTexture); 
        Health = health; 
>>>>>>> 3f595c1bb89844ad92e6269ca976ead6a89ca9ab

    }

    public override void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_input.IsKeyDown(Keys.Left) || _input.IsKeyDown(Keys.A))
        {
            Position.X -= _speed * deltaTime;
        }
        if (_input.IsKeyDown(Keys.Right) || _input.IsKeyDown(Keys.D))
        {
            Position.X += _speed * deltaTime;
        }
        // --- SKJUTA --- 
        if (_input.IsKeyPressed(Keys.Space) || _input.IsLeftClick())
        {
            // Start positon för bullet spawn, vi vill att bullet ska komma fram vid playerSprite. 
            Vector2 bulletOrigin = new Vector2(Position.X + (Texture.Width / 2), Position.Y);
            // --- SHOOT Egenskaper - origin, velocity, direction och damage 
            _bulletManager.Shoot(bulletOrigin, 1000f, new Vector2(0, -3), 10);

        }
<<<<<<< HEAD
        _bulletManager.Update(gameTime);
=======


        
        _bulletManager.Update(gameTime); 
>>>>>>> 3f595c1bb89844ad92e6269ca976ead6a89ca9ab

        // --- HÅLLER SPELARE INNANFÖR FÖNSTRET --- 
        Position.X = MathHelper.Clamp(Position.X, 0, _windowWidth - Texture.Width);

    }

<<<<<<< HEAD
    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health < 0) _health = 0;

    }


    public override void Draw(SpriteBatch spriteBatch) //* Override basklassens Draw()
=======
    public void TakeDamage(int damage)
    {
        Health -= damage; 
        if(Health <= 0)
        {
            Health = 0;  // health inte går under 0. 
        }
        
    }


     public override void Draw(SpriteBatch spriteBatch) //* Override basklassens Draw()
>>>>>>> 3f595c1bb89844ad92e6269ca976ead6a89ca9ab
    {
        spriteBatch.Draw(Texture, Position, Color.White);
        _bulletManager.Draw(spriteBatch);

        ///--- Ritar ut texten - färg, typsnit, sträng och position
    }

}
