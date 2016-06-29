using UnityEngine;
using System.Collections;

public class GetQA : MonoBehaviour {

    public string url;

    public void Start()
    {
        StartCoroutine(CheckQuestions());
    }

    IEnumerator CheckQuestions()
    {

        WWW getData = new WWW(url);
        yield return getData;
        string webtext = getData.text;

      QuestionCollection questions = JsonUtility.FromJson<QuestionCollection>(webtext);

    }

}
