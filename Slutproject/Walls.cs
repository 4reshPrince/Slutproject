using System;
using System.Collections.Generic;
using Raylib_cs;


public class Walls
{
    public static List<Rectangle> MakeWalls()
    {
        List<Rectangle> wallRects = new List<Rectangle>();
        
        wallRects.Add(new Rectangle(209, 0, 590, 80));
        wallRects.Add(new Rectangle(0, 0, 210, 254));
        wallRects.Add(new Rectangle(505, 81, 39, 119));
        wallRects.Add(new Rectangle(543, 81, 85, 46));
        wallRects.Add(new Rectangle(756, 81, 44, 518));
        wallRects.Add(new Rectangle(420, 560, 335, 39));
        wallRects.Add(new Rectangle(504, 280, 251, 81));
        wallRects.Add(new Rectangle(609, 361, 83, 41));
        wallRects.Add(new Rectangle(0, 254, 40, 227));
        wallRects.Add(new Rectangle(0, 481, 125, 119));
        wallRects.Add(new Rectangle(125, 560, 254, 39));
        wallRects.Add(new Rectangle(54, 360, 144, 52));
        wallRects.Add(new Rectangle(673, 121, 82, 42));
        wallRects.Add(new Rectangle(325, 81, 67, 15));

        return wallRects;
    }

    public static List<Rectangle> MakeWall()
    {
        List<Rectangle> wallRect = new List<Rectangle>();
        
        wallRect.Add(new Rectangle(0, 0, 800, 56));
        wallRect.Add(new Rectangle(61, 89, 200, 117));
        wallRect.Add(new Rectangle(61, 207, 80, 37));
        wallRect.Add(new Rectangle(181, 207, 80, 37));
        wallRect.Add(new Rectangle(352, 97, 58, 44));
        wallRect.Add(new Rectangle(307, 141, 148, 66));
        wallRect.Add(new Rectangle(342, 244, 39, 13));
        wallRect.Add(new Rectangle(464, 321, 36, 68));
        wallRect.Add(new Rectangle(502, 89, 199, 117));
        wallRect.Add(new Rectangle(502, 207, 79, 39));
        wallRect.Add(new Rectangle(621, 207, 80, 37));
        wallRect.Add(new Rectangle(0, 56, 19, 543));
        wallRect.Add(new Rectangle(782, 56, 17, 543));
        wallRect.Add(new Rectangle(20, 581, 762, 18));
        

        return wallRect;
    }

}
