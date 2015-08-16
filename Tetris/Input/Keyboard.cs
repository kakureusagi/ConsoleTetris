using System;

namespace Tetris.Input {
	public class Keyboard : IInput {

		private ConsoleKeyInfo keyInfo;



		public void Update() {
			if (Console.KeyAvailable) {
				keyInfo = Console.ReadKey(true);
			}
			else {
				keyInfo = new ConsoleKeyInfo();
			}
		}

		public bool left {
			get {
				return keyInfo.Key == ConsoleKey.LeftArrow;
			}
		}

		public bool right {
			get {
				return keyInfo.Key == ConsoleKey.RightArrow;
			}
		}

		public bool up {
			get {
				return keyInfo.Key == ConsoleKey.UpArrow;
			}
		}

		public bool down {
			get {
				return keyInfo.Key == ConsoleKey.DownArrow;
			}
		}

		public bool leftRotation {
			get {
				return keyInfo.Key == ConsoleKey.Z;
			}
		}

		public bool rightRotation {
			get {
				return keyInfo.Key == ConsoleKey.X;
			
			}
		}

		public bool finish {
			get {
				return keyInfo.Key == ConsoleKey.Escape;
			}
		}
	}
}

