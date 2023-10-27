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
    [SerializeField]
    Button button;
    public Sprite createSprite;
    public Sprite bikeSprite;
    public PlayerCtrl playerCtrl;
    public GameObject Panel;
    public Transform panelMinPos;
    public Transform panelMaxPos;
    private bool onOffButton = false;
    private bool isCoolDown = false;
    private float cullentMoveSpeed;


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
		onOffButton = !onOffButton;
		if (onOffButton)
        {
            btnImage.sprite = createSprite;
            Panel.SetActive(false);
            //StartCoroutine(TransitionCreate(true));
            playerCtrl.moveSpeed = 13f;
            playerCtrl.MovePlayer();
        }
        else
        {
            btnImage.sprite = bikeSprite;

            Panel.SetActive(true);
            //StartCoroutine(TransitionCreate(false));
            playerCtrl.moveSpeed = 7f;
            //playerCtrl.StopPlayer();
			isCoolDown = false;//panelがfalseになる場合、クールダウンを無くす
			yield break;//クールダウンを続けないためにコルーチン終了
		}
        button.interactable = false;
        yield return new WaitForSeconds(2f);
        button.interactable = true;
    }
    IEnumerator TransitionCreate(bool panelActive)
	{
        float timer = 0;
        if (panelActive)
		{
			while (timer <= 1)
			{
				Vector3 panelPos = Vector3.Lerp(panelMinPos.position, panelMaxPos.position, timer);
				float panelScale = Mathf.Lerp(panelMinPos.localScale.x, panelMaxPos.localScale.x, timer);
				Panel.transform.position = panelPos;
				Panel.transform.localScale = new Vector3(panelScale, panelScale, panelScale);
				timer += Time.deltaTime;
				yield return null;
			}
			yield break;
		}else
		{
            while (timer <= 1)
            {
                Vector3 panelPos = Vector3.Lerp(panelMaxPos.position, panelMinPos.position, timer);
                Panel.transform.position = panelPos;
                timer += Time.deltaTime;
                yield return null;
            }
            yield break;
        }
	}
}
