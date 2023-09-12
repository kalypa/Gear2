using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AtkModule<T> : MonoBehaviour
{
    protected T animator;
    protected bool isAtk = true;
    public float attackRadius;

    protected virtual void Start()
    {
        animator = GetComponent<T>();
    }
}
