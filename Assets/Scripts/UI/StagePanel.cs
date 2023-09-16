using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using DG.Tweening;
public class StagePanel : MonoBehaviour
{
    RectTransform rect;
    public float startX;
    public float endX;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    public void OnClickExitStagePanel()
    {
        rect.DOAnchorPosX(endX, 0.1f);
    }

    public void OnClickEnterStagePanel()
    {
        rect.DOAnchorPosX(startX, 0.1f);
    }
}
