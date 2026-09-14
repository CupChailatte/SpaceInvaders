using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CoreClassLibrary.Managers;

public class DisplayManager
{
    private readonly GraphicsDeviceManager _graphics;
    public int Width { get; private set; }
    public int Height { get; private set; }
    public bool IsFullScreen { get; private set; }

    public DisplayManager(GraphicsDeviceManager graphics, int width, int height, bool isFullScreen)
    {
        _graphics = graphics;
        SetResolution(width, height);
    }

    //Metod som applicerar ändringarna från värderna. 
    public void SetResolution(int width, int height)
    {
        Width = width;
        Height = height;

        _graphics.PreferredBackBufferWidth = Width;
        _graphics.PreferredBackBufferHeight = Height;
        _graphics.IsFullScreen = IsFullScreen;
        _graphics.ApplyChanges();
    }
}