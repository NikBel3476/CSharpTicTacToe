using CSharpTicTacToe;

Player player = Player.First; 
string? errorMessage = null;
Game game = new Game();
Player? winner = null;

while (true)
{
    Console.Clear();
    
    game.WriteBoard();
    
    Console.WriteLine($"Ход игрока {(int)player} ({(player == Player.First ? 'X' : 'O')})");
    Console.WriteLine("Введите номер клетки (1 - 9)");
    if (!String.IsNullOrEmpty(errorMessage)) Console.WriteLine(errorMessage);
    try
    {
        errorMessage = null;
        int cellId = int.Parse(Console.ReadLine());
        if (cellId < 1 || cellId > 9) throw new ArgumentOutOfRangeException();
        
        game.Play(cellId - 1, player);
        winner = game.CheckWinner();
        if (winner != null) break;
        if (game.IsGridFilled()) break;
    }
    catch (Exception e)
    {
        switch (e)
        {
            case FormatException:
                errorMessage = "Неверный формат числа";
                break;
            case ArgumentOutOfRangeException:
                errorMessage = "Номер клетки должен быть от 1 до 9";
                break;
            case InvalidOperationException:
                errorMessage = "Клетка уже занята";
                break;
            default:
                errorMessage = "Неизвестная ошибка";
                break;
        }
        continue;
    }

    player = player == Player.First ? Player.Second : Player.First;
}

Console.Clear();
game.WriteBoard();
Console.WriteLine(winner != null ? $"Победил игрок {(int)winner}" : "Ничья");
Console.ReadKey();