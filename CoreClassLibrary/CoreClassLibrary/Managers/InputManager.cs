using System;
using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input; 

namespace CoreClassLibrary.Managers; 

public class InputManager
{
    private KeyboardState _currentKey; 
    private KeyboardState _previousKey; 

    private MouseState _currentMouse;
    private MouseState _previousMouse;

    public void Update()
    {
        //1. Flyttar current state till previous state 
        _previousKey = _currentKey;
        _previousMouse = _currentMouse; 
        // 2. Tar nya tangent states från Monogame. 
        _currentKey = Keyboard.GetState();
        _currentMouse = Mouse.GetState(); 
    }

    // -- TANGENT HJÄLPARE -- 

    // --RÖRELSE I X-AXLEN 
    // blir sant vart enda frame om man trycker ner på en tangent
  
    public bool IsKeyDown(Keys key)
    {
        return _currentKey.IsKeyDown(key); 
    }
    //-- SKJUTA MED TANGENTBORD -- 
    // Blir sant bara på den frame man trycker på en tangent t.ex hoppa med spacebar
    public bool IsKeyPressed(Keys key)
    {
        return _currentKey.IsKeyDown(key) && _previousKey.IsKeyUp(key); 
    }

    // -- MUS HJÄLPARE --

    //-- SKJUTA MED MUS --- 
    // Blir sant bara på den frame man trycker på musen. 
    public bool IsLeftClick() 
    {
        return _currentMouse.LeftButton == ButtonState.Pressed && 
        _previousMouse.LeftButton == ButtonState.Released; 
    }

}