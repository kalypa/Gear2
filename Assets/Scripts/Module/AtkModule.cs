using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AtkModule<T> : MonoBehaviour
{
    protected T animator;
    public bool isAtk = true;
    public bool isDead = false;
    public float attackRadius;

    protected virtual void Start() => animator = GetComponent<T>();
}
