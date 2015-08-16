using System;
using System.Text;
using Tetris.Game;

namespace Tetris.View {
	public class View {
		public View() {
		}

		public void Refresh(CellColor[,] cellColors) {
			Console.Clear();

			StringBuilder builder = new StringBuilder();
			for (int y = 0 ; y < cellColors.GetLength(1) ; ++y) {
				for (int x = 0 ; x < cellColors.GetLength(0) ; ++x)  {
					CellColor color = cellColors[x, y];
					if (color == CellColor.Empty) {
						Console.Write("□");
					}
					else if (color == CellColor.White) {
						Console.Write("■");
					}
				}
				Console.Write("\n");
			}
		}

		public void ShowGameEndMessage() {
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("何かキーを押すとアプリを終了します。");
			Console.ReadKey();
		}
	}
}

