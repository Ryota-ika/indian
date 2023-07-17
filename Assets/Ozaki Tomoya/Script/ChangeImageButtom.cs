using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageButtom : MonoBehaviour
{

    Image btnImage;
    public Sprite Cratesprite;
    public Sprite Bikesprite;
    private bool on_off_button;
    // Start is called before the first frame update
    void Start()
    {
        btnImage = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        on_off_button = !on_off_button;
        if (on_off_button == true)
        {
            btnImage.sprite = Cratesprite;
            
        }
        else
        {
            btnImage.sprite = Bikesprite;
           
        }
    }
    
}
