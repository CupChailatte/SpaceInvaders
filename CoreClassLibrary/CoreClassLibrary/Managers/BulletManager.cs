using System;
using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using CoreClassLibrary.Entities; 

namespace CoreClassLibrary.Mangers;

public class BulletManager
{
    List<Bullet> _activeBulletList; 
    private Texture2D _bulletTexture; 
    
    public BulletManager(Texture2D texture)
    {
        _activeBulletList = new List<Bullet>();
    }

    // --- SHOOT --- 
    public void Shoot(Vector2 startPosition, float velocity, float direction, float damage)
    {
        Bullet newBullet = new Bullet(_bulletTexture, startPosition, velocity, direction, damage); 
        _activeBulletList.Add(newBullet); 
    }

    public void Update(float deltaTime)
    {
        for (int i = _activeBulletList.Count - 1; i >= 0; i--)
        {
            _activeBulletList[i].Update(deltaTime);
            if (_activeBulletList[i].IsExpired)
            {
                _activeBulletList.RemoveAt(i); 
            }
        }
    }
}