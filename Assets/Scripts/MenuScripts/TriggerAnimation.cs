using UnityEngine;
using System.Collections;

public class TriggerAnimation : MonoBehaviour {

    public Animator shipAnimator;

	public void AnimTrigger(string animName)
    {
        shipAnimator.SetBool(animName, true);
    }
}
