namespace ConsoleApp.CrazyRoom.Models;

using Interfaces;
using Things;

public class Game : IGame
{
    private readonly IRenderService _renderService;
    private readonly IEventLoggerService _eventLoggerService;
    private readonly IStatusService _statusService;
    private readonly IInteractionService _mineInteractionService;
    private readonly IEventService _eventService;

    public Game(
        IRenderService renderService,
        IEventLoggerService eventLoggerService,
        IStatusService statusService,
        IInteractionService mineInteractionService,
        IEventService eventService
    )
    {
        _renderService = renderService;
        _eventLoggerService = eventLoggerService;
        _statusService = statusService;
        _mineInteractionService = mineInteractionService;
        _eventService = eventService;
    }

    public void Start(IRoom room)
    {
        foreach (var thing in room.GetThingsListInRoom())
        {
            if (thing is Mine)
            {
                _mineInteractionService.Subscribe(thing);
            }
        }
        _renderService.Run(room);
        _eventService.Run(room);
        
        while (true)
        {
            var keyInfo = Console.ReadKey();
            var hero = room.GetHero();
            
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    hero.MoveLeft(0);
                    break;
                case ConsoleKey.RightArrow:
                    hero.MoveRight((sbyte)(room.GetWidth() - 1));
                    break;
                case ConsoleKey.UpArrow:
                    hero.MoveUp(0);
                    break;
                case ConsoleKey.DownArrow:
                    hero.MoveDown((sbyte)(room.GetHeight() - 1));
                    break;
            }
            
            _renderService.Run(room);
            _eventService.Run(room);
        }
    }
    //
    // private void RenderSidebar(int width, int height) 
    // {
    //     // Тут этому не место
    //     if (_logs.Count > _roomHeight)
    //     {
    //         _logs.RemoveAt(0);
    //     }
    //     
    //     
    //     
    //     for (var h = 0; h < height; h++)
    //     {
    //         Console.SetCursorPosition(width + 1, h);
    //         Console.Write('|');
    //         Console.Write(' ');
    //         Console.Write(_logs.Count <= h ? string.Empty : _logs[h]);
    //     }
    // }
    //
    // public void Start()
    // {
    //     Render();
    //     
    //     while (true)
    //     {
    //         var keyInfo = Console.ReadKey();
    //         
    //         switch (keyInfo.Key)
    //         {
    //             case ConsoleKey.LeftArrow:
    //                 _hero.MoveLeft(0);
    //                 Render();
    //                 break;
    //             case ConsoleKey.RightArrow:
    //                 _hero.MoveRight((sbyte)(_roomWidth - 1));
    //                 Render();
    //                 break;
    //             case ConsoleKey.UpArrow:
    //                 _hero.MoveUp(0);
    //                 Render();
    //                 break;
    //             case ConsoleKey.DownArrow:
    //                 _hero.MoveDown((sbyte)(_roomHeight - 1));
    //                 Render();
    //                 break;
    //             
    //             default:
    //                 break;
    //         }
    //     }
    // }
}