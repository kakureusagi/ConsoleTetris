using System;
using Tetris.Input;
using Tetris.Game;
using Tetris.View;

namespace Tetris.Scene {

	/// <summary>
	/// テトリス部分のシーン担当.
	/// </summary>
	public class GameScene : IScene {

		private readonly GameController gameController;
		private readonly GameView gameView;

		public GameScene() {
			gameController = new GameController();
			gameView = new GameView();
		}

		public IScene Update(IInput input) {
			if (input.finish) {
				return new EndScene();
			}

			gameController.Update(input);
			if (gameController.isGameOver) {
				return new EndScene();
			}

			gameView.Refresh(gameController.cellColors);
			return this;
		}

		public bool IsApplicationFinish() {
			return false;
		}
	}
}

