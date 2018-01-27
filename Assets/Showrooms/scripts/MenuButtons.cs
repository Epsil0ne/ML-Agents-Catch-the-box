using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour {


	public void Task1 () {
		Scenes.Load ("ShowroomTask",1);
	}
	public void Task2 () {
		Scenes.Load ("ShowroomTask",2);
	}
	public void Task3 () {
		Scenes.Load ("ShowroomTask",3);
	}
	public void Scenario1 () {
		Scenes.Load ("ShowroomScenario",1);
	}
	public void Game1 () {
		Scenes.Load ("ShowroomGame",1);
	}
	public void Game2 () {
		Scenes.Load ("ShowroomGame",2);
	}



	public void Quit () {
		Application.Quit ();

	}
}

