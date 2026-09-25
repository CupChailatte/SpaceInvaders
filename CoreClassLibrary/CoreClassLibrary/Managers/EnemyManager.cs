
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CoreClassLibrary.Entities;


namespace CoreClassLibrary.Managers;

public class EnemyManager
{
    private List<Enemy> _enemyList;
    public List<Enemy> enemies => _enemyList; 
    private Texture2D _fastEnemy;
    private Texture2D _heavyEnemy;
    private Texture2D _mediumEnemy;

    public EnemyManager(Texture2D fastEnemy, Texture2D mediumEnemy, Texture2D heavyEnemy)
    {
        _fastEnemy = fastEnemy;
        _mediumEnemy = mediumEnemy;
        _heavyEnemy = heavyEnemy;
        _enemyList = new List<Enemy>();
    }

    //---METOD FÖR ATT SPAWNA ENEMIES--- 
    // Jag vill kunna kontrollera column och row av enemy, så metoden tar emot två argument col och row
    public void SpawnEnemyFleet(int row, int column)
    {
        //start position 
        // //! HARDKODAT - TODO: Måste hitta ett annat sätt att positonera,
        // //! för att om fönsterstorlek ändras kommer start positionen vara olika.
        float startX = 50f;
        float startY = -50f;
        //Spacing mellan enemies
        float spacingX = 150f;
        float spacingY = 100f;

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < column; c++)
            {
                Vector2 spawnPosition = new Vector2(startX + (c * spacingX), startY + (r * spacingY));


                if (r >= 3)
                {
                    _enemyList.Add(new FastEnemy(_fastEnemy, spawnPosition, 200, 15f, false)); // RÖD 

                }
                else if (r >= 2)
                {
                    _enemyList.Add(new MediumEnemy(_mediumEnemy, spawnPosition, 50, 10f, false)); // BLÅ 
                }
                else if (r >= 1)
                {
                    _enemyList.Add(new HeavyEnemy(_heavyEnemy, spawnPosition, 75, 5f, false)); // GRÖN 
                }
                else
                {

                }

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