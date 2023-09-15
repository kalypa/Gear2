using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoButton : MonoBehaviour
{
    public Sprite usedSprite;
    public Sprite notUsedSprite;
    private bool isActiveAuto = false;
    public void OnClickAutoButton()
    {
        Debug.Log("ÀÚµ¿");
        if(!isActiveAuto) isActiveAuto = true;
        else if(isActiveAuto) isActiveAuto = false;
        if(isActiveAuto) GetComponent<Image>().sprite = usedSprite;
        else GetComponent<Image>().sprite = notUsedSprite;
        GameManager.Inst.playerskill.isAuto = true;
        GameManager.Inst.playerTransform.isAuto = true;
    }
}
