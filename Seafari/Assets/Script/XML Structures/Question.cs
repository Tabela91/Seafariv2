using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot ("question")]
public class Question {

	[XmlAttribute ("value")]
    public string question;

	[XmlAttribute ("correct")]
	public string correct;

	[XmlArray ("answers"),XmlArrayItem ("answer")]
	public List <Answer> answers;

}
