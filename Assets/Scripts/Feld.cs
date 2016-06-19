using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Feld : MonoBehaviour {

    public float CostToClear;
    public bool Overgrown;
    public Sprite OvergrownSprite;
    public Sprite FreeSprite;

    private State state;
    private Pflanze pflanze;
    private float TimeOfNextGrowthStage;

    public enum State
    {
        Overgrown, Free, Planted
    }

	// Use this for initialization
	void Start () {
        if (Overgrown)
        {
            state = State.Overgrown;
            //set sprite of overgrown field
            DebugText("$" + CostToClear);
        }
        else
        {
            state = State.Free;
            //set sprite of free field
            DebugText("Free");
        }

       
    }
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case State.Overgrown:
                break;

            case State.Free:
                break;

            case State.Planted:
                if (!pflanze.Done())
                {
                    if (TimeOfNextGrowthStage <= Time.time)
                    {
                        pflanze.Grow();
                        TimeOfNextGrowthStage = Time.time + pflanze.TimeUntilNextState();
                        //set sprite of appropriate growth stage
                        DebugText(pflanze.GetDebugText() + " " + (int)pflanze.GetGrowthStage());
                    }
                }
                else
                {
                    //done growing
                    DebugText(pflanze.GetDebugText() + " Done");
                }
                break;
        }
    }

    public void OnClick()
    {
        switch (state)
        {
            case State.Overgrown:
                Overgrown = false;
                Inventar.Instance.ChangeMoney(-CostToClear);
                state = State.Free;

                //set sprite of free field
                DebugText("Free");
                break;

            case State.Free:
                Plant();
                state = State.Planted;

                DebugText(pflanze.GetDebugText() + " " + (int)pflanze.GetGrowthStage());
                break;

            case State.Planted:
                if (pflanze.Done())
                {
                    state = State.Free;

                    //set sprite of free field
                    DebugText("Free");
                }
                break;
        }
    }

    private void Plant()
    {
        Zutat.ID[] zutaten = (Zutat.ID[])System.Enum.GetValues(typeof(Zutat.ID));
        Zutat.ID z = zutaten[Random.Range(0, zutaten.Length - 1)];

        pflanze = new Pflanze(z);
        TimeOfNextGrowthStage = Time.time + pflanze.TimeUntilNextState();

        //set sprite of seeded plant
    }

    private void DebugText(string content)
    {
        Text t = GetComponentInChildren<Text>();
        if (t)
            t.text = content;
    }
}
