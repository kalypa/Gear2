using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCharacter : MonoBehaviour
{
    public Image characterImage;
    public Sprite[] characters = new Sprite[3];
    RectTransform rect;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update() => SetStatCharacter();

    void SetStatCharacter() //변신 상태에 따라 캐릭터 UI 변경
    {
        if (GameManager.Inst.playerTransform.playermode != 1) rect.sizeDelta = new Vector2(22 * 6, 108);
        else rect.sizeDelta = new Vector2(90, 108);
        characterImage.sprite = characters[GameManager.Inst.playerTransform.playermode - 1];
    }
}
