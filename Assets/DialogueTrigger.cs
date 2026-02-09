using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Yarn.Unity;

public class DialogueTrigger : Interactable
{

    public DialogueRunner dr;
    public string StartNode;
    
    //Needs to be modified in the yarn script
    public bool Repeatable = false;
    private bool played = false;

    public float Cooldown = 0.5f;
    private bool isOnCooldown = false;


    [YarnCommand("set_played")]
    public void SetPlayed(bool Played)
    {
        played = Played;
    }

    [YarnCommand("set_repeatable")]
    public void Set_Repeatable(bool repeatable)
    {
        Repeatable = repeatable;
    }

    public override bool CanBeInteractedWith()
    {
        return !isOnCooldown && !dr.IsDialogueRunning && ((!played) || (played && Repeatable));
    }

    public override void Activate()
    {
        if (CanBeInteractedWith())
        {
            dr.StartDialogue(StartNode);
            played = true;
            StartCoroutine(DialogueDelay());
        }
       
    }

    private IEnumerator DialogueDelay()
    {
        isOnCooldown=true;
        yield return new WaitForSecondsRealtime(Cooldown);
        isOnCooldown=false;
    }
}
