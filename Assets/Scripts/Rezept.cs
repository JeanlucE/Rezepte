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
        Tomatensalat,
        Bratkartoffeln,
        Curry_mit_Suesskartoffeln_und_Brokkoli,
        Pasta_mit_Brokkoli_Pilz_Sosse
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

            zutaten.Add(new Tupel(Zutat.ID.Tomate, 4));
            rezepte.Add(new Rezept(ID.Tomatensalat, zutaten, "Tomaten schneiden,\nZwiebeln schälen und schneiden,\nEssig und Öl dazu,\nMit Pfeffer und Salz abschmecken"));
            zutaten.Clear();

            zutaten.Add(new Tupel(Zutat.ID.Suesskartoffel, 2));
            rezepte.Add(new Rezept(ID.Bratkartoffeln, zutaten, "Zwiebeln schneiden,\nZwiebeln andünsten,\nKartoffeln in Scheiben schneiden,\nKartoffeln goldbraun braten,\nmitSalz und Pfeffer abschmecken"));
            zutaten.Clear();

            //Hier weitere Rezepte hinzufuegen
            //1. Enum hinzufuegen
            //2. Zutaten mit beliebiger Menge auffuellen. Bitte jede Zutat nur einmalig. Die mitgelieferte Zahl ist die Anzahl
            //3. Rezept erstellen mit Zutaten, Kochanleitung
            //4. Zutaten leeren und von vorn das Ganze

            zutaten.Add(new Tupel(Zutat.ID.Suesskartoffel, 2));
            zutaten.Add(new Tupel(Zutat.ID.Brokkoli, 5));
            rezepte.Add(new Rezept(ID.Curry_mit_Suesskartoffeln_und_Brokkoli, zutaten, "Zutaten: \n2 große Süßkartoffel \n2 Zwiebeln \n2 Knoblauchzehen \n1 Stück Ingwer \n4 EL Butter oder Öl \nCurry, Curcuma, Kreuzkümmel, Cayennepfeffer, Koriander, Sojasauce \n400 ml Kokosmilch \n300 ml Brühe \n500 g Brokkoli \n300g Reis \n\nZubereitung: \nBrokkoli waschen und in mundgerechte Röschen teilen.\nZwiebel, Ingwer und Knoblauchzehe fein hacken.Süßkartoffel schälen und in kleine Würfel zuschneiden.In einer großen Pfanne die Zwiebel anschwitzen, Knoblauch, Ingwer und Gewürze nur kurz erhitzen. \nDie Süßkartoffel dazu geben und einige Minuten mit dünsten.Anschließend mit der Kokosmilch ablöschen und die Brühe hinzugeben. 5 Minuten köcheln lassen. \nIn der Zwischenzeit den Reis nach Packungsanweisung kochen. \nBrokkoli dazu geben und für weitere 10 Minuten zugedeckt köcheln lassen.Mit der Sojsauce, Cayennepfeffer Salz und Koriandergrün abschmecken."));
            zutaten.Clear();

            zutaten.Add(new Tupel(Zutat.ID.Brokkoli, 5));
            zutaten.Add(new Tupel(Zutat.ID.Pilz, 3));
            zutaten.Add(new Tupel(Zutat.ID.Tomate, 4));
            rezepte.Add(new Rezept(ID.Pasta_mit_Brokkoli_Pilz_Sosse, zutaten, "Zutaten: \n500g Brokkoli \n300g Champignons \n1 kleine Zwiebel \n1,5 - 2 Dosen Tomaten stückig \n1 - 2 Knoblauchzehen \n100 ml Schlagsahne \n300g - 500g Nudeln \nfrischer Basilikum \nOlivenöl, Salz, Pfeffer,geriebener Parmesan zum Bestreuen \n\nZubereitung: \nZwiebel abziehen, klein hacken. Champignons in Streifen schneiden. Brokkoli in kleine Röschen schneiden, in kochendem Wasser 4 - 5 Minuten garen. Zwiebel in Olivenöl andünsten, Knoblauch zugeben.Die Champignons braten bis zu braun werden.Dann Tomaten, und Sahne zugeben.Nudeln mit zwei Esslöffeln Olivenöl bissfest kochen. Mit Salz, Pfeffer und Basilikum abschmecken. Am Tisch: Parmesan"));
            zutaten.Clear();


        }
        return rezepte;
    }

    /*
    Uebergib der Funktion eine ID alias enum eines beliebigen Rezeptes und du bekommst den ausgeschriebenen Namen als String zurueck
    */
    public static string getName(ID id)
    {
        switch (id)
        {
            case ID.Curry_mit_Suesskartoffeln_und_Brokkoli:
                return "Curry mit Süßkartoffeln und Brokkoli";
            case ID.Pasta_mit_Brokkoli_Pilz_Sosse:
                return "Pasta mit Brokkoli-Pilz-Soße";
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
        //z_ fuer Eindeutigkeit mit den Zutaten
        obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("r_" + id.ToString());
    }

    public static ID getNextQuest(List<Zutat.ID> list)
    {
        int length = getRezepte().Count;
        float[] matchValue = new float[length];
        Rezept[] rezepte = new Rezept[length];
        int i = 0;
        foreach(Rezept r in getRezepte())
        {
            rezepte[i] = r;
            matchValue[i] = getMatchValue(r);
            i++;
        }
        for (int t = 0; t < length - 1; t++) //Bubblesort
        {
            for (i = 0; i < length - 1; i++)
            {
                if (matchValue[i] < matchValue[i + 1])
                {
                    //swap
                    float puffer = matchValue[i];
                    matchValue[i] = matchValue[i + 1];
                    matchValue[i + 1] = puffer;
                    Rezept r = rezepte[i];
                    rezepte[i] = rezepte[i + 1];
                    rezepte[i + 1] = r;
                }
            }
        }
        float all = 0;
        for(i=0;i< length;i++)
        {
            all += matchValue[i];
        }
        float rand = Random.value;
        float current = 0;
        for(i=0;i< length;i++)
        {
            current += matchValue[i] / all;
            if (rand <= current)
                return rezepte[i].id;
        }
        return rezepte[length - 1].id;
    }
    
    private static float getMatchValue(Rezept r)
    {
        List<Tupel> inventar = Inventar.Instance.GetInventory();
        int vorhanden = 0;
        int gesamt = 0;
        foreach(Tupel t in r.zutaten)
        {
            gesamt += t.value;
            foreach (Tupel t2 in inventar)
            {
                if (t.key == t2.key)
                {
                    if (t.value < t2.value)
                        vorhanden += t.value;
                    else
                        vorhanden += t2.value;
                }
            }
        }
        Debug.Log(r.id.ToString() + "       " + (vorhanden * 1.0f / gesamt));
        return (vorhanden) * 1.0f / gesamt;
    }

    public static Rezept getRezept(ID id)
    {
        foreach(Rezept r in rezepte)
        {
            if (r.id == id)
                return r;
        }
        return null;
    }
}
