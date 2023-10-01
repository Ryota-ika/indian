//7.14
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour
{
    [SerializeField]
    Image btnImage;
    public Sprite createSprite;
    public Sprite bikeSprite;
    public PlayerCtrl playerCtrl;
    public GameObject Panel;
    public TextMeshProUGUI onOffText;
    private bool onOffButton = false;
    private bool isCoolDown = false;


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
            btnImage.sprite = bikeSprite;
            Panel.SetActive(false);
            playerCtrl.moveSpeed = 13f;
            playerCtrl.MovePlayer();
        }
        else
        {

            //onOffText.text = "Return";
            btnImage.sprite = createSprite;
            Panel.SetActive(true);
            playerCtrl.StopPlayer();
            isCoolDown=false;//panelがfalseになる場合、クールダウンを無くす
            yield break;//クールダウンを続けないためにコルーチン終了
        }
        yield return new WaitForSeconds(2f);
        isCoolDown = false;
    }
}
