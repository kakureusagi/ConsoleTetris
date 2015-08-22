using System;
using Tetris.Input;
using Tetris.View;

namespace Tetris.Scene {

	/// <summary>
	/// ゲームの終了シーン担当.
	/// </summary>
	public class EndScene : IScene {

		private readonly EndView view;

		private bool applicationFinish;

		public EndScene() {
			view = new EndView();
		}

		public IScene Update(IInput input) {
			applicationFinish = input.finish;
			view.Refresh();
			return this;
		}

		public bool IsApplicationFinish() {
			return applicationFinish;
		}
	}
}

