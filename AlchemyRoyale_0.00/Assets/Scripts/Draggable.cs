using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Transform placeHolderParent = null;

    GameObject placeHolder = null;

    public enum CardType { INGREDIENT, RECIPE, POTION, CHARACTER };
    public CardType typeOfCard = CardType.INGREDIENT;
    
    public void OnBeginDrag(PointerEventData eventData){
        
        //Puts an empty placeholder space where the card was so that the cards don't move
        //and the player knows where the card will land when dropped
        placeHolder = new GameObject();
        placeHolder.transform.SetParent( this.transform.parent );
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        RectTransform rt = placeHolder.GetComponent<RectTransform>();

        //Sets actual width of placeholder -- no idea why it resets the width and height to 100 normally
        rt.sizeDelta = new Vector2(this.GetComponent<LayoutElement>().preferredWidth,this.GetComponent<LayoutElement>().preferredHeight);

        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeHolder.transform.SetSiblingIndex( this.transform.GetSiblingIndex() );

        //get location on object where dragging from to use as an offset
        parentToReturnTo = this.transform.parent;
        Debug.Log(parentToReturnTo);
        placeHolderParent = parentToReturnTo;
        this.transform.SetParent( this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        //TO DO -- Make all possible drop zones for current card glow
        // DropZone[] zones = GameObject.FindObjectOfType<DropZone>();
    }

    public void OnDrag(PointerEventData eventData){
        // Debug.Log("on drag");

        //use that offset to make it look like the player is dragging from that place on the object, and not the same origin 
        this.transform.position = eventData.position;

        if(placeHolder.transform.parent != placeHolderParent){
            placeHolder.transform.SetParent(placeHolderParent);
        }


        int newSiblingIndex = placeHolderParent.childCount;

        for(int i = 0; i < placeHolderParent.childCount; i++){
            if(this.transform.position.x < placeHolderParent.GetChild(i).position.x){ 
                
                newSiblingIndex = i;

                if(placeHolder.transform.GetSiblingIndex() < newSiblingIndex){ //might need to change this to placeHolderParent
                    newSiblingIndex --;
                }
                break;
            }
        }

        placeHolder.transform.SetSiblingIndex(newSiblingIndex);

    }

    public void OnEndDrag(PointerEventData eventData) {
        // Debug.Log("end drag");

        //if not in another drag spot
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex( placeHolder.transform.GetSiblingIndex() );

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeHolder);
        // Debug.Log("Destroy");
        
    }


}
