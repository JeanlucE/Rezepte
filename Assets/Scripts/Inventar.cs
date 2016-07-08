using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Inventar : MonoBehaviour {
    public static Inventar Instance;

    public float StartingMoney;
    
    private List<Tupel> inventory = new List<Tupel>();
    private float money;
    public bool InventoryChanged;
    public GameObject gameCanvas;
    public GameObject inventoryCanvas;

    public event EventHandler InventoryChangedEvent;
    
	// Use this for initialization
	void Awake () {
        if (Instance == null)
            Instance = this;

        money = StartingMoney;
        InventoryChanged = true;
	}

    //adds ingredients to inventory
    public void Add(Tupel t)
    {
        if(t == null || t.value < 1)
        {
            return;
        }

        foreach(Tupel invTupel in inventory)
        {
            if(invTupel.key == t.key)
            {
                invTupel.value += t.value;
                InventoryChanged = true;
                return;
            }
        }

        //ingredient doesnt exist yet, so add it
        inventory.Add(t);
        InventoryChanged = true;
    }

    //checks if all ingredients of a recipe are available
    public bool CheckRecipe(Rezept r)
    {
        foreach(Tupel t in r.zutaten)
        {
            if(!Exists(t))
            {
                return false;
            }
        }

        return true;
    }

    //check if a certain amount of an ingredient is available
    public bool Exists(Tupel t)
    {
        if (t == null || t.value < 1)
        {
            return false;
        }

        foreach (Tupel invTupel in inventory)
        {
            if (invTupel.key == t.key)
            {
                return invTupel.value >= t.value;
            }
        }

        return false;
    }

    //removes ingredients if possible. 
    //returns true if the ingredients were in inventory and were actually removed
    public bool Remove(Tupel t)
    {
        if(!Exists(t))
        {
            return false;
        }

        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].key == t.key)
            {
                inventory[i].value -= t.value;

                if(inventory[i].value <= 0)
                    inventory.RemoveAt(i);

                InventoryChanged = true;
                break;
            }
        }

        return true;
    }

    public List<Tupel> GetInventory()
    {
        List<Tupel> l = new List<Tupel>(inventory.Count);
        foreach(Tupel t in inventory)
        {
            Tupel tupelCopy = new Tupel(t.key, t.value);
            l.Add(tupelCopy);
        }

        return l;
    }

    //set the money value directly
    public void SetMoney(float amount)
    {
        money = amount;
    }

    //add and remove money
    public void ChangeMoney(float amount)
    {
        money += amount;
    }

    //return amount of money
    public float GetMoney()
    {
        return money;
    }
    // Ends the game
    public void Endgame()
    {
        Application.Quit();
    }


    // Deaktivates the Game canvas and starts the inventory canvas
    public void OpenInventory()
    {
        inventoryCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }
	
    public void CloseInventory()
    {
        inventoryCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

	// Update is called once per frame
	void Update () {
        if (InventoryChanged)
        {
            if(InventoryChangedEvent != null)
                InventoryChangedEvent(null, EventArgs.Empty);

            InventoryChanged = false;
        }
	}
}
