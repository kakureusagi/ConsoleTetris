using System;
using Tetris.Input;

namespace Tetris.Scene {
	public interface IScene {
		IScene Update(IInput input);
		bool IsApplicationFinish();
	}
}

