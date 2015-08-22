using System;

namespace Tetris.Game {

	/// <summary>
	/// テトリミノ１つ分を管理するクラス.
	/// </summary>
	public class Tetrimino {

		public int leftTopX { get; private set;}

		public int leftTopY { get; private set;}

		public int validLeft {
			get {
				for (int x = 0 ; x < width ; ++x) {
					for (int y = 0 ; y < height ; ++y) {
						if (colors[x, y] != CellColor.Empty) {
							return leftTopX + x;
						}
					}
				}
				return 0;
			}
		}

		public int vaildRight {
			get {
				for (int x = width - 1 ; x >= 0 ; --x) {
					for (int y = 0 ; y < height ; ++y) {
						if (colors[x, y] != CellColor.Empty) {
							return leftTopX + x;
						}
					}
				}
				return 0;
			}
		}

		public int validTop {
			get {
				for (int y = 0 ; y < height ; ++y) {
					for (int x = 0 ; x < width ; ++x) {
						if (colors[x, y] != CellColor.Empty) {
							return leftTopY + y;
						}
					}
				}
				return 0;
			}
		}

		public int validBottom {
			get {
				for (int y = height - 1 ; y >= 0 ; --y) {
					for (int x = 0 ; x < width ; ++x) {
						if (colors[x, y] != CellColor.Empty) {
							return leftTopY + y;
						}
					}
				}
				return 0;
			}
		}

		public int width {
			get {
				return colors.GetLength(0);
			}
		}

		public int height {
			get {
				return colors.GetLength(1);
			}
		}

		public CellColor[,] colors { get; private set; }


		public Tetrimino(int x, int y, CellColor[,] colors) {
			leftTopX = x;
			leftTopY = y;
			this.colors = colors;
		}

		public Tetrimino(Tetrimino original) {
			leftTopX = original.leftTopX;
			leftTopY = original.leftTopY;
			colors = original.colors;
		}

		public void RotateRight() {
			CellColor[,] temp = new CellColor[width, height];
			for (int x = 0 ; x < width ; ++x) {
				for (int y = 0 ; y < height ; ++y) {
					temp[x, y] = colors[y, width - x - 1];
				}
			}
			colors = temp;
		}

		public void RotateLeft() {
			CellColor[,] temp = new CellColor[width, height];
			for (int x = 0 ; x < width ; ++x) {
				for (int y = 0 ; y < height ; ++y) {
					temp[x, y] = colors[height - y - 1, x];
				}
			}
			colors = temp;
		}

		public void MoveLeft() {
			--leftTopX;
		}
		public void MoveRight() {
			++leftTopX;
		}
		public void MoveDown() {
			++leftTopY;
		}
		public void MoveUp() {
			--leftTopY;
		}
	}
}

