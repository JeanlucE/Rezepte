using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class Inventoryfiller : MonoBehaviour {
    public List<RectTransform> ZutatenFrames;

	// Use this for initialization
	void Start () {
        Inventar.Instance.InventoryChangedEvent += OnInventoryChanged;
	}

    private void OnInventoryChanged(object sender, EventArgs e)
    {
        Debug.Log("Inventory changed");
        //populate inventory panel with text and images
        List<Tupel> inventory = Inventar.Instance.GetInventory();
        int i = 0;
        for (i = 0; i < inventory.Count && i < ZutatenFrames.Count; i++)
        {
            Tupel t = inventory[i];
            ZutatenFrames[i].gameObject.SetActive(true);
            ZutatenFrames[i].GetComponentInChildren<Text>().text = t.value + "x " + t.key.ToString();
            Zutat.getImage(ZutatenFrames[i].GetComponentInChildren<Image>().gameObject, t.key, Zutat.Growthstage.inventory);
        }

        //hide unneccessary text and image panels
        for(; i < ZutatenFrames.Count; i++)
        {
            ZutatenFrames[i].gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
