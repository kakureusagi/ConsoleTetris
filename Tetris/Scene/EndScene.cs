using System;
using Tetris.Input;
using Tetris.View;

namespace Tetris.Scene {
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

