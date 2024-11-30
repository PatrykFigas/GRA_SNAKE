public class Pixel
{

    public int xPos { get; set; }

    public int yPos { get; set; }

    public ConsoleColor ScreenColor { get; set; }

    public string Character { get; set; }

    public Pixel(int xPos, int yPos, ConsoleColor color, string character)
    {
        this.xPos = xPos;
        this.yPos = yPos;
        this.ScreenColor = color;
        this.Character = character;
    }

    public void Draw() 
    {
        Console.ForegroundColor = this.ScreenColor;
        Console.SetCursorPosition(this.xPos, this.yPos);
        Console.Write(this.Character);  
    }

}