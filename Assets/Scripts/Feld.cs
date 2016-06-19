using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Feld : MonoBehaviour {

    public float CostToClear;
    public bool Overgrown;
    public Sprite OvergrownSprite;
    public Sprite FreeSprite;


    private State state;

    public enum State
    {
        Overgrown, Free, Planted
    }

	// Use this for initialization
	void Start () {
        if (Overgrown)
        {
            state = State.Overgrown;
            DebugText("$" + CostToClear);
        }
        else
        {
            state = State.Free;
            DebugText("Free");
        }

       
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        switch (state)
        {
            case State.Overgrown:
                Overgrown = false;
                Inventar.Instance.ChangeMoney(-CostToClear);
                state = State.Free;

                DebugText("Free");
                break;

            case State.Free:
                Plant();
                state = State.Planted;

                DebugText("Planted");
                break;
        }
    }

    private void Plant()
    {

    }

    private void DebugText(string content)
    {
        Text t = GetComponentInChildren<Text>();
        if (t)
            t.text = content;
    }
}
