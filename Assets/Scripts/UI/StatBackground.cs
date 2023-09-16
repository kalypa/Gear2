using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBackground : MonoBehaviour
{
    public Image backgroundImage;
    public Sprite[] background = new Sprite[3];
    void Update() => SetStatBackground();

    void SetStatBackground() //맵에 따라 UI 변경
    {
        backgroundImage.sprite = background[GameManager.Inst.currentStage];
    }
}
