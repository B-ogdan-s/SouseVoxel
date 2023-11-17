using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void StartState() { }
    public virtual void StopState() { }
}
