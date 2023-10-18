using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class PlayerCtrl : MonoBehaviour
=======
public class Playjjj: MonoBehaviour
>>>>>>> Stashed changes
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.tag == "Road_1A")
        {
        }
            player.transform.position += new Vector3(0, 0, 1)*Time.deltaTime;
    }
}
