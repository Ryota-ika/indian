using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragPazl : MonoBehaviour, IDragHandler
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(eventData.position);
        TargetPos.z = 0;
        transform.position = TargetPos;
    }


}
