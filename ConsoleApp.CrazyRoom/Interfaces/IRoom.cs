namespace ConsoleApp.CrazyRoom.Interfaces;

using Models.Things;

/// <summary>
/// Интерфейс для описания игровой комнаты, в которой происходят все события игры
/// </summary>
public interface IRoom
{
    /// <summary>
    /// Получает ширину комнаты
    /// </summary>
    /// <returns> Ширина комнаты в единицах (1 единица = 1 ячейка массива) </returns>
    int GetWidth();

    /// <summary>
    /// Получает высоту комнаты
    /// </summary>
    /// <returns>Высота комнаты в единицах (1 единица = 1 ячейка массива)</returns>
    int GetHeight();

    /// <summary>
    /// Получает все предметы в комнате
    /// </summary>
    /// <returns>Все предметы</returns>
    Thing[] GetThingsListInRoom();

    /// <summary>
    /// Получает героя
    /// </summary>
    /// <returns>Герой</returns>
    IHero GetHero();
    
    /// <summary>
    /// Получает разметку для комнаты
    /// </summary>
    /// <returns> Двумерный массив, представляющий разметку комнаты на ячейки </returns>
    int[,] GetGrid();
}