using UnityEngine;
using System.Collections;

public class Zutat {
    
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
    public string getName(ID id)
    {
        if (id == ID.Tomate)
            return "Tomate";
        if (id == ID.Gurke)
            return "Gurke";
        if (id == ID.Kartoffel)
            return "Kartoffel";
        //Entsprechend weiterfuehren!
        return "Wenn du diesen Fehler ausloest bist du zu dumm zum ....!";
    }
}
