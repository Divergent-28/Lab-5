using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    /// <summary>
    /// Класс крестики-нолики
    /// Возвращамые значения: <returns>
    /// </summary>
    public class MB
    {
        static void Continue()
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadLine();
        }

        static char[,] playerGrid = new char[5, 5];
        static char[,] computerGrid = new char[5, 5];

        public void MorskoyBoy()
        {
            InitializeGrid(playerGrid);
            InitializeGrid(computerGrid);

            Console.WriteLine("Добро пожаловать в игру 'Морской бой'!");

            PlayerPlaceShips(playerGrid);
            PlaceShips(computerGrid);

            while (!GameIsOver())
            {
                DisplayGrid();

                PlayerTurn();

                ComputerTurn();
            }
            Console.WriteLine("Игра окончена!");
        }

        static void InitializeGrid(char[,] grid)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grid[i, j] = '~';
                }
            }
        }

        static void PlaceShips(char[,] grid)
        {
            // 3 однопалубных корабля
            PlaceShip(grid, 1);
            PlaceShip(grid, 1);
            PlaceShip(grid, 1);

            // 1 двухпалубный корабль
            PlaceShip(grid, 2);

            // 1 трёхпалубный корабль
            PlaceShip(grid, 3);
        }

        static void PlayerPlaceShips(char[,] grid)
        {
            // 3 однопалубных корабля
            for (int i = 0; i < 3; i++)
            {
                PlayerPlaceShip(grid, 1);
            }

            // 1 двухпалубный корабль
            PlayerPlaceShip(grid, 2);

            // 1 трёхпалубный корабль
            PlayerPlaceShip(grid, 3);
        }

        static void PlaceShip(char[,] grid, int shipSize)
        {
            Random random = new Random();
            int orientation = random.Next(2);

            int row, col;
            do
            {
                row = random.Next(5);
                col = random.Next(5);
            } while (!CanPlaceShip(grid, shipSize, orientation, row, col));

            if (orientation == 0) // Горизонтально
            {
                for (int i = 0; i < shipSize; i++)
                {
                    grid[row, col + i] = 'S';
                }
            }
            else // Вертикально
            {
                for (int i = 0; i < shipSize; i++)
                {
                    grid[row + i, col] = 'S';
                }
            }
        }

        static void PlayerPlaceShip(char[,] grid, int shipSize)
        {
            while (!TryPlayerPlaceShip(grid, shipSize)) { };
        }

        static bool TryPlayerPlaceShip(char[,] grid, int shipSize)
        {
            DisplayGrid(grid, true);
            Console.WriteLine("Введите координаты для размещения корабля размером " + shipSize);

            char rowChar;
            int row;
            do
            {
                Console.WriteLine("Введите строку (A-E): ");
                string input = Console.ReadLine().ToUpper();
                if (input.Length == 1 && input[0] >= 'A' && input[0] <= 'E')
                {
                    rowChar = input[0];
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите один символ от A до E.");
                    rowChar = '0';
                }
            }
            while (rowChar < 'A' || rowChar > 'E');

            row = rowChar - 'A';
            Console.WriteLine("Введите столбец (1-5): ");
            int col;
            do
            {
                int.TryParse(Console.ReadLine(), out col);
                if (col < 1 || col > 5)
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите числовое значение от 1 до 5.");
                }
            } while (col <= 0 || col > 5);
            col--;

            Console.WriteLine("Выберите ориентацию корабля (0 - Горизонтально, 1 - Вертикально): ");
            int orientation;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out orientation) || (orientation != 0 && orientation != 1))
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите 0 или 1 для ориентации корабля.");
                    orientation = -1;
                }
            } while (orientation != 0 && orientation != 1);

            if (CanPlaceShip(grid, shipSize, orientation, row, col))
            {
                if (orientation == 0) // Горизонтально
                {
                    for (int i = 0; i < shipSize; i++)
                    {
                        grid[row, col + i] = 'S';
                    }
                }
                else // Вертикально
                {
                    for (int i = 0; i < shipSize; i++)
                    {
                        grid[row + i, col] = 'S';
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("Корабль не может быть размещен в данном месте. Пожалуйста, введите другие координаты.");
            }
            return false;
        }


        static bool CanPlaceShip(char[,] grid, int shipSize, int orientation, int row, int col)
        {
            if (orientation == 0) // Горизонтально
            {
                if (col + shipSize > 5) return false;
                for (int i = 0; i < shipSize; i++)
                {
                    if (grid[row, col + i] != '~') return false;
                }
            }
            else // Вертикально
            {
                if (row + shipSize > 5) return false;
                for (int i = 0; i < shipSize; i++)
                {
                    if (grid[row + i, col] != '~') return false;
                }
            }
            return true;
        }

        static void DisplayGrid()
        {
            Console.WriteLine("Игровое поле игрока:");
            DisplayGrid(playerGrid, true);
            Console.WriteLine();
            Console.WriteLine("Игровое поле компьютера:");
            DisplayComputerGrid();
        }

        static void DisplayComputerGrid()
        {
            char rowLabel = 'A';
            Console.Write(" ");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Console.Write(rowLabel++ + " ");
                for (int j = 0; j < 5; j++)
                {
                    // Все клетки изначально отображаются как вопросительные знаки
                    if (computerGrid[i, j] == 'S')
                    {
                        Console.Write("? "); // Неизвестные клетки с кораблями
                    }
                    else if (computerGrid[i, j] == 'X')
                    {
                        Console.Write("X "); // Попадание
                    }
                    else if (computerGrid[i, j] == 'O')
                    {
                        Console.Write("O "); // Промах
                    }
                    else
                    {
                        Console.Write("? "); // Пустые клетки также отображаются как ?
                    }
                }
                Console.WriteLine();
            }
        }



        static void DisplayGrid(char[,] grid, bool isPlayer)
        {
            char rowLabel = 'A';
            Console.Write(" ");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                Console.Write(rowLabel++ + " ");
                for (int j = 0; j < 5; j++)
                {
                    if (grid[i, j] == 'S' && isPlayer)
                    {
                        Console.Write("S ");
                    }
                    else
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void CheckWinner()
        {
            if (AllShipsSunk(computerGrid))
            {
                Console.WriteLine("Вы выиграли!");
                Continue();
            }
            else if (AllShipsSunk(playerGrid))
            {
                Console.WriteLine("Компьютер выиграл!");
                Continue();
            }
        }

        static bool GameIsOver()
        {
            bool gameOver = AllShipsSunk(playerGrid) || AllShipsSunk(computerGrid);
            if (gameOver)
            {
                CheckWinner();
            }
            return gameOver;
        }

        static bool AllShipsSunk(char[,] grid)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (grid[i, j] == 'S') return false;
                }
            }
            return true;
        }

        static void PlayerTurn()
        {
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine("\nВаш ход. Введите координаты выстрела (например A1):");
                string input = Console.ReadLine().ToUpper();
                int row = -1;
                int col = -1;
                bool pr = true;
                while (pr)
                {
                    if (input.Length == 2 && int.TryParse(input.Substring(1), out col))
                    {
                        col--;
                        row = input[0] - 'A';
                        pr = false;
                    }
                    else
                    {
                        Console.WriteLine("Введите координату заново");
                        input = Console.ReadLine().ToUpper();
                    }
                }

                if (input.Length == 2 && char.IsLetter(input[0]) && char.IsDigit(input[1]))
                {
                    if (row >= 0 && row < 5 && col >= 0 && col < 5 && computerGrid[row, col] != 'X' && computerGrid[row, col] != 'O')
                    {
                        isValidInput = true;
                        if (computerGrid[row, col] == 'S')
                        {
                            computerGrid[row, col] = 'X';
                            Console.WriteLine("Попадание!");
                        }
                        else
                        {
                            computerGrid[row, col] = 'O';
                            Console.WriteLine("Мимо!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Координаты вне диапазона, или выстрел в одну то же место. Пожалуйста, попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите координаты в формате A1.");
                }
            }
        }


        static void ComputerTurn()
        {
            Random random = new Random();
            int row, col;
            do
            {
                row = random.Next(5);
                col = random.Next(5);
            } while (playerGrid[row, col] == 'X' || playerGrid[row, col] == 'O');

            if (playerGrid[row, col] == 'S')
            {
                playerGrid[row, col] = 'X';
                Console.WriteLine($"Компьютер попал по координатам {((char)('A' + row))}{(col + 1)}");
            }
            else
            {
                playerGrid[row, col] = 'O';
                Console.WriteLine($"Компьютер промахнулся по координатам {((char)('A' + row))}{(col + 1)}");
            }
        }
    }
}
