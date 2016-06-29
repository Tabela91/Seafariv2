using UnityEngine;
using System.Collections;

//This script generates a flock of fish
public class globalFlock : MonoBehaviour {

    public GameObject fishPrefab;
   // public GameObject goalPrefab;
    public static int tankSize = 4;//controls the volume within which the fish spawn

    static int numFish = 50; //controls the number of generated fish
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start ()
    {//adds fog to scene
        RenderSettings.fogColor = Camera.main.backgroundColor;
        RenderSettings.fogDensity = 0.04f;
        RenderSettings.fog = true;

        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-tankSize, tankSize),
                                                                 Random.Range(-tankSize, tankSize),
                                                                     Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos,Quaternion.identity);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if(Random.Range (0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                                  Random.Range(-tankSize, tankSize),
                                  Random.Range(-tankSize, tankSize));
            //goalPrefab.transform.position = goalPos;
        }
	
	}
}
