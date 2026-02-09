using UnityEngine;
using Yarn.Unity;

public class NarrativeManager : MonoBehaviour
{
    public static NarrativeManager Instance {get; private set;}
    public void Awake()
    {
        if(Instance != null && Instance!= this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public DialogueRunner dialogueRunner;
    public PlayerMovement Player;
    public Transform SleepPosition;
    public Transform WakePosition;

    [YarnCommand("sleep")]
    public void Sleep()
    {
        Player.activeControls = false;
        Player.gameObject.transform.position = SleepPosition.position;
    }
    [YarnCommand("wake_up")]
    public void WakeUp()
    {
        Player.activeControls = true;
        Player.gameObject.transform.position = WakePosition.position;
    }

    //kickstart 
    private void Start()
    {
        Sleep();
        dialogueRunner.StartDialogue("Start");
    }

}
