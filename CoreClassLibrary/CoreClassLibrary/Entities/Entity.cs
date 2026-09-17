using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CoreClassLibrary.Entities;

// --- BAS KLASS FÖR ALLA ENTITIES --- 
public class Entity
{
    // Spatial & Visuel Data 
    public Vector2 Position;
    public Texture2D Texture { get; protected set; }

    //Flaga för att managerna ska veta när objektet ska tas bort ur minnet
    public bool IsExpired { get; set; } = false;

    // Skyddad egenskap så alla underklasser kan läsa det. 
    protected float DeltaTime { get; private set; }


    /// <summary>
    /// Hitbox som räknas ut automatisk baserat på position och bildens storlek
    /// "Virtual" - Polymorphism - Underklasser/Child har tillgång till att ändra 
    /// dess beteende genom att använda "override".  
    /// </summary>
    /// 
    ///
    /*    public virtual Rectangle HitBox
    {
        get
        {
            if (Texture == null)
                return Rectangle.Empty;

                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); 
        }

    }
*/

    // Collision Property på Huvudklassen.
    public virtual Rectangle Bounds => new Rectangle(
    (int)Position.X,
    (int)Position.Y,
    Texture.Width,
    Texture.Height);




    public Entity(Texture2D texture, Vector2 position)
    {
        Texture = texture;
        Position = position;

    }

    // Virtual - Andra objekt kan använda "override" metoden med sin egen logik 
    public virtual void Update(GameTime gameTime)
    {
        //Grundlogik/default logik om jag behöver det.
        DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    // Om texturen av objekten och objekten är inte expired ska den renderas
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        if (Texture != null && !IsExpired)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }

}