namespace ConsoleApp.CrazyRoom.Game;

using GameRoom;
using Hero;
using Things;
using GameRender;
using GameChat;
using GameStatusDisplay;

public class Game
{
    private readonly int _roomWidth;
    private readonly int _roomHeight;
    private readonly IHero _hero;
    private readonly Thing[] _things;
    private readonly List<string> _logs  = [];
    private readonly IGameRender _gameRender = new GameRender();
    private readonly IGameChat _gameChat = new GameChat();
    private readonly IGameStatusDisplay _gameStatusDisplay = new GameStatusDisplay();

    public Game(IGameRoom gameRoom)
    {
        IHero hero = gameRoom.GetHero();
        
        _hero = hero;
        _roomWidth = gameRoom.GetWidth();
        _roomHeight = gameRoom.GetHeight();
        _things = gameRoom.GetThingsListInRoom();
        
        // Как реализовать DI? Чем больше объектов будет появляться тем хуже
        var interactionManager = new MineInteractionManager();
        foreach (var thing in _things)
        {
            if (thing is Mine)
            {
                interactionManager.Subscribe(thing as Mine);
            }
        }
    }

    private void Render()
    {
        Console.Clear();
        
        var heroPosition = _hero.GetPosition();

        for (var y = 0; y < _roomHeight; y++)
        {
            for (var x = 0; x < _roomWidth; x++)
            {
                if (heroPosition.X == x && heroPosition.Y == y)
                {
                    ShowHero(_hero);
                }
                else if (_things.Length == 0)
                {
                    ShowEmptyField();
                }
                else
                {
                    bool isEmpty = true;
                    foreach (var thing in _things)
                    {
                        var thingPosition = thing.GetPosition();
                        if (thingPosition.X != x || thingPosition.Y != y) continue;
                        ShowThing(thing);
                        isEmpty = false;

                        if (!thing.InTheAreaOfAction(heroPosition)) continue;
                        thing.InteractWith(_hero as IGameCharacter);
                        _logs.Add($"Осталось здоровья {_hero.GetHealth()} из 100");
                    }

                    if (isEmpty)
                    {
                        ShowEmptyField();
                    }
                }
            }
            Console.WriteLine();
        }
        
        RenderSidebar(_roomWidth, _roomHeight);
    }
    
    private void ShowHero(IHero hero)
    {
        // Требуется сущность для реализации отображения героя
        // Например, герой может поменять одежду если идет дождь и прочее
        Console.Write(hero.GetAvatar());
    }

    private void ShowEmptyField()
    {
        Console.Write('.');
    }

    private void ShowThing(Thing thing)
    {
        Console.Write(thing.GetAvatar());
    }
    
    private void RenderSidebar(int width, int height) 
    {
        // Тут этому не место
        if (_logs.Count > _roomHeight)
        {
            _logs.RemoveAt(0);
        }
        
        
        
        for (var h = 0; h < height; h++)
        {
            Console.SetCursorPosition(width + 1, h);
            Console.Write('|');
            Console.Write(' ');
            Console.Write(_logs.Count <= h ? string.Empty : _logs[h]);
        }
    }

    public void Start()
    {
        Render();
        
        while (true)
        {
            var keyInfo = Console.ReadKey();
            
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    _hero.MoveLeft(0);
                    Render();
                    break;
                case ConsoleKey.RightArrow:
                    _hero.MoveRight((sbyte)(_roomWidth - 1));
                    Render();
                    break;
                case ConsoleKey.UpArrow:
                    _hero.MoveUp(0);
                    Render();
                    break;
                case ConsoleKey.DownArrow:
                    _hero.MoveDown((sbyte)(_roomHeight - 1));
                    Render();
                    break;
                
                default:
                    break;
            }
        }
    }
}