using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventar : MonoBehaviour {
    public static Inventar Instance;

    public float StartingMoney;
    
    private List<Tupel> inventory = new List<Tupel>();
    private float money;

	// Use this for initialization
	void Start () {
        if (Instance == null)
            Instance = this;

        money = StartingMoney;
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
                return;
            }
        }

        //ingredient doesnt exist yet, so add it
        inventory.Add(t);
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
                inventory.RemoveAt(i);
                break;
            }
        }

        return true;
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

    public void OpenInventory()
    {
        Debug.Log("Inventory Opened");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
