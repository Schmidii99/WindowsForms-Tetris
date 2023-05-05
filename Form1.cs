using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed


namespace Tetris
{
    public partial class Form1 : Form
    {
        private readonly Image[] tileImages = new Image[]
        {
            Properties.Resources.TileEmpty,
            Properties.Resources.TileCyan,
            Properties.Resources.TileBlue,
            Properties.Resources.TileOrange,
            Properties.Resources.TileYellow,
            Properties.Resources.TileGreen,
            Properties.Resources.TilePurple,
            Properties.Resources.TileRed
        };

        private readonly Image[] blockImages = new Image[]
        {
            Properties.Resources.Block_Empty,
            Properties.Resources.Block_I,
            Properties.Resources.Block_J,
            Properties.Resources.Block_L,
            Properties.Resources.Block_O,
            Properties.Resources.Block_S,
            Properties.Resources.Block_T,
            Properties.Resources.Block_Z
        };

        private readonly Image[] ghostImages = new Image[]
        {
            Properties.Resources.TileEmpty,
            Properties.Resources.GhostTileCyan,
            Properties.Resources.GhostTileBlue,
            Properties.Resources.GhostTileOrange,
            Properties.Resources.GhostTileYellow,
            Properties.Resources.GhostTileGreen,
            Properties.Resources.GhostTilePurple,
            Properties.Resources.GhostTileRed
        };

        private PictureBox[,] imageControls;
        

        private GameState gameState = new GameState();

        public Form1()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.GameGrid);

            lbl_nextBlock.BackColor = Color.Transparent;
            lbl_score.BackColor = Color.Transparent;
            pB_nextBlock.BackColor = Color.Transparent;

            // Spiel starten
            GameLoop();
       }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Left:
                    gameState.MoveBlockLeft();
                    break;
                case Keys.Right:
                    gameState.MoveBlockRight();
                    break;
                case Keys.Down:
                    gameState.MoveBlockDown();
                    break;
                case Keys.Space:
                    gameState.DropBlock();
                    break;
                // Rotation
                case Keys.Up:
                    gameState.RotateBlockCW();
                    break;
                case Keys.Z:
                    gameState.RotateBlockCCW();
                    break;

            }
            Draw(gameState);
        }

        private PictureBox[,] SetupGameCanvas(GameGrid grid)
        {
            PictureBox[,] pictureBoxes = new PictureBox[grid.Rows, grid.Columns];
            int cellSize = 40;

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    PictureBox picBox = new PictureBox()
                    {
                        Top = r * cellSize,
                        Left = c * cellSize,
                        Width = cellSize,
                        Height = cellSize,
                        Image = tileImages[0],
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    Canvas.Controls.Add(picBox);
                    pictureBoxes[r, c] = picBox;
                }
            }

            return pictureBoxes;
        }

        #region Drawing
        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePositions())
            {
                imageControls[p.Row, p.Column].Image = tileImages[block.Id];
            }
        }
        private void DrawNextBlock(BlockQueue blockQueue)
        {
            Block nextBlock = blockQueue.NextBlock;
            pB_nextBlock.Image = blockImages[nextBlock.Id];
        }
        private void DrawGhostBlock(Block block)
        {
            int dropDistance = gameState.BlockDropDistance();

            foreach (Position pos in block.TilePositions())
            {
                imageControls[pos.Row + dropDistance, pos.Column].Image = ghostImages[block.Id];
            }
        }
        private void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Image = tileImages[id];
                }
            }
        }
        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.GameGrid);
            DrawGhostBlock(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.BlockQueue);

            lbl_score.Text = $"Score: {gameState.Score}";
        }

        #endregion

        private int maxDelay = 1000;
        private int minDelay = 75;
        private int delayDecrease = 25;
        private async Task GameLoop()
        {
            // neues GameState Object erzeugen
            gameState = new GameState();
            Draw(gameState);

            while (!gameState.GameOver)
            {
                int delay = Math.Max(minDelay, maxDelay - (gameState.Score * delayDecrease));
                await Task.Delay(delay);
                gameState.MoveBlockDown();
                Draw(gameState);
            }

            // Wenn die Schleife zu ende ist ist das Spiel vorbei
            GameOver();
        }

        private void GameOver()
        {
            MessageBox.Show("GameOver!");
            // Spiel neu starten
            GameLoop();
        }
    }
}
