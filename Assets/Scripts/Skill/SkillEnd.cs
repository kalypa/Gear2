using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEnd : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.Inst.playerskill.isSkillAtk = false;
    }
}
