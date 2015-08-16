using System;
using Tetris.Input;
using Tetris.View;

//namespace Tetris {
//	public class GameManager {
//
//		private IInput input;
//		private GameModel model;
//		private View.View view;
//
//
//		public GameManager() {
//			input = new Keyboard();
//			model = new GameModel();
//			view = new View.View();
//		}
//
//		public bool Update() {
//			input.Update();
//			if (input.finish) {
//				return false;
//			}
//
//			//update model
//			CellColor[,] cellColors = model.Update(input);
//
//			//update view
//			view.Refresh(cellColors);
//
//			return true;
//		}
//	}
//}

