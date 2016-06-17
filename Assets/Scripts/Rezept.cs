using System.Collections.Generic;

public class Rezept {

    private static List<Rezept> rezepte;

    public ID id;
    public List<Tupel> zutaten;
    public string text;
    public string imagePath;

    public enum ID
    {
        Gurkensalat,
        Bratkartoffeln
        //Weitere Rezepte durch Komma getrennt einfuegen
    }

    public Rezept(ID i, List<Tupel> z, string t, string im)
    {
        id = i;
        zutaten = new List<Tupel>(z);
        text = t;
        imagePath = im;
    }

    public static List<Rezept> getRezepte()
    {
        if(rezepte == null)
        {
            rezepte = new List<Rezept>();
            List<Tupel> zutaten = new List<Tupel>();

            zutaten.Add(new Tupel(Zutat.ID.Gurke, 1));
            rezepte.Add(new Rezept(ID.Gurkensalat, zutaten, "Einfacher Gurkensalat:\n Man nehme ... blabliblub Kochanleitung", "D:\\eine\\Mudda\\hat\\nen\\Bild\\gemacht.jpg"));
            zutaten.Clear();

            //Hier weitere Rezepte hinzufuegen
            //1. Zutaten mit beliebiger Menge auffuellen. Bitte jede Zutat nur einmalig. Die mitgelieferte Zahl ist die Anzahl
            //2. Rezept erstellen mit Zutaten, Kochanleitung und evt Bild
            //3. Enum fuer das Rezept sowie String in getName hinzufuegen
            //4. Zutaten leeren und von vorn das Ganze
        }
        return rezepte;
    }

    /*
    Uebergib der Funktion eine ID alias enum eines beliebigen Rezeptes und du bekommst den ausgeschriebenen Namen als String zurueck
    */
    public static string getName(ID id)
    {
        if (id == ID.Gurkensalat)
            return "Gurkensalat";
        if (id == ID.Bratkartoffeln)
            return "Bratkartoffeln";
        //Entsprechend weiterfuehren!
        return "Wenn du diesen Fehler ausloest bist du zu dumm zum ....!";
    }

    /*
    WIP
    */
    private static int getMatchValue(List<Tupel> felder, Rezept r)
    {
        int value = 0;
        foreach (Tupel t in felder)
        {
            foreach (Tupel v in r.zutaten)
            {
                if (t == v)
                {
                    value++;
                    break;
                }
            }
        }
        return value;
    }
}
