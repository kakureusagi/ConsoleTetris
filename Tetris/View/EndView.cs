using System;

namespace Tetris.View {

	/// <summary>
	/// ゲーム終了シーンの描画担当.
	/// </summary>
	public class EndView {

		private bool print;

		public void Refresh() {
			if (print) return;
			print = true;

			Console.Clear();
			Console.WriteLine("再度Escキーを押すとアプリを終了します。");
		}
	}
}

