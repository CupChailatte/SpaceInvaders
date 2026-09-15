using System;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using CoreClassLibrary.Entities;

namespace CoreClassLibrary.Entities; 

public class Enemy : Entity
{
    //Unik data 
    private int _health; 
    private float _speed; 
    private bool _canShoot; 
    
    public Enemy(Texture2D texture, Vector2 position, int hp, float speed, bool canShoot) : base(texture, position)
    {
        _health = hp; 
        _speed = speed; 
        _canShoot = canShoot; 
    }

    public override void Update(GameTime gameTime)
    {
      
      // !Position = new Vector2(Position.X, Position.Y + _speed);  Misstag! 
      // Lägger _speed direkt på Y-pos varje frame,
      //  om man har en skärm med högre refresh rate då kommer spelets hasighet köras olika på olika skärmar. 

        //* Enemy Rörs sig neråt. (fixad version)
      base.Update(gameTime);  //Anropa basklassens Update() för att uppdatera DeltaTime; Om inte, annars händer inget! 
      Position = new Vector2(Position.X, Position.Y + (_speed * DeltaTime)); 
    }

    //* Override basmetoden för draw, nu är min sprite röd. 
    //* Jag kommer ihåg att om jag inte behöver ändra något i Draw, behöver jag inte ens skriva en draw metod i under klassen
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.Red); 
    }


  
}