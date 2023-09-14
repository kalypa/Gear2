using UnityEngine;
using UnityEngine.UI;

public class PlayerManaBar : MonoBehaviour
{
    public Image manaImage;

    void Update()
    {
        if(GameManager.Inst.playerStat.mp < GameManager.Inst.playerStat.maxMp) 
            GameManager.Inst.playerStat.mp += GameManager.Inst.playerStat.mpSpeed * Time.deltaTime;
    }

    public void SetMana(float currentMana, float maxMana)
    {
        manaImage.fillAmount = currentMana / maxMana;
    }
}
