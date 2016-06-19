using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Rezept
{

    private static List<Rezept> rezepte;

    public ID id;
    public List<Tupel> zutaten;
    public string text;

    public enum ID
    {
        Gurkensalat,
        Bratkartoffeln
        //Weitere Rezepte durch Komma getrennt einfuegen
    }

    public Rezept(ID i, List<Tupel> z, string t)
    {
        id = i;
        zutaten = new List<Tupel>(z);
        text = t;
    }

    public static List<Rezept> getRezepte()
    {
        if(rezepte == null)
        {
            rezepte = new List<Rezept>();
            List<Tupel> zutaten = new List<Tupel>();

            zutaten.Add(new Tupel(Zutat.ID.Gurke, 1));
            rezepte.Add(new Rezept(ID.Gurkensalat, zutaten, "Einfacher Gurkensalat:\n Man nehme ... blabliblub Kochanleitung"));
            zutaten.Clear();

            //Hier weitere Rezepte hinzufuegen
            //1. Enum hinzufuegen
            //2. Zutaten mit beliebiger Menge auffuellen. Bitte jede Zutat nur einmalig. Die mitgelieferte Zahl ist die Anzahl
            //3. Rezept erstellen mit Zutaten, Kochanleitung
            //4. Zutaten leeren und von vorn das Ganze
        }
        return rezepte;
    }

    /*
    Uebergib der Funktion eine ID alias enum eines beliebigen Rezeptes und du bekommst den ausgeschriebenen Namen als String zurueck
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
        //z_ fuer Eindeutigkeit mit den Zutaten
        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("r_" + id.ToString());
    }

    public static ID getNextQuest(List<Zutat.ID> list)
    {
        List<Rezept> rezepte = getRezepte();
        Rezept best = new Rezept(ID.Bratkartoffeln, null, ""); // Dummy
        int match = 0;
        foreach(Rezept r in rezepte)
        {
            int mv = getMatchValue(list, r);
            if(match < mv)
            {
                float prob = (mv - match * 1.0f) / (mv - match + 0.5f);
                if( Random.value > prob)
                {
                    match = mv;
                    best = r;
                }
            }
        }
        return best.id;
    }

    /*
    WIP
    */
    private static int getMatchValue(List<Zutat.ID> felder, Rezept r)
    {
        int value = 0;
        foreach (Zutat.ID t in felder)
        {
            foreach (Tupel v in r.zutaten)
            {
                if (t == v.key)
                {
                    value++;
                    break;
                }
            }
        }
        return value;
    }
}
