using System;
using Tetris.Input;

namespace Tetris.Scene {
	public class SceneSwitcher {

		public enum Scene {
			Start,
			Game,
			End,
		}
			
		public IScene currentScene {get; private set;}

		private IInput input;

		public SceneSwitcher(IInput input) {
			this.input = input;
		}

		public void SwitchTo(Scene scene) {
			switch (scene) {
			case Scene.Start:
				currentScene = new StartScene(this, input);
				break;
			case Scene.Game:
				currentScene = new GameScene(this, input);
				break;
			case Scene.End:
				currentScene = new EndScene(input);
				break;
			}
		}
	}
}

