using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateEnd : StateMachineBehaviour
{

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { //애니메이션 끝났을 때 변신 종료
        GameManager.Inst.playerTransform.isTransform = false;
    }

    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

}
