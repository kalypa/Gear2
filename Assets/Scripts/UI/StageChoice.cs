using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChoice : MonoBehaviour
{
    public int index;
    public GameObject[] backgrounds = new GameObject[3];
    public void OnClickStageEnterButton()
    {
        backgrounds[GameManager.Inst.currentStage].SetActive(false);
        GameManager.Inst.currentStage = index;
        backgrounds[index].SetActive(true);
    }
}
