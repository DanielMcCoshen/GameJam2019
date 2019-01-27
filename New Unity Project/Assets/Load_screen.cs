using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Load_screen : MonoBehaviour {

	public void LoadByIndex()
	{
		SceneManager.LoadScene ("Main Game");
	}
}