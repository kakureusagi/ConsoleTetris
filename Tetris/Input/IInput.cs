using System;

namespace Tetris.Input {

	/// <summary>
	/// 入力担当.
	/// </summary>
	public interface IInput {
		void Update();

		bool left { get; }
		bool right{ get; }
		bool up { get; }
		bool down {get; }

		bool leftRotation { get; }
		bool rightRotation { get; }

		bool finish { get; }
	}
}
