using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public void levelTransitionStart()
    {
        transition.SetTrigger("Start");
    }

    public void levelTransitionEnd()
    {
        transition.SetTrigger("End");
    }

}
