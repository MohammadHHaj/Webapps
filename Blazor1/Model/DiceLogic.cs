namespace Blazor1.Pages;

public class DiceLogic
{
    public string GetImagePath()
    {
        return $"/øjne{eyes}.png";
    }
    

    public int eyes;

    public int size;

    public Random r;

    public DiceLogic(int size = 6)
    {
        this.size = size;
        r = new();
    }

    public void Roll()
    {
        eyes = r.Next(size) + 1;
    }

    public int getEyes()
    {
        return eyes;
    }

    public int GetSize()
    {
        return size;
    }
}
