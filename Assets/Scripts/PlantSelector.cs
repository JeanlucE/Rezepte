using UnityEngine;
using System.Collections;

public class PlantSelector : MonoBehaviour {

    public static PlantSelector Instance; 

    private Feld activeFeld;

	// Use this for initialization
	void Start () {
        if (Instance == null)
            Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CenterOn(Feld feld)
    {
        activeFeld = feld;
        //Debug.Log(activeFeld.GetComponent<RectTransform>().anchoredPosition);

        GetComponent<RectTransform>().anchoredPosition = activeFeld.GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnClick(string ingredient)
    {
        if (!activeFeld)
            return;

        switch(ingredient.ToLower())
        {
            case "brokkoli":
                activeFeld.Plant(Zutat.ID.Brokkoli);
                break;

            case "suesskartoffel":
                activeFeld.Plant(Zutat.ID.Suesskartoffel);
                break;

            case "tomate":
                activeFeld.Plant(Zutat.ID.Tomate);
                break;

            case "pilz":
                activeFeld.Plant(Zutat.ID.Pilz);
                break;

            default:
                Debug.Log("No Ingredient set for this button");
                break;
        }
    }
}
