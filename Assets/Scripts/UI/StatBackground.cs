using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBackground : MonoBehaviour
{
    public Image backgroundImage;
    public Sprite[] background = new Sprite[3];
    void Update()
    {
        SetStatBackground();
    }

    void SetStatBackground()
    {
        backgroundImage.sprite = background[GameManager.Inst.currentStage];
    }
}
