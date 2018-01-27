using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameSceneManager : MonoBehaviour {

	public GameObject game1;
	public GameObject game2;
	public GameObject game3;

	void OnLevelWasLoaded(){
		print (Scenes.parameter);
		if (Scenes.parameter == 1)
			game1.gameObject.SetActive (true);
		if (Scenes.parameter == 2)
			game2.gameObject.SetActive (true);
		if (Scenes.parameter == 3)
			game3.gameObject.SetActive (true);
	}


	public void OnInfoIsPushed(){
		GameObject obj = this.gameObject.transform.GetChild(0).gameObject;
		obj.SetActive(!obj.activeSelf);
	}
}


