using System;
using System.Text;
using Tetris.Game;

namespace Tetris.View {
	public class GameView {

		private StringBuilder buffer;

		public void Refresh(CellColor[,] cellColors) {
			StringBuilder tempBuffer = new StringBuilder();

			for (int y = 0 ; y < cellColors.GetLength(1) ; ++y) {
				for (int x = 0 ; x < cellColors.GetLength(0) ; ++x)  {
					CellColor color = cellColors[x, y];
					if (color == CellColor.Empty) {
						tempBuffer.Append("□");
					}
					else if (color == CellColor.White) {
						tempBuffer.Append("■");
					}
				}
				tempBuffer.Append("\n");
			}

			if (buffer == null) {
				buffer = tempBuffer;
			}
			else {
				if (buffer.ToString() == tempBuffer.ToString()) {
					return;
				}
				buffer = tempBuffer;
			}

			Console.Clear();
			Console.WriteLine(buffer);
		}
	}
}

