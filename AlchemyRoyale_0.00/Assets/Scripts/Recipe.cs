using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : Draggable
{

    private string name = null;

    private enum Rarities {COMMON, UNCOMMON, WILD};

    private Rarities rarity;

    private string[] ingredients;

    private string description;

    private int cost;

    private int marketValue;


    void setName(string n) {
        name = n;
    }

    void setRarity (string r) {
        if(r == "COMMON"){
            rarity = Rarities.COMMON;
        } else if(r == "UNCOMMON"){
            rarity = Rarities.UNCOMMON;
        } else if(r == "WILD"){
            rarity = Rarities.WILD;
        }

    }

    void setIngredients(string zero, string one, string two){
        ingredients[0] = zero;
        ingredients[1] = one;
        ingredients[2] = two;
    }

    public string Description{
        get{return description;}
        set{description = value;}
    }

    public int Cost {
        get{return cost;}
        set{cost = value;}
    }

    public int MarketValue {
        get{return marketValue;}
        set{marketValue = value;}
    }

}
