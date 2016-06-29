using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using System.Collections;

public class GameController : MonoSingleton <GameController> {

	#region Variables
	// public PlayerData playerData;

	QuestionCollection questionCollection;
	#endregion


	#region Events
	protected override void AwakeEx () {

		LoadQuestions ();


	}
	#endregion


	#region Methods
	void LoadQuestions () {

		var serializer = new XmlSerializer (typeof(QuestionCollection));
		var stream = new FileStream (Path.Combine (Application.dataPath, "data.xml"), FileMode.Open);
		questionCollection = serializer.Deserialize (stream) as QuestionCollection;
		stream.Close ();

	}

	public List <Question> GetSessionQuestions () {

		return questionCollection.GetQuestions (10); // this changes to 10 in the final version

	}
	#endregion

}
