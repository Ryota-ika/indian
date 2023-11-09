using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public GameObject obj;
    public GameObject ira;

    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(false);
        ira.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "Player")
        {
            obj.SetActive(true);
            ira.SetActive(true);
         if(ira==true)
            {
                StartCoroutine(MyCoroutine());
            }
           

        }
    }

    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        ira.SetActive(false);
    }
}
