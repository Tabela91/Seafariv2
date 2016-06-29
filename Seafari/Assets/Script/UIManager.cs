using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	[SerializeField]
	private Text _questionText;

	[SerializeField]
	private InteractiveButton[] _answers;

   
	private List <Question> _questions;
	private int index = 0;
    
    void Awake ()
    {
        if (GameController.Instance == null)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    void Start () {
        _questions = GameController.Instance.GetSessionQuestions ();
		Prepare ();
        
    }
    
    void Prepare () {

        print(index);

        List<int> indexes = new List<int>();
        for (int i = 0; i < _answers.Length; ++i)
            indexes.Add(i);

		_questionText.text = _questions [index].question;
		for (int i = 0; i < _questions [index].answers.Count; ++i) {
            int idx = indexes[Random.Range(0, indexes.Count)];
            indexes.Remove(idx);

			_answers [idx].SetText (_questions [index].answers [i].answer);
			_answers [idx].SetCorrect (_questions [index].correct == i.ToString ());
		}

	}


	public void LoadNextQuestion () {

		if (++index >= _questions.Count) {
			// change to the end screen
			return;
		}

        foreach (InteractiveButton ib in _answers)
            ib.Reset();

		Prepare ();

	}

}
