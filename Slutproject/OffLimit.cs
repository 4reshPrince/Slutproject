using System;
using Raylib_cs;


public class OffLimit
{
    public static (bool, bool) Limits(Rectangle playerRect, bool undoX, bool undoY)
    {
        if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
        {
            undoX = true;
        }
        if (playerRect.y < 0 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
        {
            undoY = true;
        }

        return (undoX, undoY);
    }
}
