using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris {

	/// <summary>
	/// エントリポイント.
	/// </summary>
	class Tetris {
		public static void Main(string[] args) {
			new GameLoop().Run();
		}
	}
}
