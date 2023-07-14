using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonContrll : MonoBehaviour
{

    [SerializeField]
    private TMP_Text on_off_Tdext;
    int Button = 1;

    [SerializeField]
    GameObject Canvas;
    
    public void ButtonSet()
    {
        if(Button ==1)
        {
            Debug.Log("•\Ž¦");
            on_off_Tdext.text = "OFF"; 
            Button = 0;
            Canvas.SetActive(true);
        }
        else if(Button == 0) 
        {
            Debug.Log("”ñ•\Ž¦");
            on_off_Tdext.text = "ON";
            Button= 1;
            Canvas.SetActive(false);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
