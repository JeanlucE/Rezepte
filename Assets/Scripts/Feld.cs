using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Feld : MonoBehaviour {

    //static list of all fields
    public static List<Feld> AllFelder;

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
        if(AllFelder == null)
        {
            AllFelder = new List<Feld>();
        }

        AllFelder.Add(this);
        

        if (Overgrown)
        {
            state = State.Overgrown;
            //set sprite of overgrown field
            GetComponent<Image>().sprite = OvergrownSprite;
            DebugText("$" + CostToClear);
        }
        else
        {
            state = State.Free;
            //set sprite of free field
            GetComponent<Image>().sprite = FreeSprite;
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
                        pflanze.SetImage(this.gameObject);
                        DebugText(pflanze.GetDebugText() + " " + (int)pflanze.GetGrowthStage());
                    }
                }
                else
                {
                    //done growing
                    pflanze.SetImage(this.gameObject);
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
                GetComponent<Image>().sprite = FreeSprite;
                DebugText("Free");
                break;

            case State.Free:
                //center on this field
                PlantSelector.Instance.CenterOn(this);
                //select zutat from selector
                //selector calls Plant(Zutat.ID)
               
                //DebugText(pflanze.GetDebugText() + " " + (int)pflanze.GetGrowthStage());
                break;

            case State.Planted:
                if (pflanze.Done())
                {
                    state = State.Free;
                    GetComponent<Image>().sprite = FreeSprite;
                    //set sprite of free field
                    DebugText("Free");

                    Inventar.Instance.Add(pflanze.GetResult());
                }
                break;
        }
    }

    public Zutat.ID GetZutatID()
    {
        return pflanze.GetZutatID();
    }

    public void Plant(Zutat.ID ID)
    {
        if (state != State.Free)
            return;

        Zutat.ID z = ID;

        pflanze = new Pflanze(z);
        TimeOfNextGrowthStage = Time.time + pflanze.TimeUntilNextState();

        //set sprite of seeded plant
        pflanze.SetImage(this.gameObject);

        state = State.Planted;
    }

    private void DebugText(string content)
    {
        Text t = GetComponentInChildren<Text>();
        if (t)
            t.text = "";
    }
}
