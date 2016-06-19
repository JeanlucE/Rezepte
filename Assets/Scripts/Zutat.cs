﻿using UnityEngine;
using UnityEngine.UI;

public class Zutat
{
    public enum ID
    {
        Tomate,
        Gurke,
        Kartoffel
        //Weitere Zutaten durch Komma getrennt einfuegen
    }

    /*
    Uebergib der Funktion eine ID alias enum einer beliebigen Zutat und du bekommst den ausgeschriebenen Namen als String zurueck
    */
    public static string getName(ID id)
    {
        return id.ToString();
    }

    /*
    Uebergebt dieser funktion ein GUI Element. Diesem wird dann, wenn nicht schon vorhanden ein Image hinzugefuegt und dann dieses Bild mit einem der id entsprechenden belegt
    */
    public static void getImage(GameObject obj, ID id)
    {
        if (obj.GetComponent<Image>() == null)
            obj.AddComponent<Image>();
        //z_ fuer eindeutigkeit mit den Rezepten
        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("z_"+ id.ToString());
    }
}
