using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TungMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        //For override
    }
}
