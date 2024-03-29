using Pacman.utils;

namespace Pacman
{
    public class Map
    {
        public List<List<string>> MapData { get; set; }
        public static List<string> walkable = new() { " ", "·", "o", "ⴃ" };
        public static int Width = 0;
        public static int Height = 0;
        public static List<Point> Points = [];
        public static List<PacGomme> PacGommes = [];
        public static List<Cherry> Cherries = [];

        private void InitMap()
        {
            var map_lines = MapText.getMapText().Split('\n');
            foreach (var line in map_lines)
            {
                var map_line = new List<string>();
                foreach (var c in line)
                {
                    if (c.ToString() == walkable[1])
                    {
                        map_line.Add(" ");
                        Points.Add(new Point(map_line.Count - 1, MapData.Count));
                        continue;
                    }
                    if (c.ToString() == walkable[2])
                    {
                        map_line.Add(" ");
                        PacGommes.Add(new PacGomme(map_line.Count - 1, MapData.Count));
                        continue;
                    }
                    if (c.ToString() == walkable[3])
                    {
                        map_line.Add(" ");
                        Cherries.Add(new Cherry(map_line.Count - 1, MapData.Count));
                        continue;
                    }
                    if (!walkable.Contains(c.ToString()))
                    {
                        var temp = "#darkblue#" + c + "#white#";
                        map_line.Add(temp);
                        continue;
                    }
                    map_line.Add(c.ToString());
                }
                MapData.Add(map_line);
            }
            Width = MapData[0].Count;
            Height = MapData.Count;
        }

        public Map()
        {
            MapData = new List<List<string>>();
            InitMap();
        }
    
        public void Draw()
        {
            Console.WriteLine($"Score: {Game.Score}");
            for (var i = 0; i < MapData.Count; i++)
            {
                for (var j = 0; j < MapData[i].Count; j++)
                {
                    ColorWrite.Parser(MapData[i][j]);
                }
                Console.WriteLine();
            }
        }
        
        public static void CheckCollision()
        {
            foreach (var point in Points)
            {
                point.CheckCollision();
            }

            foreach (var pacGomme in PacGommes)
            {
                pacGomme.CheckCollision();
            }

            foreach (var cherry in Cherries)
            {
                cherry.CheckCollision();
            }
        }
        
        public static void DrawObject()
        {
            foreach (var point in Points)
            {
                point.Draw();
            }

            foreach (var pacGomme in PacGommes)
            {
                pacGomme.Draw();
            }

            foreach (var cherry in Cherries)
            {
                cherry.Draw();
            }
            
        }
        
        public static void CheckWin()
        {
            if (Points.All(point => point.IsEaten) && PacGommes.All(pacGomme => pacGomme.IsEaten) && Cherries.All(cherry => cherry.IsEaten))
            {
                Console.Clear();
                Console.WriteLine("You win!");
                Console.WriteLine($"Score: {Game.Score}");
                Game.Running = false;
            }
        }
    
    }
}