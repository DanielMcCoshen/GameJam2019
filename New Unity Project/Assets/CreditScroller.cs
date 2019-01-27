using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditScroller : MonoBehaviour {

	public Text Text;

	public float Shift = 300;
	public float Duration = 3;

	// Use this for initialization
	IEnumerator Start ()
	{
		var elapsedTime = 0F;
		var startingPos = Text.transform.position;
		var newPosition = startingPos + new Vector3 (0, Shift, 0);

		while (elapsedTime < Duration)
		{
			Text.transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / Duration));
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		// GOTO: Zero Scene
		SceneManager.LoadScene(0);
	}
}
