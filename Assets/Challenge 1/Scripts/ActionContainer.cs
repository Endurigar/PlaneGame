using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionContainer
{
    public static Action OnRestart;
    public static Action OnCoinTriggerEnter;
    public static Action OnHit;
    public static Action OnMove;
    public static Action<bool> OnEffectsStateChanged; 
}
