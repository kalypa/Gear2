using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SkillPanel : MonoBehaviour
{
    public SkillInfoUI skillInfo;
    public int index;
    public float startX;
    public float endX;
    public RectTransform rectInfo;
    public void OnClickSkillInfoEnterButton()
    {
        skillInfo.infoIndex = index;
        if(rectInfo.anchoredPosition.x != endX) rectInfo.DOAnchorPosX(endX, 0.1f);
    }
    public void OnClickSkillInfoExitButton()
    {
        rectInfo.DOAnchorPosX(startX, 0.1f);
    }
}
