using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rezeptbuch : MonoBehaviour {

    public static Rezeptbuch Instance;

    public GameObject gameCanvas;
    public GameObject rezeptbuchCanvas;
    public Rezept.ID currentQuest;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        Rezept.getRezepte();
    }

        // Update is called once per frame
        void Update () {
	
	}

    public void OpenRezeptbuch()
    {
        rezeptbuchCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    public void CloseRezeptbuch()
    {
        gameCanvas.SetActive(true);
        rezeptbuchCanvas.SetActive(false);
    }

    public void CookRezept()
    {
        List<Tupel> z = Rezept.getRezept(currentQuest).zutaten;
        List<Tupel> r = Inventar.Instance.GetInventory();
        //Check
        foreach (Tupel t in z)
        {
            bool enthalten = false;
            foreach (Tupel t2 in r)
            {
                if (t2.key == t.key && t2.value <= t.value)
                    enthalten = true;
            }
            if(!enthalten)
            {
                Debug.Log("Nicht genug Zutaten");
                return;
            }
        }
        //Remove
        foreach(Tupel t in z)
        {
            Inventar.Instance.Remove(t);
        }
        Inventar.Instance.ChangeMoney(10);
        if (Random.value < 0.5f)
            currentQuest = Rezept.ID.Bratkartoffeln;
        else
            currentQuest = Rezept.ID.Tomatensalat;
        Inventar.Instance.InventoryChanged = true;
    }
}
