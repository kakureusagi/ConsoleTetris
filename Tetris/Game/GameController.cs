using System;
using System.Threading.Tasks;
using System.Threading;
using Tetris.Input;


namespace Tetris.Game {
	public class GameController {

		private const double AUTO_BOTTOM_SHIFT_MILLISECONDS = 1000;
		
		public Cells cells { get ; private set; }
		public CellColor[,] cellColors {
			get {
				return cells.Merge(currentTetrimino);
			}
		}
		public bool isGameOver { get; private set; }

		private Tetrimino currentTetrimino;
		private DateTime time;


		public GameController() {
			cells = new Cells();
			currentTetrimino = TetriminoGenerator.CreateRandomTetrimino();
			time = DateTime.Now;
		}

		public void Update(IInput input) {
			bool autoBottomShift = false;
			double timeFromDown = (DateTime.Now - time).TotalMilliseconds;
			if (timeFromDown >= AUTO_BOTTOM_SHIFT_MILLISECONDS) {
				autoBottomShift = true;
				time = DateTime.Now;
			}

			if (input.leftRotation) {
				Tetrimino copy = TetriminoGenerator.Copy(currentTetrimino);
				copy.RotateLeft();
				if (cells.IsReflection(copy)) {
					currentTetrimino = copy;
				}
			}
			if (input.rightRotation) {
				Tetrimino copy = TetriminoGenerator.Copy(currentTetrimino);
				copy.RotateRight();
				if (cells.IsReflection(copy)) {
					currentTetrimino = copy;
				}
			}
			if (input.left) {
				Tetrimino copy = TetriminoGenerator.Copy(currentTetrimino);
				copy.MoveLeft();
				if (cells.IsReflection(copy)) {
					currentTetrimino = copy;
				}
			}
			if (input.right) {
				Tetrimino copy = TetriminoGenerator.Copy(currentTetrimino);
				copy.MoveRight();
				if (cells.IsReflection(copy)) {
					currentTetrimino = copy;
				}
			}
			if (input.down || autoBottomShift) {
				Tetrimino copy = TetriminoGenerator.Copy(currentTetrimino);
				copy.MoveDown();
				if (cells.IsReflection(copy)) {
					currentTetrimino = copy;
				}
				else {
					//固定.
					cells.Reflect(currentTetrimino);
					currentTetrimino = TetriminoGenerator.CreateRandomTetrimino();
					if (!cells.IsReflection(currentTetrimino)) {
						isGameOver = true;
					}
					time = DateTime.Now;
				}
			}

			cells.DeleteLine();
		}
	}
}

