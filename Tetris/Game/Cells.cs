using System;
using System.Linq;
using System.Collections.Generic;

namespace Tetris.Game {
	public class Cells {

		private const int WiDTH = 8;
		private const int HEIGHT = 12;

		public readonly CellColor[,] cellColors;

		public Cells() {
			cellColors = CreateEmptyCellColors();
		}

		/// <summary>
		/// 現在のテトリミノをマスに反映させられるかどうか.
		/// </summary>
		/// <returns><c>true</c> if this instance is reflection the specified tetrimino; otherwise, <c>false</c>.</returns>
		/// <param name="tetrimino">Tetrimino.</param>
		public bool IsReflection(Tetrimino tetrimino) {
			//境界チェック.
			if (tetrimino.validLeft < 0 || tetrimino.vaildRight >= WiDTH || tetrimino.validTop < 0 || tetrimino.validBottom >= HEIGHT) {
				return false;
			}

			//既存のセルとぶつかるかどうか.
			for (int tetriminoX = 0 ; tetriminoX < tetrimino.width ; ++tetriminoX) {
				for (int tetriminoY = 0 ; tetriminoY < tetrimino.height ; ++tetriminoY) {
					int x = tetrimino.leftTopX + tetriminoX;
					int y = tetrimino.leftTopY + tetriminoY;
					if (x < 0 || x >= WiDTH || y < 0 || y >= HEIGHT) {
						continue;
					}

					if (tetrimino.colors[tetriminoX, tetriminoY] != CellColor.Empty && cellColors[x, y] != CellColor.Empty) {
						return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// 現在のテトリミノの情報をマスにかきこむ.
		/// </summary>
		/// <param name="tetrimino">Tetrimino.</param>
		public void Reflect(Tetrimino tetrimino) {
			Reflect(cellColors, tetrimino);
		}

		private void Reflect(CellColor[,] colors, Tetrimino tetrimino) {
			for (int tetriminoX = 0 ; tetriminoX < tetrimino.width ; ++tetriminoX) {
				for (int tetriminoY = 0 ; tetriminoY < tetrimino.height ; ++tetriminoY) {
					int x = tetrimino.leftTopX + tetriminoX;
					int y = tetrimino.leftTopY + tetriminoY;
					if (x < 0 || x >= WiDTH || y < 0 || y >= HEIGHT) {
						continue;
					}

					if (tetrimino.colors[tetriminoX, tetriminoY] != CellColor.Empty) {
						colors[x, y] = tetrimino.colors[tetriminoX, tetriminoY];
					}
				}
			}
		}

		public void DeleteLine() {
			for (int y = 0 ; y < HEIGHT ; ++y) {
				if (!GetLine(y).Any(c => c == CellColor.Empty)) {
					ShiftLine(y);
				}
			}
		}

		private void ShiftLine(int deleteY) {
			for (int x = 0 ; x < WiDTH ; ++x) {
				for (int y = deleteY ; y >= 1 ; --y) {
					cellColors[x, y] = cellColors[x, y - 1];
				}
			}
			for (int x = 0 ; x < WiDTH ; ++x) {
				cellColors[x, 0] = CellColor.Empty;
			}
		}

		/// <summary>
		/// 現在のテトリミノの情報をマス全体に書き込むことなく、結合した状態を取得する.
		/// </summary>
		/// <param name="tetrimino">Tetrimino.</param>
		public CellColor[,] Merge(Tetrimino tetrimino) {
			CellColor[,] colors = CreateEmptyCellColors();
			for (int x = 0 ; x < WiDTH ; ++x) {
				for (int y = 0 ; y < HEIGHT ; ++y) {
					colors[x, y] = cellColors[x, y];
				}
			}

			Reflect(colors, tetrimino);
			return colors;
		}

		private CellColor[,] CreateEmptyCellColors() {
			CellColor[,] colors = new CellColor[WiDTH, HEIGHT];
			for (int x = 0 ; x < WiDTH ; ++x) {
				for (int y = 0 ; y < HEIGHT ; ++y) {
					colors[x, y] = CellColor.Empty;
				}
			}
			return colors;
		}

		private List<CellColor> GetLine(int y) {
			if (y < 0 || y >= HEIGHT) {
				throw new Exception("範囲外のラインを取得しようとしています。 y=" + y);
			}

			List<CellColor> line = new List<CellColor>(WiDTH);
			for (int x = 0 ; x < WiDTH ; ++x) {
				line.Add(cellColors[x, y]);
			}
			return line;
		}
	}
}

