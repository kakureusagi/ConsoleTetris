using System;
using Tetris.Input;
using Tetris.Game;
using Tetris.View;

namespace Tetris.Scene {
	public class GameScene : IScene {

		private readonly SceneSwitcher sceneSwitcher;
		private readonly IInput input;
		private readonly GameController gameController;
		private readonly GameView gameView;

		public GameScene(SceneSwitcher sceneSwitcher, IInput input) {
			this.sceneSwitcher = sceneSwitcher;
			this.input = input;
			gameController = new GameController(input);
			gameView = new GameView();
		}

		public void Update() {
			if (input.finish) {
				sceneSwitcher.SwitchTo(SceneSwitcher.Scene.End);
				return;
			}

			gameController.Update();
			if (gameController.isGameOver) {
				sceneSwitcher.SwitchTo(SceneSwitcher.Scene.End);
				return;
			}

			gameView.Refresh(gameController.cellColors);
		}

		public bool IsApplicationFinish() {
			return false;
		}
	}
}

