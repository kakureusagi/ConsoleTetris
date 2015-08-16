using System;
using System.Threading;
using Tetris.Input;
using Tetris.View;
using Tetris.Scene;

namespace Tetris {
	public class GameLoop {

		public void Run() {
			IInput input = new Keyboard();
			SceneSwitcher sceneSwitcher = new SceneSwitcher(input);
			sceneSwitcher.SwitchTo(SceneSwitcher.Scene.Start);

			try {
				while (true) {
					input.Update();

					IScene scene = sceneSwitcher.currentScene;
					scene.Update();
					if (scene.IsApplicationFinish()) {
						break;
					}

					Thread.Sleep(33);
				}
			}
			catch (Exception e) {
				Console.WriteLine("エラーが発生しました。：　" + e);
				Console.ReadKey();
			}
		}
	}
}

