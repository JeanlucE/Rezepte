using UnityEngine;
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

    public enum Growthstage
    {
        seeded,
        growing,
        grown
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
        //z_ fuer Eindeutigkeit mit den Rezepten
        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("z_"+ id.ToString());
    }

    public static void getImage(GameObject obj, ID id, Growthstage gs)
    {
        if (obj.GetComponent<Image>() == null)
            obj.AddComponent<Image>();
        //z_ fuer Eindeutigkeit mit den Rezeptenui
        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("z_" + id.ToString() + "_" + gs.ToString());
    }

    public static float getGrowthTimeInSeconds(Zutat.ID zutat, Growthstage stage)
    {
        switch (zutat)
        {
            case Zutat.ID.Tomate:
                switch (stage)
                {
                    case Growthstage.seeded:
                        return 2;
                    case Growthstage.growing:
                        return 2;
                    default:
                        return 0;
                }
                
            case Zutat.ID.Gurke:
                switch (stage)
                {
                    case Growthstage.seeded:
                        return 2.5f;
                    case Growthstage.growing:
                        return 5;
                    default:
                        return 0;
                }

            case Zutat.ID.Kartoffel:
                switch (stage)
                {
                    case Growthstage.seeded:
                        return 5;
                    case Growthstage.growing:
                        return 10;
                    default:
                        return 0;
                }
            default:
                return 0;
        }
    }
}
