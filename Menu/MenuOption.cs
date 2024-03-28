using Pacman.utils;

namespace Pacman.Menu;

public class MenuOption(string label, Action action, int index, bool centered = true)
{
    private string Label { get; set; } = label;
    private bool Centered { get; set; } = centered;
    private int Index { get; set; } = index;
    public bool Selected { get; set; }
    public Action Action { get; set; } = action;

    public void Display()
    {
        if (Centered) Console.SetCursorPosition(Console.WindowWidth / 2 - (ColorWrite.GetTextLength(Label) / 2), Console.WindowHeight / 2 + Index);
        ColorWrite.Parser(Selected ? $"#yellow#> {Label}" : Label);
    }
}