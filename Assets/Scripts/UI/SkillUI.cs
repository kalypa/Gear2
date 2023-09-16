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
    public void OnClickSkillEnterButton() //�г� ���̱�
    {
        rect.DOAnchorPosX(endX, 0.1f);
    }
    public void OnClickSkillExitButton() //�г� �����
    {
        rect.DOAnchorPosX(startX, 0.1f);
    }
}
