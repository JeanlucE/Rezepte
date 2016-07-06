﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RezeptSammlungscript : MonoBehaviour
{
    // Die beiden Cavases zum "Szene wechseln"
    public GameObject menu;
    public GameObject sammlung;

    // Das Empty game objekt wo es die Rezepte spawnen soll
    public GameObject parent;
    // Das Prefab eines Rezepts
    public GameObject prefab;

    public void goToRezepte()
    {
        menu.SetActive(false);
        sammlung.SetActive(true);
    }
    public void backToMenu()
    {
        menu.SetActive(true);
        sammlung.SetActive(false);
    }

    public void setRezepte()
    {
        System.Collections.Generic.List <Rezept> rez = Rezept.getRezepte();
        int i = 0;
        foreach (Rezept r in rez)
        {

            Vector3 pos = new Vector3(prefab.GetComponent<RectTransform>().position.x, prefab.GetComponent<RectTransform>().position.y, prefab.GetComponent<RectTransform>().position.z);
            GameObject game = Instantiate(prefab, pos, prefab.transform.rotation) as GameObject;
            game.transform.SetParent(parent.transform);
            game.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            game.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            game.GetComponent<RectTransform>().anchorMax = new Vector2(game.GetComponent<RectTransform>().anchorMax.x, game.GetComponent<RectTransform>().anchorMax.y-0.1f*i);
            game.GetComponent<RectTransform>().anchorMin = new Vector2(game.GetComponent<RectTransform>().anchorMin.x , game.GetComponent<RectTransform>().anchorMin.y-0.1f*i);
            game.GetComponentInChildren<Text>().text = r.id+"";
            i++;
        }
        // game.GetComponent<RectTransform>().rect.width;
    }

    // Use this for initialization
    void Start()
    {
        setRezepte();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
