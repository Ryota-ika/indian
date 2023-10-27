using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodAnimation : MonoBehaviour
{
    [SerializeField] private GameObject blood;
    public float moveDownSpeed=0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blood.transform.position.y>-2.0)
        {
            Vector3 newPosition = blood.transform.position-new Vector3(0f,moveDownSpeed*Time.deltaTime,0f);
            blood.transform.position = newPosition;
        }
        
    }
}
