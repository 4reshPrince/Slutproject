using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

public class Collisions
{
    public static Rectangle CheckCollisionY(List<Rectangle> wallRects, Rectangle playerRect, Vector2 movement)
    {
        for (int i = 0; i < wallRects.Count; i++)
        {
            if (Raylib.CheckCollisionRecs(playerRect, wallRects[i]))
            {
                playerRect.y -= movement.Y;
            }
        }

        return playerRect;
    }

    public static Rectangle CheckCollisionX(List<Rectangle> wallRects, Rectangle playerRect, Vector2 movement)
    {
        for (int i = 0; i < wallRects.Count; i++)
        {
            if (Raylib.CheckCollisionRecs(playerRect, wallRects[i]))
            {
                playerRect.x -= movement.X;
            }
        }

        return playerRect;
    }   
}