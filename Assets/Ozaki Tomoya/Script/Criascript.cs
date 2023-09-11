using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criascript : MonoBehaviour
{

    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Debug.Log("ÉSÅ[ÉãÇ…è’ìÀÇµÇΩ");
            isHit = true;
        }
    }
    public bool GetIsHit()
    {
        return isHit;
    }
}


