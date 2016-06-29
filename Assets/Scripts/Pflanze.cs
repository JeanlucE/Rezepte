using UnityEngine;
using System.Collections;

public class Pflanze
{

    private Zutat.Growthstage state;
    private Zutat.ID zutat;

    public Pflanze(Zutat.ID zutat)
    {
        this.zutat = zutat;
        state = Zutat.Growthstage.seeded;
    }

    public Zutat.Growthstage GetGrowthStage()
    {
        return state;
    }

    public void SetImage(GameObject gameObject)
    {
        Zutat.getImage(gameObject, zutat, GetGrowthStage());
    }

    public void Grow()
    {
        switch (state)
        {
            case Zutat.Growthstage.seeded:
                state = Zutat.Growthstage.growing;
                break;

            case Zutat.Growthstage.growing:
                state = Zutat.Growthstage.grown;
                break;

        }

    }

    public bool Done()
    {
        return state == Zutat.Growthstage.grown;
    }

    public float TimeUntilNextState()
    {
        if (!Done())
        {
            return Zutat.getGrowthTimeInSeconds(zutat, state);
        }
        else
        {
            return 0;
        }
    }

    public string GetDebugText()
    {
        return Zutat.getName(zutat);
    }
}
