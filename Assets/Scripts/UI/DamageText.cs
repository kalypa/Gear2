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
    float randomValueMonster;
    float randomValuePlayer;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        randomValueMonster = (Random.Range(0, 2) == 0) ? 10 : -10;
        randomValuePlayer = (Random.Range(0, 2) == 0) ? 5 : -5;
    }
    void Update()
    {
        TextEffect();
    }
    void TextEffect()
    {
        if(!isPlayer)
        {
            DamageTween(randomValueMonster, 3);
        }
        else
        {
            DamageTween(randomValuePlayer, 4);
        }
    }
    void DamageTween(float x, int index)
    {
        rectTransform.DOJump(rectTransform.position + new Vector3(x, -15f, 0f), 0.5f, 1, 0.7f)
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
