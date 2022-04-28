using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "2D-topdown game");
Raylib.SetTargetFPS(60);

float speed = 3f;

Texture2D playerImage = Raylib.LoadTexture("front.png");
Rectangle playerRect = new Rectangle(576, 171, playerImage.width, playerImage.height);

Texture2D menuImage = Raylib.LoadTexture("start-menu.png");
Texture2D settingImage = Raylib.LoadTexture("mapping-menu.png");
Texture2D startImage = Raylib.LoadTexture("Capture.png");
Texture2D outImage = Raylib.LoadTexture("outside.PNG");

Rectangle playRect = new Rectangle(290, 375, 198, 80);
Rectangle settingRect = new Rectangle(306, 469, 168, 57);
Rectangle backRect = new Rectangle(8, 6, 60, 60);



// Väggarnas plasering och position

List<Rectangle> wallRects = Walls.MakeWalls();
List<Rectangle> wallRect = Walls.MakeWall();



Rectangle door = new Rectangle(379, 595, 41, 6);
Rectangle door1 = new Rectangle(142, 207, 39, 3);
Rectangle door2 = new Rectangle(582, 207, 38, 3);
Rectangle door3 = new Rectangle(379, 595, 41, 6);


bool undoX = false;
bool undoY = false;

string level = "menu";

while (!Raylib.WindowShouldClose())
{

    Vector2 movement = ReadMovement(speed);

    if (movement.X > 0)
    {
        // Bilden ändras när man trycker på D
        playerImage = Raylib.LoadTexture("right.png");
    }
    else if (movement.X < 0)
    {
        // Bilden ändras när man trycker på A
        playerImage = Raylib.LoadTexture("left.png");
    }
    if (movement.Y > 0)
    {
        // Bilden ändras när man trycker på S
        playerImage = Raylib.LoadTexture("front.png");
    }
    else if (movement.Y < 0)
    {
        // Bilden ändras när man trycker på W
        playerImage = Raylib.LoadTexture("back.png");
    }

    undoX = false;
    undoY = false;

    // Läs av musens position, spara i en Vector2
    Vector2 mousePos = Raylib.GetMousePosition();

    if (level == "menu")
    {

        Raylib.DrawTexture(menuImage, 0, 0, Color.WHITE);

        // Kolla om positionen är inuti rektangeln && musknappen är nedtryckt
        if(Raylib.CheckCollisionPointRec(mousePos, playRect))
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

        // Om det stämmer...?

    }

    if (level == "setting")
    {

        Raylib.DrawTexture(settingImage, 0, 0, Color.WHITE);

        // Kolla om positionen är inuti rektangeln && musknappen är nedtryckt
        if(Raylib.CheckCollisionPointRec(mousePos, backRect))
        {
            
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                level = "menu";
            }
        }

        
    }

    if (level == "start")
    {
        Raylib.DrawTexture(startImage, 0, 0, Color.WHITE);

        movement = ReadMovement(speed);

        playerRect.x += movement.X;

        // Gör så att det finns väggar med collision i X-axeln

        playerRect = Collisions.CheckCollisionX(wallRects, playerRect, movement);



        playerRect.y += movement.Y;

        // Gör så att det finns väggar med collision i Y-axeln

        playerRect = Collisions.CheckCollisionY(wallRects, playerRect, movement);



        // Gör så att man inte kan gå utanför bilden i både X och Y axeln

        if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
        {
            undoX = true;
        }
        if (playerRect.y < 0 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
        {
            undoY = true;
        }

    }

    if (level == "sec")
    {
        Raylib.DrawTexture(outImage, 0, 0, Color.WHITE);

        movement = ReadMovement(speed);


        playerRect.x += movement.X;

        // Gör så att det finns väggar med collision i X-axeln

        playerRect = OutsideColl.CheckCollisionX(wallRect, playerRect, movement);


        
        playerRect.y += movement.Y;

        // Gör så att det finns väggar med collision i Y-axeln

        playerRect = OutsideColl.CheckCollisionY(wallRect, playerRect, movement);



        if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
        {
            undoX = true;
        }
        if (playerRect.y < 0 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
        {
            undoY = true;
        }
    }

    if (level == "third")
    {
        Raylib.DrawTexture(startImage, 0, 0, Color.WHITE);

        movement = ReadMovement(speed);

        playerRect.x += movement.X;


        playerRect.y += movement.Y;


        if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
        {
            undoX = true;
        }
        if (playerRect.y < 0 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
        {
            undoY = true;
        }
    }

    if (level == "start")
    {
        if (Raylib.CheckCollisionRecs(playerRect, door))
        {
            level = "sec";
            playerRect.x = 148;
            playerRect.y = 220;
        }
    }

    if (level == "sec")
    {
        if (Raylib.CheckCollisionRecs(playerRect, door1))
        {
            level = "start";
            playerRect.x = 385;
            playerRect.y = 540;
        }

        if (Raylib.CheckCollisionRecs(playerRect, door2))
        {
            level = "third";
            playerRect.x = 385;
            playerRect.y = 540;
        }
    }

    if (level == "third")
    {
        if (Raylib.CheckCollisionRecs(playerRect, door3))
        {
            level = "sec";
            playerRect.x = 587;
            playerRect.y = 220;
        }
    }

    if (undoX == true) playerRect.x -= movement.X;
    if (undoY == true) playerRect.y -= movement.Y;

    Raylib.BeginDrawing();

    if (level == "menu")
    {
        // Visar vart rektangeln är så att man vet positionen där man ska kunna trycka 
        // Raylib.DrawRectangleRec(playRect, Color.WHITE);
        // Raylib.DrawRectangleRec(settingRect, Color.WHITE);
    }

    if (level == "setting")
    {
        // Raylib.DrawRectangleRec(backRect, Color.WHITE);
    }

    if (level == "start")
    {
        for (int i = 0; i < wallRects.Count; i++)
        {
            // Raylib.DrawRectangleRec(wallRects[i], Color.WHITE);

        }

        // Raylib.DrawRectangleRec(doorRect, Color.BLUE);
    }

    if (level == "sec")
    {
        for (int i = 0; i < wallRect.Count; i++)
        {
            // Raylib.DrawRectangleRec(wallRect[i], Color.WHITE);
        }

        // Raylib.DrawRectangleRec(door1, Color.BLUE);
    }

    if (level == "third")
    {
        // Raylib.DrawRectangleRec(door3, Color.BLUE);
    }

    if (level == "start" || level == "sec" || level == "third")
    {
        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        // Raylib.DrawText(points.ToString(), 10, 10, 40, Color.BLACK);
    }

    Raylib.EndDrawing();
}

static Vector2 ReadMovement(float speed)
{
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;

    return movement;
}