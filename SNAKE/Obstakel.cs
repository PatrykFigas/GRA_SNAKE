public class Obstacle

{

    public int Xpos { get; set; }
    public int Ypos { get; set; }
    public ConsoleColor ScreenColor { get; set; }
    public string Character { get; set; }

    public Obstacle(int xPos, int yPos, ConsoleColor color, string character)
    {
        Xpos = xPos;
        Ypos = yPos;
        ScreenColor = color;
        Character = character;
    }

    public void draw()
    {
        Console.ForegroundColor = ScreenColor;
        Console.SetCursorPosition(Xpos, Ypos);
        Console.Write(Character);
    }
}