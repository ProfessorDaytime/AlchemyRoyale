using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public Draggable.CardType typeOfCard = Draggable.CardType.INGREDIENT;  

    public void OnPointerEnter(PointerEventData eventData) {
        // Debug.Log("pointerEnter");
        if(eventData.pointerDrag == null){
            return;
        }
        
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null){
            if(typeOfCard == d.typeOfCard){
                d.placeHolderParent = this.transform;
            }
            
        }
    }
    public void OnPointerExit(PointerEventData eventData) {
        // Debug.Log("pointerExit");
        if(eventData.pointerDrag == null){
            return;
        }

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeHolderParent == this.transform){
            if(typeOfCard == d.typeOfCard){
                d.placeHolderParent = d.parentToReturnTo;
            }
            
        }
    }
    public void OnDrop(PointerEventData eventData) {
        // Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null){
            if(typeOfCard == d.typeOfCard){
                d.parentToReturnTo = this.transform;
            }
            
        }
    }


}