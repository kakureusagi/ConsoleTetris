
using System;

namespace Tetris.View {
	public class StartView {

		private bool print;

		public void Refresh() {
			if (print) return;
			print = true;

			Console.Clear();
			Console.WriteLine("Zキーを押すとテトリスがスタートします。");
			Console.WriteLine("");
			Console.WriteLine("操作方法");
			Console.WriteLine("十字キー：　テトリミノの移動");
			Console.WriteLine("Z：　テトリミノの左回転");
			Console.WriteLine("S：　テトリミノの右回転");
			Console.WriteLine("Esc：　アプリの終了");
		}
	}
}

