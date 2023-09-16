using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveModule<T> : MonoBehaviour
{
    public float MoveSpeed;
    protected float moveSpeed { get => MoveSpeed; set => MoveSpeed = value; }
    protected bool isChased = false;
    public bool isAtk = false;
    protected Transform target;
    protected Rigidbody2D rigidBody;
    protected T animator;
    public bool isDead = false;
    public abstract void Flip(float dir); // 스프라이트 X방향 반전
    public abstract void Move(); //이동
}
