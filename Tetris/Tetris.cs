using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris {
	class Tetris {
		public static void Main(string[] args) {
			new GameLoop().Run();
		}
	}
}
