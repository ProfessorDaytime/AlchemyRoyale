using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Discard : DropZone, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
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
