using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCharacter : MonoBehaviour
{
    public Image characterImage;
    public Sprite[] characters = new Sprite[3];
    void Update()
    {
        SetStatCharacter();
    }

    void SetStatCharacter()
    {
        characterImage.sprite = characters[GameManager.Inst.playerTransform.playermode - 1];
    }
}
