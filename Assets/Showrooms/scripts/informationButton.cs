using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class informationButton : MonoBehaviour {


	public void OnInfoIsPushed(){
		GameObject obj = this.gameObject.transform.GetChild(0).gameObject;
		obj.SetActive(!obj.activeSelf);
	}
}


