using System.Xml;
using System.Xml.Serialization;

[XmlRoot ("answer")]
public class Answer
{
	[XmlAttribute ("value")]
    public string answer;
}