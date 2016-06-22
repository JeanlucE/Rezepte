using UnityEngine;
using System.Collections;

public class Singelten : MonoBehaviour {
    public static Singelten gameControl;
    // Use this for initialization
    void Start() {
        if (gameControl == null)
        {
            DontDestroyOnLoad(gameObject);
            gameControl = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
	// Update is called once per frame
	void Update () {
	
	}
}
