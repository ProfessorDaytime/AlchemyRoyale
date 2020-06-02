using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private string name;

    private string character;

    List<GameObject> hand = new List<GameObject>();

    private int money;

    private int fame;

    private string[] recipes;

    private string[] potions;

    private int abilityPoints;

    private bool isNewt = false;

    public string Name{
        get{return name;}
        set{name = value;}
    }

    public string Character{
        get{return character;}
        set{character = value;}
    }

    // public int Money{
    //     get{return money;}
    //     set{money = value;}
    // }
    public int GetMoney(){
        return money;
    }

    public int Fame{
        get{return fame;}
        set{fame = value;}
    }

    public int AbilityPoints{
        get{return abilityPoints;}
        set{abilityPoints = value;}
    }

    public bool IsNewt{
        get{return isNewt;}
        set{isNewt = value;}
    }
    

    public void AddToHand(GameObject ingredient){
        hand.Add(ingredient);
        Debug.Log(ingredient);
    }

    // Start is called before the first frame update
    void Start()
    {
        money = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
