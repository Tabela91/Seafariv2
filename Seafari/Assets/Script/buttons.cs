using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void forwardButton () {
		SceneManager.LoadScene (1);
	}
	public void highscoreButtons () {
		SceneManager.LoadScene  (4);
	}
	public void backbutton () {
		SceneManager.LoadScene (1);
	}
	public void level1 () {
		SceneManager.LoadScene (2);
	}
	public void level2 () {
		SceneManager.LoadScene (3);
	}
	public void backToMain () {
		SceneManager.LoadScene (0);
	}
}
