namespace SudokuCheckerTests
{
    public class Tests
    {
        [Test]
        public void Test_ValidSudoku()
        {
            //arrange 
            var validBoard = new List<List<int>>
            {
                new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9},
                new List<int>{4, 5, 6, 7, 8, 9, 1, 2, 3},
                new List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6},
                new List<int>{2, 3, 4, 5, 6, 7, 8, 9, 1},
                new List<int>{5, 6, 7, 8, 9, 1, 2, 3, 4},
                new List<int>{8, 9, 1, 2, 3, 4, 5, 6, 7},
                new List<int>{3, 4, 5, 6, 7, 8, 9, 1, 2},
                new List<int>{6, 7, 8, 9, 1, 2, 3, 4, 5},
                new List<int>{9, 1, 2, 3, 4, 5, 6, 7, 8}
            };
            var expectedResult = "The Sudoku board is valid.";

            //act 
            var result = SudokuChecker.Program.CheckSudoku(validBoard);

            //assert 
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test_RowErrorSudoku()
        {
            //arrange 
            var rowErrorBoard = new List<List<int>>
            {
                new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9},
                new List<int>{4, 5, 6, 7, 8, 9, 1, 2, 3},
                new List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6},
                new List<int>{2, 3, 4, 5, 6, 7, 8, 9, 1},
                new List<int>{5, 6, 7, 8, 9, 1, 2, 3, 4},
                new List<int>{8, 9, 1, 2, 3, 4, 5, 5, 7}, // double 5 
                new List<int>{3, 4, 5, 6, 7, 8, 9, 1, 2},
                new List<int>{6, 7, 8, 9, 1, 2, 3, 4, 5},
                new List<int>{9, 1, 2, 3, 4, 5, 6, 7, 8}
            };
            var expectedResult = "Row 6 is erroneous.";

            //act 
            var result = SudokuChecker.Program.CheckSudoku(rowErrorBoard);

            //assert 
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test_ColumnErrorSudoku()
        {
            //arrange 
            var columnErrorBoard = new List<List<int>>
            {
                new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9},
                new List<int>{4, 5, 6, 7, 8, 9, 1, 2, 3},
                new List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6},
                new List<int>{2, 3, 4, 5, 6, 7, 8, 9, 1},
                new List<int>{5, 6, 7, 8, 9, 1, 2, 3, 4},
                new List<int>{8, 9, 1, 2, 3, 4, 5, 6, 7},
                new List<int>{3, 4, 5, 6, 7, 8, 9, 1, 2},
                new List<int>{6, 7, 8, 9, 1, 2, 3, 4, 5},
                new List<int>{9, 1, 3, 2, 4, 5, 6, 7, 8} // column 3 and 4 have twice 3 and twice 2 respectively 
            };
            var expectedResult = "Column 3 is erroneous.";

            //act 
            var result = SudokuChecker.Program.CheckSudoku(columnErrorBoard);

            //assert 
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test_RangeErrorSudoku()
        {
            //arrange 
            var sectionErrorBoard = new List<List<int>>
            {
                new List<int>{1, 2, 3, 4, 5, 7, 6, 8, 9}, // 2nd region has twice 7 and 3rd region has twice 9 
                new List<int>{4, 5, 6, 7, 8, 1, 9, 2, 3},
                new List<int>{7, 8, 9, 1, 2, 4, 3, 5, 6},
                new List<int>{2, 3, 4, 5, 6, 8, 7, 9, 1},
                new List<int>{5, 6, 7, 8, 9, 2, 1, 3, 4},
                new List<int>{8, 9, 1, 2, 3, 5, 4, 6, 7},
                new List<int>{3, 4, 5, 6, 7, 9, 8, 1, 2},
                new List<int>{6, 7, 8, 9, 1, 3, 2, 4, 5},
                new List<int>{9, 1, 2, 3, 4, 6, 5, 7, 8}
            };
            var expectedResult = "Region 2 is erroneous.";

            //act 
            var result = SudokuChecker.Program.CheckSudoku(sectionErrorBoard);

            //assert 
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test_MissingNumberInRowSudoku()
        {
            //arrange 
            var missingNumberRowBoard = new List<List<int>>
            {
                new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9},
                new List<int>{4, 5, 6, 7, 8, 9, 1, 2, 3},
                new List<int>{7, 8, 9, 1, 2, 3, 4, 5, 0}, // 0 instead of 6 
                new List<int>{2, 3, 4, 5, 6, 7, 8, 9, 1},
                new List<int>{5, 6, 7, 8, 9, 1, 2, 3, 4},
                new List<int>{8, 9, 1, 2, 3, 4, 5, 6, 7},
                new List<int>{3, 4, 5, 6, 7, 8, 9, 1, 2},
                new List<int>{6, 7, 8, 9, 1, 2, 3, 4, 5},
                new List<int>{9, 1, 2, 3, 4, 5, 6, 7, 8}
            };
            var expectedResult = "Row 3 is erroneous.";

            //act 
            var result = SudokuChecker.Program.CheckSudoku(missingNumberRowBoard);

            //assert 
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test_EmptyRowSudoku()
        {
            //arrange 
            var emptyRowBoard = new List<List<int>>
            {
                new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9},
                new List<int>{4, 5, 6, 7, 8, 9, 1, 2, 3},
                new List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6},
                new List<int>{2, 3, 4, 5, 6, 7, 8, 9, 1},
                new List<int>{5, 6, 7, 8, 9, 1, 2, 3, 4},
                new List<int>{8, 9, 1, 2, 3, 4, 5, 6, 7},
                new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0}, // row 7 is all 0 
                new List<int>{6, 7, 8, 9, 1, 2, 3, 4, 5},
                new List<int>{9, 1, 2, 3, 4, 5, 6, 7, 8}
            };
            var expectedResult = "Row 7 is erroneous.";

            //act 
            var result = SudokuChecker.Program.CheckSudoku(emptyRowBoard);

            //assert 
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Test_NotFullSudoku()
        {
            //arrange 
            var duplicateInSectionBoard = new List<List<int>>
            {
                new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9},
                new List<int>{4, 5, 6, 7, 8, 9, 1, 2, 3},
                new List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6},                
            };
            var expectedResult = "Row 4 is erroneous.";

            //act 
            var result = SudokuChecker.Program.CheckSudoku(duplicateInSectionBoard);

            //assert 
            Assert.AreEqual(expectedResult, result);
        }
    }
}