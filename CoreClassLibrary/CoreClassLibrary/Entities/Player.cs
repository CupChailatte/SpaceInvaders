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
    private int _windowWidth; 
    private BulletManager _bulletManager; 


    public Player(Texture2D texture, Vector2 position,Texture2D bulletTexture ,InputManager inputManager,int windowWidth, float speed)
    : base(texture, position)
    {
        _input = inputManager;
        _windowWidth = windowWidth; 
        _speed = speed;
        _bulletManager = new BulletManager(bulletTexture); 

    }

    public override void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_input.IsKeyDown(Keys.Left) || _input.IsKeyDown(Keys.A))
        {
            Position.X -= _speed * deltaTime;
        }
        if (_input.IsKeyDown(Keys.Right)|| _input.IsKeyDown(Keys.D))
        {
            Position.X += _speed * deltaTime; 
        }
        // --- SKJUTA --- 
        if (_input.IsKeyPressed(Keys.Space) || _input.IsLeftClick())
        {
            // Start positon för bullet spawn, vi vill att bullet ska komma fram vid playerSprite. 
            Vector2 bulletOrigin = new Vector2(Position.X + (Texture.Width /2 ), Position.Y); 
            // --- SHOOT Egenskaper - origin, velocity, direction och damage 
            _bulletManager.Shoot(bulletOrigin, 1000f, new Vector2(0,-1), 10 ); 

        }
        _bulletManager.Update(gameTime); 

        // --- HÅLLER SPELARE INNANFÖR FÖNSTRET --- 
        Position.X = MathHelper.Clamp(Position.X, 0, _windowWidth - Texture.Width);

    }
     public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
        _bulletManager.Draw(spriteBatch);

        ///--- Ritar ut texten - färg, typsnit, sträng och position
    }

}
