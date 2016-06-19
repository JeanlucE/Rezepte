using UnityEngine;
using System.Collections;

public class Pflanze : MonoBehaviour {

    private GrowthState state = GrowthState.ONE;

    public enum GrowthState
    {
        ONE, TWO, THREE
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
