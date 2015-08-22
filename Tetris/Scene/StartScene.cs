using System;
using Tetris.View;
using Tetris.Input;

namespace Tetris.Scene {

	/// <summary>
	/// ゲーム開始シーンの描画担当.
	/// </summary>
	public class StartScene : IScene {

		private readonly StartView view;

		public StartScene() {
			view = new StartView();
		}

		public IScene Update(IInput input) {
			if (input.finish) {
				return new EndScene();
			}

			if (input.leftRotation) {
				return new GameScene();
			}

			view.Refresh();
			return this;
		}

		public bool IsApplicationFinish() {
			return false;
		}
	}
}

