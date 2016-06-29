using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractiveButton : MonoBehaviour {

	static Color wrongColor = new Color (1f, 0f, 0f, 0.5f);
	static Color rightColor = new Color (0f, 1f, 0f, 0.5f);
	static Color normalColor = new Color (1f, 1f, 1f, 0.75f);

	private Text _text;
	private Image _buttonImage;

	private bool isCorrect = false;


	void Awake () {
		_text = GetComponentInChildren <Text> ();
		_buttonImage = GetComponent <Image> ();
	}


	public void SetCorrect (bool correct) {
		
		isCorrect = correct;
	
	}


	public void Highlight () {

		_buttonImage.color = (isCorrect) ? rightColor : wrongColor;

	}


	public void SetText (string s) {

		_text.text = s;

	}


	public void Reset () {

		_buttonImage.color = normalColor;

	}

}
