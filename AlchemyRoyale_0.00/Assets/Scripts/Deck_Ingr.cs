using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck_Ingr : MonoBehaviour, IPointerClickHandler
{
   
    // Transform canvasTransform = this.transform.parent.parent;
    // transform handTransform = canvasTransform.Find("Hand");

    // [SerializeField]
    public GameObject toadstool;
    public GameObject elderberries;
    public GameObject goldDust;
    public GameObject snakeVenom;
    public GameObject quicksilver;
    public GameObject starDust;
    public GameObject handArea;

    public GameObject forestFloor;
    // public GameObject player1;
    
    

    // public GameObject discardPile;


    List<GameObject> deck = new List<GameObject>();
    

    void Start(){
        Debug.Log("Strt");
        for(int i = 0; i < 12; i++){
            deck.Add(toadstool);
            
            deck.Add(elderberries);
            
            deck.Add(goldDust);
            
            if(i < 9){
                deck.Add(snakeVenom);
                
                deck.Add(quicksilver);
                
                if(i < 6){
                    deck.Add(starDust);
                    
                }
            }
        }
        Debug.Log("Deck Size: " + deck.Count);

        Shuffle();

        // for each player
        for(int i = 0; i < 5; i++){

            GameObject inHand = Instantiate(deck[0], new Vector3(0, 0, 0), Quaternion.identity);
            inHand.transform.SetParent(handArea.transform, false);
            FindObjectOfType<Player>().AddToHand(deck[0]);
            deck.RemoveAt(0);
        }

        for(int i = 0; i < 4; i++){

            GameObject inHand = Instantiate(deck[0], new Vector3(0, 0, 0), Quaternion.identity);
            inHand.transform.SetParent(forestFloor.transform, false);
            deck.RemoveAt(0);
        }

        Debug.Log("Deck Size: " + deck.Count);
    }

    public void Shuffle(){
        for (int i = 0; i < deck.Count; i++) {
         GameObject temp = deck[i];
         int randomIndex = Random.Range(i, deck.Count);
         deck[i] = deck[randomIndex];
         deck[randomIndex] = temp;
     }
     Debug.Log("Shuffled");
    }


    public void OnPointerClick(PointerEventData eventData){

        
        
        for(int i = 0; i < 3; i++){
            GameObject inHand = Instantiate(deck[0], new Vector3(0, 0, 0), Quaternion.identity);
            inHand.transform.SetParent(handArea.transform, false);
            FindObjectOfType<Player>().AddToHand(deck[0]);
            deck.RemoveAt(0);

        }
    }
}
