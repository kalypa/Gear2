using DG.Tweening;
using Redcode.Pools;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class DamageText : MonoBehaviour, IPoolObject
{
    public TextMeshProUGUI text;
    public float jumpHeight = 30.0f;
    public float jumpDuration = 1.0f;
    private RectTransform rectTransform;
    public bool isPlayer;
    void Update()
    {
        TextEffect();
    }
    void TextEffect()
    {
        if(!isPlayer)
        {
            DamageTween(78, 3);
        }
        else
        {
            DamageTween(900, 4);
        }
    }
    void DamageTween(float x, int index)
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.DOJump(new Vector3(x, rectTransform.anchoredPosition.y + 500 + jumpHeight, 0), 1, 1, jumpDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => PoolManager.Instance.TakeToPool(index, this));
    }
    public void SetText(string dmgText)
    {
        text.text = dmgText;
    }

    public void OnCreatedInPool()
    {

    }

    public void OnGettingFromPool()
    {
        if(rectTransform != null) rectTransform.anchoredPosition = Vector2.zero;
    }
}
