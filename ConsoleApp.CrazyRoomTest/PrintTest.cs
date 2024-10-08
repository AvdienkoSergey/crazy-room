// using ConsoleApp.CrazyRoom;

namespace ConsoleApp.CrazyRoomTest;

public class PrintTest
{
    // private readonly Print _print = new("Crazy Room test");

    [Fact]
    public void Show()
    {
        // Assert.Equal("Crazy Room test", _print.Show());
    }
    
    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(9)]
    public void MyFirstTheory(int value)
    {
        // Assert.True(_print.IsOdd(value));
    }
}