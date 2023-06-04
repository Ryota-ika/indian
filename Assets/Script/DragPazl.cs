using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragPazl : MonoBehaviour
{
    Vector2 SecondPos;
    Vector2 currenSwipePos;
    Vector2 firstPos;

    float datectionButton = -0.8f;
    float datetctionup = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();

    }

    public void Swipe()
    {
        if(Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            SecondPos = new Vector2 (Input.mousePosition.x,Input.mousePosition.y);
            currenSwipePos = new Vector2(currenSwipePos.x - firstPos.x, currenSwipePos.y - firstPos.y);
            currenSwipePos.Normalize();
        }
        if(currenSwipePos.y > 0 && currenSwipePos.x >datectionButton && currenSwipePos.x < datetctionup)
        {
            Debug.Log("ã");
        }
        if (currenSwipePos.y < 0 && currenSwipePos.x > datectionButton && currenSwipePos.x < datetctionup)
        {
            Debug.Log("‰º");
        }
        if (currenSwipePos.x < 0 && currenSwipePos.y > datectionButton && currenSwipePos.y < datetctionup)
        {
            Debug.Log("¶");
        }
        if (currenSwipePos.x > 0 && currenSwipePos.y > datectionButton && currenSwipePos.y < datetctionup)
        {
            Debug.Log("‰E");
        }
    }


}
