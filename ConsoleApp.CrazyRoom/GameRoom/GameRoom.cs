namespace ConsoleApp.CrazyRoom.GameRoom;

using ConsoleApp.CrazyRoom.Hero;
using ConsoleApp.CrazyRoom.Things;

public class GameRoom
{
    public class Room : IGameRoom
    {
        private readonly byte _width;
        private readonly byte _height;
        private readonly int[,] _grid;
        private Hero _hero;
        private Thing[] _things;

        public Room(byte w, byte h, Hero hero, Thing[] things)
        {
            if (w > 40) throw new ArgumentException("Invalid width, must be less than or equal to 40."); 
            if (h > 40) throw new ArgumentException("Invalid height, must be less than or equal to 40.");

            _width = w;
            _height = h;
            _grid = new int[_width, _height];
            _hero = hero;
            _things = things;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public int[,] GetGrid()
        {
            return _grid;
        }
    }
}