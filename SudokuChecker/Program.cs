namespace SudokuChecker
{
    public class Program
    {
        public static string CheckSudoku(List<List<int>> board)
        {
            // Check each row
            for (int i = 0; i < 9; i++)
            {
                if (board.Count <= i)
                {
                    return $"Row {i + 1} is erroneous.";
                }
                if (!IsValidSet(board[i]))
                {
                    return $"Row {i + 1} is erroneous.";
                }
            }

            // Check each column
            for (int i = 0; i < 9; i++)
            {
                var column = board.Select(row => row[i]).ToList();
                if (!IsValidSet(column))
                {
                    return $"Column {i + 1} is erroneous.";
                }
            }

            // Check each 3x3 region
            var region = 0;
            for (int row = 0; row < 9; row += 3)
            {
                for (int col = 0; col < 9; col += 3)
                {
                    var section = new List<int>();
                    for (int r = row; r < row + 3; r++)
                    {
                        for (int c = col; c < col + 3; c++)
                        {
                            section.Add(board[r][c]);
                        }
                    }
                    region++;
                    if (!IsValidSet(section))
                    {
                        return $"Region {region} is erroneous.";
                    }
                }
            }

            // If no errors, the board is valid
            return "The Sudoku board is valid.";
        }

        private static bool IsValidSet(List<int> numbers)
        {
            var validSet = Enumerable.Range(1, 9).ToDictionary(x => x, x => 0);
            foreach (var number in numbers)
            {
                if (!validSet.ContainsKey(number)) { return false; }
                validSet[number] = 1;
            }
            return !validSet.Any(x => x.Value == 0);
        }
    }
}