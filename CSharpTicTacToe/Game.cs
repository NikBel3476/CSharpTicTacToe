namespace CSharpTicTacToe;

public class Game
{
    private enum FieldState
    {
        Empty,
        X,
        O
    }
    
    private FieldState[] _gameGrid = new []
    {
        FieldState.Empty, FieldState.Empty, FieldState.Empty,
        FieldState.Empty, FieldState.Empty, FieldState.Empty,
        FieldState.Empty, FieldState.Empty, FieldState.Empty
    };
    
    private void PrintField(FieldState fieldState)
    {
      ConsoleColor prevForegroundColor = Console.ForegroundColor;
      switch (fieldState)
      {
          case FieldState.X:
              Console.ForegroundColor = ConsoleColor.Red;
              Console.Write('X');
              Console.ForegroundColor = prevForegroundColor;
              break;
          case FieldState.O:
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.Write('O');
              Console.ForegroundColor = prevForegroundColor;
              break;
      }
    }

    private void WriteGrid()
    {
        Console.WriteLine(
        @"
             |     |         
          1  |  2  |  3  
        _____|_____|_____
             |     |     
          4  |  5  |  6  
        _____|_____|_____
             |     |     
          7  |  8  |  9  
             |     |     
        ");
    }

    private void WriteFields()
    {
        var prevCursorPosition = Console.GetCursorPosition();
        for (int i = 0; i < _gameGrid.Length; i++)
        {
            // TODO: delete magic numbers
            int x = 10 + i % 3 * 6;
            int y = 2 + i / 3 * 3;
            Console.SetCursorPosition(x, y);
            PrintField(_gameGrid[i]);
        }
        Console.SetCursorPosition(prevCursorPosition.Left, prevCursorPosition.Top);
    }

    public void WriteBoard()
    {
        WriteGrid();
        WriteFields();
    }

    public void Play(int field, Player player)
    {
        if (_gameGrid[field] != FieldState.Empty)
            throw new InvalidOperationException();

        _gameGrid[field] = player == Player.First ? FieldState.X : FieldState.O;
    }

    public Player? CheckWinner()
    {
        // 1st row
        if (
            _gameGrid[0] == _gameGrid[1] && _gameGrid[1] == _gameGrid[2]
            && _gameGrid[0] != FieldState.Empty
            && _gameGrid[1] != FieldState.Empty
            && _gameGrid[2] != FieldState.Empty
        ) return _gameGrid[0] == FieldState.X ? Player.First : Player.Second;
        
        // 2nd row
        if (
            _gameGrid[3] == _gameGrid[4] && _gameGrid[4] == _gameGrid[5]
            && _gameGrid[3] != FieldState.Empty
            && _gameGrid[4] != FieldState.Empty
            && _gameGrid[5] != FieldState.Empty
        ) return _gameGrid[3] == FieldState.X ? Player.First : Player.Second;
        
        // 3rd row
        if (
            _gameGrid[6] == _gameGrid[7] && _gameGrid[7] == _gameGrid[8]
            && _gameGrid[6] != FieldState.Empty
            && _gameGrid[7] != FieldState.Empty
            && _gameGrid[8] != FieldState.Empty
        ) return _gameGrid[6] == FieldState.X ? Player.First : Player.Second;
        
        // 1st column
        if (
            _gameGrid[0] == _gameGrid[3] && _gameGrid[3] == _gameGrid[6]
            && _gameGrid[0] != FieldState.Empty
            && _gameGrid[3] != FieldState.Empty
            && _gameGrid[6] != FieldState.Empty
        ) return _gameGrid[0] == FieldState.X ? Player.First : Player.Second;
        
        // 2nd column
        if (
            _gameGrid[1] == _gameGrid[4] && _gameGrid[4] == _gameGrid[7]
            && _gameGrid[1] != FieldState.Empty
            && _gameGrid[4] != FieldState.Empty
            && _gameGrid[7] != FieldState.Empty
        ) return _gameGrid[1] == FieldState.X ? Player.First : Player.Second;
        
        // 3rd column
        if (
            _gameGrid[2] == _gameGrid[5] && _gameGrid[5] == _gameGrid[8]
            && _gameGrid[2] != FieldState.Empty
            && _gameGrid[5] != FieldState.Empty
            && _gameGrid[8] != FieldState.Empty
        ) return _gameGrid[2] == FieldState.X ? Player.First : Player.Second;
        
        // diagonal 1
        if (
            _gameGrid[0] == _gameGrid[4] && _gameGrid[4] == _gameGrid[8]
            && _gameGrid[0] != FieldState.Empty
            && _gameGrid[4] != FieldState.Empty
            && _gameGrid[8] != FieldState.Empty
        ) return _gameGrid[0] == FieldState.X ? Player.First : Player.Second;
        
        // diagonal 2
        if (
            _gameGrid[2] == _gameGrid[4] && _gameGrid[4] == _gameGrid[6]
            && _gameGrid[2] != FieldState.Empty
            && _gameGrid[4] != FieldState.Empty
            && _gameGrid[6] != FieldState.Empty
        ) return _gameGrid[2] == FieldState.X ? Player.First : Player.Second;

        return null;
    }

    public bool IsGridFilled() => _gameGrid.All(x => x != FieldState.Empty);
}