using UnityEngine;
using System.Collections;

public class MonoSingleton <T> : MonoBehaviour where T : MonoSingleton <T> {

	#region Private Variables
	private static T _instance;
	#endregion


	#region Getters and Setters
	public static T Instance {
		get {
			return _instance;
		}
	}
	#endregion


	#region Methods
	void Awake () {

		if (_instance != null) {
			DestroyImmediate (this.gameObject);
		} else {
			_instance = this as T;
			DontDestroyOnLoad (this.gameObject);
			AwakeEx ();
		}

	}

	void OnDestroy () {
		OnDestroyEx ();
		if (_instance == this) _instance = null;
	}

	protected virtual void AwakeEx () { }
	protected virtual void OnDestroyEx () { }
	#endregion

}
