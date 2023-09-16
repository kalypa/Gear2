using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnd : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    { //스킬 애니메이션 종료 시 스킬 종료
        GameManager.Inst.playerskill.isSkillAtk = false;
    }
}
