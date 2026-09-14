using System; 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using CoreClassLibrary.Entities;
using System.Reflection.Metadata.Ecma335;

namespace CoreClaseLibrary.Entities; 

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
        Position.Y += _direction * _velocity * gameTime; 
    }

}