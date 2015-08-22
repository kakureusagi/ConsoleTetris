using System;
using System.Collections.Generic;

namespace Tetris.Game {

	/// <summary>
	/// テトリミノの生成担当.
	/// </summary>
	public class TetriminoGenerator {

		private static readonly List<CellColor[,]> patterns = new List<CellColor[,]> {
			new CellColor[2, 2] {
				{CellColor.White, CellColor.White,},
				{CellColor.White, CellColor.White,},
			},
			new CellColor[4, 4] {
				{CellColor.Empty, CellColor.White, CellColor.Empty, CellColor.Empty},
				{CellColor.Empty, CellColor.White, CellColor.Empty, CellColor.Empty},
				{CellColor.Empty, CellColor.White, CellColor.Empty, CellColor.Empty},
				{CellColor.Empty, CellColor.White, CellColor.Empty, CellColor.Empty},
			},
			new CellColor[3, 3] {
				{CellColor.Empty, CellColor.White, CellColor.Empty},
				{CellColor.White, CellColor.White, CellColor.White},
				{CellColor.Empty, CellColor.Empty, CellColor.Empty},
			},
			new CellColor[3, 3] {
				{CellColor.White, CellColor.Empty, CellColor.Empty},
				{CellColor.White, CellColor.White, CellColor.White},
				{CellColor.Empty, CellColor.Empty, CellColor.Empty},
			},
			new CellColor[3, 3] {
				{CellColor.Empty, CellColor.Empty, CellColor.White},
				{CellColor.White, CellColor.White, CellColor.White},
				{CellColor.Empty, CellColor.Empty, CellColor.Empty},
			},
			new CellColor[3, 3] {
				{CellColor.White, CellColor.Empty, CellColor.Empty},
				{CellColor.White, CellColor.White, CellColor.Empty},
				{CellColor.Empty, CellColor.White, CellColor.Empty},
			},
			new CellColor[3, 3] {
				{CellColor.Empty, CellColor.Empty, CellColor.White},
				{CellColor.Empty, CellColor.White, CellColor.White},
				{CellColor.Empty, CellColor.White, CellColor.Empty},
			},
		};

		public static Tetrimino CreateRandomTetrimino() {
			int random = new Random().Next(patterns.Count);
			return new Tetrimino(2, 0, patterns[random]);
		}

		public static Tetrimino Copy(Tetrimino tetrimino) {
			return new Tetrimino(tetrimino);
		}
	}
}

