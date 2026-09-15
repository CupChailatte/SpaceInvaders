
using System; 
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CoreClassLibrary.Entities;


namespace CoreClassLibrary.Managers; 

public class EnemyManager
{
    private List<Enemy> _enemyList; 
    private Texture2D _fastEnemy; 
    private Texture2D _heavyEnemy; 

    public EnemyManager(Texture2D fastEnemy, Texture2D heavyEnemy)
    {
        _fastEnemy = fastEnemy; 
        _heavyEnemy = heavyEnemy; 
        _enemyList = new List<Enemy>(); 
    }

    //---METOD FÖR ATT SPAWNA ENEMIES--- 
    // Jag vill kunna kontrollera column och row av enemy, så metoden tar emot två argument col och row
    public void SpawnEnemyFleet(int row, int column)
    {
        //start position 
        float startX = 60f;
        float startY = 50f; 
        //Spacing mellan enemies
        float spacingX = 150f; 
        float spacingY = 100f; 

        for (int r = 0; r < row; r++)
        {
            for(int c = 0; c < column; c++)
            {
                Vector2 spawnPosition = new Vector2(startX + (c * spacingX), startY + (r *spacingY)); 

                if(r < 2)
                {
                    _enemyList.Add(new HeavyEnemy(_heavyEnemy, spawnPosition, 200, 5f, false));
                }
                else
                {
                    _enemyList.Add(new FastEnemy(_fastEnemy, spawnPosition, 50, 10f, false)); 
                }
                /*
                float x = startX + (c * spacingX); 
                float y = startY + (r * spacingY); 

                Vector2 spawnPosition = new Vector2(x,y); 
                _enemyList.Add(new Enemy(_texture, spawnPosition, 100, 10f, false)); 
                */
            }
        }

    }

    /* //! Kommer att crasha programmet med "InvalidOperationException" on en enemy objekt dör och tar bort sig själv
    public void Update(GameTime gameTime)
    {
        foreach (var enemy in _enemyList)
        {
            enemy.Update(gameTime); 
        }
        
    }
    */

    //* Backwards loop för att ta bort enemies utan att programmet crashar. 
    public void Update(GameTime gameTime)
    {
        for (int i = _enemyList.Count - 1; i >= 0; i--)
        {
            _enemyList[i].Update(gameTime); 

         // Example: Remove dead enemies safely
        // if (_enemyList[i].IsDead) 
        // {
        //     _enemyList.RemoveAt(i);
        // }
        }
    }



    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var enemy in _enemyList)
        {
            enemy.Draw(spriteBatch); 
        }
    }
}