using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class taskSceneManager : MonoBehaviour {

	public GameObject task1;
	public GameObject task2;
	public GameObject task3;

	void OnLevelWasLoaded(){
		print (Scenes.parameter);
		if (Scenes.parameter == 1)
			task1.gameObject.SetActive (true);
		if (Scenes.parameter == 2)
			task2.gameObject.SetActive (true);
		if (Scenes.parameter == 3)
			task3.gameObject.SetActive (true);
	}


	public void OnInfoIsPushed(){
		GameObject obj = this.gameObject.transform.GetChild(0).gameObject;
		obj.SetActive(!obj.activeSelf);
	}
}


