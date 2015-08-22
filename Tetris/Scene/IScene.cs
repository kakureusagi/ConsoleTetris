using System;
using Tetris.Input;

namespace Tetris.Scene {

	/// <summary>
	/// シーンの基本.
	/// </summary>
	public interface IScene {
		IScene Update(IInput input);
		bool IsApplicationFinish();
	}
}

