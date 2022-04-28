using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

public class OutsideColl
{
    public static Rectangle CheckCollisionY(List<Rectangle> wallRect, Rectangle playerRect, Vector2 movement)
    {
        for (int i = 0; i < wallRect.Count; i++)
        {
            if (Raylib.CheckCollisionRecs(playerRect, wallRect[i]))
            {
                playerRect.y -= movement.Y;
            }
        }

        return playerRect;
    }

    public static Rectangle CheckCollisionX(List<Rectangle> wallRect, Rectangle playerRect, Vector2 movement)
    {
        for (int i = 0; i < wallRect.Count; i++)
        {
            if (Raylib.CheckCollisionRecs(playerRect, wallRect[i]))
            {
                playerRect.x -= movement.X;
            }
        }

        return playerRect;
    }   
}