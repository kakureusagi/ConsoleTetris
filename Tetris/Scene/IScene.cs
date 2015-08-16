using System;

namespace Tetris.Scene {
	public interface IScene {
		void Update();
		bool IsApplicationFinish();
	}
}

