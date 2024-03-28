using Pacman.utils;

namespace Pacman;

public class Map
{
    public List<List<char>> MapData { get; set; }
    public static List<char> walkable = new() { ' ', '·', '+' };
    public static int Width = 0;
    public static int Height = 0;

    private void InitMap()
    {
        var map_text = @"
╔═══════════════════╦═══════════════════╗
║ · · · · · · · · · ║ · · · · · · · · · ║
║ · ╔═╗ · ╔═════╗ · ║ · ╔═════╗ · ╔═╗ · ║
║ + ╚═╝ · ╚═════╝ · ╨ · ╚═════╝ · ╚═╝ + ║
║ · · · · · · · · · · · · · · · · · · · ║
║ · ═══ · ╥ · ══════╦══════ · ╥ · ═══ · ║
║ · · · · ║ · · · · ║ · · · · ║ · · · · ║
╚═════╗ · ╠══════   ╨   ══════╣ · ╔═════╝
      ║ · ║                   ║ · ║
══════╝ · ╨   ╔════---════╗   ╨ · ╚══════
        ·     ║ █ █   █ █ ║     ·        
══════╗ · ╥   ║           ║   ╥ · ╔══════
      ║ · ║   ╚═══════════╝   ║ · ║
      ║ · ║       READY       ║ · ║
╔═════╝ · ╨   ══════╦══════   ╨ · ╚═════╗
║ · · · · · · · · · ║ · · · · · · · · · ║
║ · ══╗ · ═══════ · ╨ · ═══════ · ╔══ · ║
║ + · ║ · · · · · ·   · · · · · · ║ · + ║
╠══ · ╨ · ╥ · ══════╦══════ · ╥ · ╨ · ══╣
║ · · · · ║ · · · · ║ · · · · ║ · · · · ║
║ · ══════╩══════ · ╨ · ══════╩══════ · ║
║ · · · · · · · · · · · · · · · · · · · ║
╚═══════════════════════════════════════╝";
        var map_lines = map_text.Split('\n');
        foreach (var line in map_lines)
        {
            var map_line = new List<char>();
            foreach (var c in line)
            {
                map_line.Add(c);
            }
            MapData.Add(map_line);
        }
        Width = MapData[0].Count;
        Height = MapData.Count;
    }

    public Map()
    {
        MapData = new List<List<char>>();
        InitMap();
    }
    
    public void Draw()
    {
        Console.Clear();
        for (var i = 0; i < MapData.Count; i++)
        {
            for (var j = 0; j < MapData[i].Count; j++)
            {
                Console.Write(MapData[i][j]);
            }
            Console.WriteLine();
        }
    }
    
}