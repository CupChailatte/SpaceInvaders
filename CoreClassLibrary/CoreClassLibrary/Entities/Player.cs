using System; 
using System.Collections.Generic; 
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using CoreClassLibrary.Entities;

namespace CoreClassLibrary.Entities; 

    public class Player : Entity
    {
        private float _speed = 400f; 
        private float _fireRate;

        public Player(Texture2D texture, Vector2 position,  float speed) :base(texture, position)
        {
            _speed = speed; 
        }

        public override void Update(GameTime gameTime)
        {
            
        }
        
    }
