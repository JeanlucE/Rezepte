using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Textscript : MonoBehaviour {


    public void getText()
    {
        System.Collections.Generic.List<Rezept> rez = Rezept.getRezepte();

        foreach (Rezept r in rez)
        {
            if (GetComponentInChildren<Text>().text.Equals(Rezept.getName(r.id) + ""))
            {
                GameObject.Find("RezepteText").GetComponent<Text>().text = r.text;
                GameObject.Find("RezepteUberschrift").GetComponent<Text>().text = Rezept.getName(r.id) + "";
            }
        }

    }
}
