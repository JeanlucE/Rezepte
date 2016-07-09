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
        bool checkRecipe = Inventar.Instance.CheckRecipe(Rezept.getRezept(currentQuest));

        if (checkRecipe)
        {
            //Remove
            foreach (Tupel t in z)
            {
                Inventar.Instance.Remove(t);
            }

            GetNextRecipe();

            Inventar.Instance.InventoryChanged = true;

            Debug.Log("Recipe done");
        }
        else
        {
            Debug.Log("Recipe not done");
        }
    }

    private void GetNextRecipe()
    {
        Inventar.Instance.ChangeMoney(10);
        List<Tupel> inv = Inventar.Instance.GetInventory();
        List<Zutat.ID> zut = new List<Zutat.ID>();
        foreach(Tupel t in inv)
        {
            zut.Add(t.key);
        }
        currentQuest = Rezept.getNextQuest(zut);
    }
}
