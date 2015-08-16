using System;
using Tetris.View;
using Tetris.Input;

namespace Tetris.Scene {
	public class StartScene : IScene {

		private readonly SceneSwitcher sceneSwitcher;
		private readonly StartView view;
		private readonly IInput input;

		public StartScene(SceneSwitcher sceneSwitcher, IInput input) {
			this.sceneSwitcher = sceneSwitcher;
			this.input = input;
			view = new StartView();
		}

		public void Update() {
			if (input.finish) {
				sceneSwitcher.SwitchTo(SceneSwitcher.Scene.End);
			}

			if (input.leftRotation) {
				sceneSwitcher.SwitchTo(SceneSwitcher.Scene.Game);
			}

			view.Refresh();
		}

		public bool IsApplicationFinish() {
			return false;
		}
	}
}

