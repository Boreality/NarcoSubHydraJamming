using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class Fade : MonoBehaviour
{
    public Animator animator;
    public float fadeSpeed;

    [YarnCommand("fade_out")]
    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
    [YarnCommand("fade_in")]
    public void FadeIn()
    {
        animator.SetTrigger("FadeIn");
    }


}
