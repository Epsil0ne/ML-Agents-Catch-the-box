using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scenarioSceneManager : MonoBehaviour {

	public GameObject scenario1;
	public GameObject scenario2;
	public GameObject scenario3;

	void OnLevelWasLoaded(){
		print (Scenes.parameter);
		if (Scenes.parameter == 1)
			scenario1.gameObject.SetActive (true);
		if (Scenes.parameter == 2)
			scenario2.gameObject.SetActive (true);
		if (Scenes.parameter == 3)
			scenario3.gameObject.SetActive (true);
	}


	public void OnInfoIsPushed(){
		GameObject obj = this.gameObject.transform.GetChild(0).gameObject;
		obj.SetActive(!obj.activeSelf);
	}
}


