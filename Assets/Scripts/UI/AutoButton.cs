using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoButton : MonoBehaviour
{
    public Sprite usedSprite;
    public Sprite notUsedSprite;
    private bool isActiveAuto = false;
    public void OnClickAutoButton() //오토 버튼 클릭
    {
        if(!isActiveAuto) isActiveAuto = true;
        else if(isActiveAuto) isActiveAuto = false;
        if(isActiveAuto) GetComponent<Image>().sprite = usedSprite;
        else GetComponent<Image>().sprite = notUsedSprite;
        GameManager.Inst.playerskill.isAuto = isActiveAuto;
        GameManager.Inst.playerTransform.isAuto = isActiveAuto;
    }
}
