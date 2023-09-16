using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WhitePassive : MonoBehaviour
{
    public SpriteRenderer player;
    private Vector2 originPos;
    private SpriteRenderer spriteRenderer;
    private bool isMove = false;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Move() // 검기 이동
    {
        transform.localPosition = new Vector2(0, 0.5f);
        isMove = true;
        float xPos = player.flipX == false ? 5 : -5;
        spriteRenderer.flipX = player.flipX;
        Tween tween = transform.DOLocalMoveX(xPos, 0.5f)
            .OnComplete(()=> isMove = false);
        DOTween.Kill(tween);
    }
    private void Update() => CollisionCheck();
    void CollisionCheck() //검기와 적이 충돌했는지 체크하고 충돌했다면 데미지 주기
    {
        if(isMove)
        {
            var gm = GameManager.Inst;
            BoxCollider2D myCollider = GetComponent<BoxCollider2D>();

            Vector2 overlapBoxSize = myCollider.bounds.size;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, overlapBoxSize, 0f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Monster") && !collider.GetComponent<MonsterAtk>().isDead)
                {
                    collider.GetComponent<MonsterEvent>().Damaged(collider.GetComponent<MonsterEvent>().currenthp, gm.playerStat.whitePassiveAtk);
                }
            }
        }
    }
}
