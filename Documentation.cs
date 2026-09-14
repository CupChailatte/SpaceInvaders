
/*
14 September

Space Invaders - Vad jag behöver  

Basklass "Entity" 

Enitites
- Player 
- Enemy 
- Bullet 

Managers 
- InputManager 
- EnemyManager 
- BulletManager 

Visuals
- Animation 
- Sound


///
 ------------ Version 1  -------------------

Spelet skall innehålla minst 3 klasser utöver Game1, dvs. Player, Enemy, och Bullet.
Spelaren skall kunna styra kanonen i x-led med hjälp av tangentbordet (vänster och höger pilar).
Spelets namn och poäng skall visas i titellisten samt fönsterstorlek sätts så att höjden är större än bredden.
Minst tre rader med fiender skall placeras högst upp på skärmen. Du skall använda en lista.
Fienderna är stationära i x-led och rör sig endast nedåt mot spelaren.
Spelaren skall skjuta fiender men fienderna behöver inte skjuta tillbaka mot spelaren.
Spelaren skall förlora ett liv om en fiende når botten av skärmen
///




 ------------ Version 2 -------------------

Nu skall du utöka spelet med fler rader av fiender (minst fem rader) med olika typer av fiender som ger olika poäng.
Fienderna ska hanteras i en 2D-array.
Fienderna ska röra sig från vänster till höger, sedan nedåt, och därefter från höger till vänster, som i det ursprungliga spelet.
Anpassa spelet så att poängen skrivs ut på skärmen.
Skapa en Startskärm och GameOver-skärm som visas när spelet startar respektive avslutas. Detta görs genom tre olika gamestates som hanteras med enum.
Både start- och slutskärm skall ha en bakgrundsbild.
Startskärmen skall innehålla en animation med hjälp av ett spritesheet och spelet startas genom att klicka på en specifik bild.
Spelet tar slut efter ett begränsat antal liv eller om alla fiender är besegrade.
På slutskärmen skall du rita ut minst 5 valfria sprites med slumpad position.




---- DOCS --- 

1 Först skapar Entity basklass, underklasserna är Bullet, Player och Enemy.
2 Gör player class klar: 
- Texture renderas och positoneras sig på skärmen. 
- Player kan röra på sig
- Player ska ha bullet texture i konstruktorn, eftersom den ska kunna skjuta 







 */ 


 