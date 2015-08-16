using System;
using Tetris.Input;
using Tetris.View;

namespace Tetris.Scene {
	public class EndScene : IScene {

		private readonly IInput input;
		private readonly EndView view;

		private bool applicationFinish;

		public EndScene(IInput input) {
			this.input = input;
			view = new EndView();
		}

		public void Update() {
			applicationFinish = input.finish;
			view.Refresh();
		}

		public bool IsApplicationFinish() {
			return applicationFinish;
		}
	}
}

