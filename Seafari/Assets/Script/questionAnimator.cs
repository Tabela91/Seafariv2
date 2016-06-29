using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class questionAnimator : MonoBehaviour {

	private Animator _animator;

	void Awake () {

		_animator = GetComponent <Animator> ();

	}

	 void Update()
	{
		if (_animator.GetCurrentAnimatorStateInfo(0).IsName("questionIntro"))
		{
			_animator.SetBool("toOutro1",false);
		}
			
	}

	public void answers(){
		_animator.SetBool("toOutro1",true);
	}

	public void ansButton () {
		answers ();
	}

	public void ResetAnimation () {

		_animator.SetTrigger ("reset");
        GameObject.FindObjectOfType<UIManager>().LoadNextQuestion();


    }
	
}
