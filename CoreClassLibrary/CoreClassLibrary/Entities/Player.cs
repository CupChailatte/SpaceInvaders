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


    public Player(Texture2D texture, Vector2 position, InputManager inputManager,int windowWidth, float speed)
    : base(texture, position)
    {
        _input = inputManager;
        _windowWidth = windowWidth; 
        _speed = speed;
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
        if (_input.IsKeyPressed(Keys.Space) || _input.IsLeftClick())
        {
            
        }

        // --- HÅLLER SPELARE INNANFÖR FÖNSTRET --- 
        Position.X = MathHelper.Clamp(Position.X, 0, _windowWidth - Texture.Width);


    }

}
