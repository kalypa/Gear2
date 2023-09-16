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
        3 => "���� ������ ���� �о����� �� ���ݸ��� ���ݷ��� <color=red>" +
        GameManager.Inst.playerStat.normalPassiveAtk.ToString() + "</color>��ŭ�� ���ظ� �߰��� �����ϴ�.",
        4 => "�ڽ� ������ ���鿡�� �ʴ� ���ݷ��� <color=red>" +
        GameManager.Inst.playerStat.darkPassiveAtk.ToString() + "</color>�� ���ϴ� ���ظ� �����ϴ�",
        5 => "3��° ���ݸ��� �ڽ� ������ ���鿡�� ���ظ� ������ �˱⸦ �߻��Ͽ� <color=red>" +
        GameManager.Inst.playerStat.whitePassiveAtk.ToString() + "</color>�� ���ϴ� ���ظ� �����ϴ�",
        _ => ""
    };

    string SetSkillInfoText() => infoIndex switch
    {
        0 => "�ڽ� ������ ���鿡�� <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>��ŭ�� ���ظ� �߰��� �����ϴ�.",
        1 => "�ߵ� �� ���� ����� ���� ������ �����Ͽ� ���� ���� ���鿡�� <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>�� ���ϴ� ���ظ� �����ϴ�",
        2 => "�ߵ� �� ���� ����� ���� �������� ���� �߻��Ͽ� ���� ���� ���鿡�� <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>�� ���ϴ� �������� �����ϴ�",
        3 => "��� ���� ���� ���°� �Ǹ� ������ ���� �� ���� ���鿡�� <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>��ŭ�� ���ظ� �����ϴ�.",
        4 => "��� ���� ���� ���°� �Ǹ� ������ ���� �� ���� ���鿡�� <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>�� ���ϴ� ���ظ� �����ϴ�",
        5 => "��� ���� ���� ���°� �Ǹ� ������ ���� �� ���� ���鿡�� <color=red>" +
        skills[infoIndex].damage.ToString() + "</color>�� ���ϴ� ���ظ� �����ϴ�",
        _ => ""
    };

}
