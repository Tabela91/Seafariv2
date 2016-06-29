using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class registrationController : MonoBehaviour 
{
	public InputField emailInputField;
	public InputField nameInputField;

	string inputEmail;
	string inputName;

    public string url;

	void Start()
	{
		nameInputField.text = "Enter Name...";
		emailInputField.text = "Enter Email...";
	}

	public void GoToSomethingElse () {
		inputName = nameInputField.text;
		inputEmail = emailInputField.text;

		StartCoroutine (CheckData ());
	}

	IEnumerator CheckData ()
	{

		inputEmail = WWW.EscapeURL (inputEmail);
        string submitUrl = string.Format(url, inputName, inputEmail);

		WWW getData = new WWW (submitUrl);
		yield return getData;
		string webtext = getData.text;

        State myState = JsonUtility.FromJson<State>(webtext);
        
        if (myState.can_play == 1)
        {
            print("Welcome to Seafari!");
        }
        else
        {
            print("You played today dumbass.");
        }
		
    }
}