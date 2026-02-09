using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float range = 3f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,range);
    }


    

    public virtual void Activate()
    {
        //to be overwriten.
    }

    public virtual bool CanBeInteractedWith()
    {
        return true;
        //override
    }
}
