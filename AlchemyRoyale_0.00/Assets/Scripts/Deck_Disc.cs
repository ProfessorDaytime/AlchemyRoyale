using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Discard : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public Draggable.CardType typeOfCard = Draggable.CardType.INGREDIENT;

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("ENTER");
    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("EXIT");
    }
    public void OnDrop(PointerEventData eventData) {
        // Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        Debug.Log("DROP");
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null){
            if(typeOfCard == d.typeOfCard){
                d.parentToReturnTo = this.transform;
            }
            
        }
    }
}
