using System;
using Raylib_cs;
using System.Numerics;

public class Screens
{
    public static string MainMenuChoice(Texture2D menuImage, Vector2 mousePos, string level)
    {

        Rectangle playRect = new Rectangle(290, 375, 198, 80);
        Rectangle settingRect = new Rectangle(306, 469, 168, 57);

        Raylib.DrawTexture(menuImage, 0, 0, Color.WHITE);

        // Kolla om positionen är inuti rektangeln && musknappen är nedtryckt
        if (Raylib.CheckCollisionPointRec(mousePos, playRect))
        {

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                level = "start";
            }
        }
        else if (Raylib.CheckCollisionPointRec(mousePos, settingRect))
        {

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                level = "setting";
            }
        }

        return level;
    }

    public static string SettingScreen(Texture2D settingImage, Vector2 mousePos, string level)
    {
        Rectangle backRect = new Rectangle(8, 6, 60, 60);

        Raylib.DrawTexture(settingImage, 0, 0, Color.WHITE);

        // Kolla om positionen är inuti rektangeln && musknappen är nedtryckt
        if (Raylib.CheckCollisionPointRec(mousePos, backRect))
        {

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                level = "menu";
            }
        }

        return level;
    }
}