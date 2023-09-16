using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInfoUI : MonoBehaviour
{
    public SkillStat[] skills = new SkillStat[7];
    private string passiveInfo;
    private string skillInfo;
    public int infoIndex;
    void Update()
    {
        passiveInfo = SetPassiveInfoText();
        skillInfo = SetSkillInfoText();
    }

    string SetPassiveInfoText() => infoIndex switch
    {
        3 => "공격 범위가 조금 넓어지며 매 공격마다 공격력의 <color=red>" +
        GameManager.Inst.playerStat.normalPassiveAtk.ToString() + "</color>만큼의 피해를 추가로 입힙니다.",
        4 => "자신 주위의 적들에게 초당 공격력의 <color=red>" +
        GameManager.Inst.playerStat.darkPassiveAtk.ToString() + "</color>에 달하는 피해를 입힙니다",
        5 => "3번째 공격마다 자신 전방의 적들에게 피해를 입히는 검기를 발사하여 <color=red>" +
        GameManager.Inst.playerStat.whitePassiveAtk.ToString() + "</color>에 달하는 피해를 입힙니다",
        _ => ""
    };

    string SetSkillInfoText() => infoIndex switch
    {
        0 => "자신 주위의 적들에게 <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>만큼의 피해를 추가로 입힙니다.",
        1 => "발동 시 가장 가까운 적의 주위를 공격하여 범위 내의 적들에게 <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>에 달하는 피해를 입힙니다",
        2 => "발동 시 가장 가까운 적의 방향으로 빛을 발사하여 범위 내의 적들에게 <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>에 달하는 데미지를 입힙니다",
        3 => "잠시 동안 무적 상태가 되며 변신이 끝난 후 주위 적들에게 <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>만큼의 피해를 입힙니다.",
        4 => "잠시 동안 무적 상태가 되며 변신이 끝난 후 주위 적들에게 <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>에 달하는 피해를 입힙니다",
        5 => "잠시 동안 무적 상태가 되며 변신이 끝난 후 주위 적들에게 <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>에 달하는 피해를 입힙니다",
        _ => ""
    };

}
