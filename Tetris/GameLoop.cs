using System;
using System.Threading;
using Tetris.Input;
using Tetris.View;
using Tetris.Scene;

namespace Tetris {
	public class GameLoop {

		public void Run() {
			IInput input = new Keyboard();
			IScene scene = new StartScene();

			try {
				while (true) {
					input.Update();
					scene = scene.Update(input);
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

