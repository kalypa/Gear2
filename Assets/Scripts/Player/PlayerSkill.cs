using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public List<ParticleSystem> SkillList = new();
    public void OnClickMainSkillbutton()
    {
        SkillList[0].gameObject.SetActive(true);
    }

    void MainSkill()
    {

    }
}
