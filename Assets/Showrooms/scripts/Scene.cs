using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scenes {

	public static int parameter;

	public static void Load(string sceneName, int p = -1) {
		Scenes.parameter = p;
		SceneManager.LoadScene(sceneName);
	}

}

