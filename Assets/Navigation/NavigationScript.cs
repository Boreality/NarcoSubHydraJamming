using System;
using UnityEngine;
using UnityEngine.UI;

public class NavigationScript : MonoBehaviour
{
    Vector2 Location = new Vector2(0,0);
    Vector2 StartLocation = new Vector2(200,500);
    Vector2 TargetLocation = new Vector2(783,137);
    float Speed = 200;

    float Bearing = 45;
    public Image MapImage;

    int ProgressIndex = 0;
    public Image[] Markers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Location = StartLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveMarker();
        }
    }

    void ShowHideMap(bool Show)
    {
        MapImage.enabled = Show;
    }

    void MoveSub()
    {
        Location += new Vector2(Mathf.Sin(Bearing),Mathf.Cos(Bearing)) * Speed;
        Debug.Log(Location);
        CheckIfAtTarget();
    }

    void CheckIfAtTarget()
    {
        if (Vector2.Distance(Location, TargetLocation) <= 30)
        {
            //win function goes here
            Debug.Log("WON");
        }
    }

    void MoveMarker()
    {
        Debug.Log("moved marker");
        Image MarkerToMove = Markers[ProgressIndex];
        Vector2 NewPosition;

        NewPosition = Camera.main.ViewportToScreenPoint(Input.mousePosition);
    }
}
