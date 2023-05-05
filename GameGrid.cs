using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        // Diese Funktion sorgt dafür das folgende Operationen auf dem GameGrid object ausgeführt werden können
        // Bsp:
        // GameGrid Spielfeld = new GameGrid();
        // Spielfeld[0, 0] = ...
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        // Konstruktor des Spielfeldes
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        // Diese Funktion überprüft ob sich ein Wert in dem Spielfeld befindet
        public bool IsInside(int row, int column)
        {
            return row >= 0 && row < this.Rows && column >= 0 && column < this.Columns;
        }

        // Diese Funktion überprüft ob ein Feld im Spielfeld und leer ist
        public bool IsEmpty(int row, int column)
        {
            // ist im "grid"-array der Wert auf 0 so ist dieses Feld leer
            return IsInside(row, column) && this.grid[row, column] == 0;
        }

        public bool IsRowFull(int row)
        {
            for (int column = 0; column < this.Columns; column++)
            {
                if (this.grid[row, column] == 0)
                {
                    // Wird ein leeres Feld gefunden so wird die Schleife abgebrochen und false zurückgegeben
                    return false;
                }
            }

            // Wurde die Schleife nicht abgebrochen so wird true zurückgegeben
            return true;
        }

        public bool IsRowEmpty(int row)
        {
            for (int column = 0; column < this.Columns; column++)
            {
                if (this.grid[row, column] != 0)
                {
                    // Wird ein volles Feld gefunden so wird die Schleife abgebrochen und false zurückgegeben
                    return false;
                }
            }

            // Wurde die Schleife nicht abgebrochen so wird true zurückgegeben
            return true;
        }

        private void ClearRow(int row)
        {
            for (int column = 0; column < this.Columns; column++)
            {
                this.grid[row, column] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}
