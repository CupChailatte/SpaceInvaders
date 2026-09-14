using System;
using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using CoreClassLibrary.Entities;
using System.Drawing;

namespace CoreClassLibrary.Managers;

public class BulletManager
{
    private List<Bullet> _activeBulletList; // Lista för nya bullet objekt som ska in till Listan, när spelaren skjuter
    private Texture2D _bulletTexture; 
    
    public BulletManager(Texture2D texture)
    {
        _activeBulletList = new List<Bullet>(); //Init. 
        _bulletTexture =texture; 
    }

    // --- SHOOT --- 
    public void Shoot(Vector2 startPosition, float velocity, Vector2 direction, float damage)
    {
        Bullet newBullet = new Bullet(_bulletTexture, startPosition, velocity, direction, damage); 
        _activeBulletList.Add(newBullet); // Lägger in nya Bullets till Listan. 
    }

    public void Update(GameTime gameTime)
    {
        for (int i = _activeBulletList.Count - 1; i >= 0; i--)
        {
            _activeBulletList[i].Update(gameTime);
            if (_activeBulletList[i].IsExpired) 
            {
                _activeBulletList.RemoveAt(i); 
                System.Diagnostics.Debug.WriteLine("Ett skott raderades ur listan!");
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var bullet in _activeBulletList)
        {
            bullet.Draw(spriteBatch); 
        }
    }
}