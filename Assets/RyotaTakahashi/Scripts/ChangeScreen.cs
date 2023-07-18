//7.14
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour
{
    public PlayerCtrl PlayerCtrl;
    public GameObject Panel;
    public TextMeshProUGUI on_off_text;
    private bool on_off_button;

   
    private void Awake()
    {
        //PlayerCtrl = FindObjectOfType<PlayerCtrl>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //PlayerCtrl.MovePlayer();
        on_off_button = true;
      
    }
    
    public void OnClick()
    {
        on_off_button = !on_off_button;
        if ( on_off_button == true)
        {
           
            on_off_text.text = "Create";
            Panel.SetActive(false);
            PlayerCtrl.move_speed = 13f;
            PlayerCtrl.MovePlayer();
        }
        else
        {
           
            on_off_text.text = "Return";
            Panel.SetActive(true);
            PlayerCtrl.StopPlayer();
        }
    }
}
