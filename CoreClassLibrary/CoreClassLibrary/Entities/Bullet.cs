using System; 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using CoreClassLibrary.Entities;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace CoreClassLibrary.Entities; 

public class Bullet : Entity 
{
    private float _velocity; 
    private float _damage; 
    private Vector2 _direction; 

    
    public Bullet(Texture2D texture, Vector2 position, float velocity, Vector2 direction,  float damage) : base(texture, position)
    {
        _velocity = velocity; 
        _direction = direction; 
        _damage = damage; 
        
    }
    public override void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds; 
        Position += _direction * _velocity * deltaTime; 

        // Här raderas objekten/bullet bort när dens Y-värde är mer än fönstret. Spara Minne.  
        if (Position.Y <= 0 ||Position.Y < -50)
        {
            IsExpired = true; 
        }
    }
    



}