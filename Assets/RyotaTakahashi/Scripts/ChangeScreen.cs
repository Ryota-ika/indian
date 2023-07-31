//7.14
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    public GameObject Panel;
    public TextMeshProUGUI onOffText;
    private bool onOffButton=false;
    private bool isCoolDown=false;

   
    private void Awake()
    {
        //PlayerCtrl = FindObjectOfType<PlayerCtrl>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //PlayerCtrl.MovePlayer();
        onOffButton = true;
      
    }

   /* public void OnClick()
    {
        onOffButton = !onOffButton;
        if (onOffButton == true)
        {

            //onOffText.text = "Create";
            Panel.SetActive(false);
            playerCtrl.moveSpeed = 13f;
            playerCtrl.MovePlayer();
        }
        else
        {

            //onOffText.text = "Return";
            Panel.SetActive(true);
            playerCtrl.StopPlayer();
        }
    }*/
    public void OnClick()
    {
        if (!isCoolDown)
        {
            
            StartCoroutine(ButtonCoolDown());
        }
    }

    private IEnumerator ButtonCoolDown()
    {
        isCoolDown = true;
        onOffButton = !onOffButton;

            if (onOffButton)
            {

                //onOffText.text = "Create";
                Panel.SetActive(false);
                playerCtrl.moveSpeed = 13f;
                playerCtrl.MovePlayer();
            }
            else
            {

                //onOffText.text = "Return";
                Panel.SetActive(true);
                playerCtrl.StopPlayer();
            }
        yield return new WaitForSeconds(2f);
        isCoolDown=false;
    }
}
