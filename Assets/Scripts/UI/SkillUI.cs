using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillUI : MonoBehaviour
{
    public float startX;
    public float endX;
    RectTransform rect;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    public void OnClickSkillEnterButton()
    {
        rect.DOAnchorPosX(endX, 0.1f);
    }
    public void OnClickSkillExitButton()
    {
        rect.DOAnchorPosX(startX, 0.1f);
    }
}
