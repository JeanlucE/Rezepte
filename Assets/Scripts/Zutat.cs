using UnityEngine;
using UnityEngine.UI;

public class Zutat
{
    public enum ID
    {
        Tomate,
        Brokkoli,
        Pilz,
        Suesskartoffel

        //Weitere Zutaten durch Komma getrennt einfuegen
    }

    public enum Growthstage
    {
        seeded,
        growing,
        grown,
        inventory
    }

    /*
    Uebergib der Funktion eine ID alias enum einer beliebigen Zutat und du bekommst den ausgeschriebenen Namen als String zurueck
    */
    public static string getName(ID id)
    {
        switch (id)
        {
            case ID.Suesskartoffel:
                return "Süßkartoffel";
            default:
                return id.ToString();
        }
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
                
            case Zutat.ID.Brokkoli:
                switch (stage)
                {
                    case Growthstage.seeded:
                        return 2.5f;
                    case Growthstage.growing:
                        return 5;
                    default:
                        return 0;
                }

            case Zutat.ID.Pilz:
                switch (stage)
                {
                    case Growthstage.seeded:
                        return 5;
                    case Growthstage.growing:
                        return 10;
                    default:
                        return 0;
                }
            case Zutat.ID.Suesskartoffel:
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

    public static int GetResultAmount(Zutat.ID zutat)
    {
        switch (zutat)
        {
            case Zutat.ID.Tomate:
                return 2;

            case Zutat.ID.Brokkoli:
                return 3;

            case Zutat.ID.Pilz:
                return 3;

            case Zutat.ID.Suesskartoffel:
                return 2;

            default:
                return 0;
        }
    }
}
