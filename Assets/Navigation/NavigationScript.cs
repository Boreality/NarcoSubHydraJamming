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

    public Canvas Self;

    int ProgressIndex = 0;
    public Image[] Markers;

    bool ShouldInputBearing = true;
    public InputField BearingInputField;

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
        if (Input.GetKey(KeyCode.Space))
        {
            EndSequence();
        }
        if (Input.GetKey(KeyCode.Return))
        {
            ConfirmBearingNumber();
        }
    }

    void ShowHideMap(bool Show)
    {
        Self.enabled = Show;
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

        NewPosition = Input.mousePosition;
        MarkerToMove.transform.position = NewPosition;
        Debug.Log(NewPosition);
    }

    void EndSequence()
    {
        ShowHideMap(false);
    }

    void StartSequence(bool InputBearing)
    {
        ShowHideMap(true);

        
    }

    void ConfirmBearingNumber()
    {
        Bearing = float.Parse(BearingInputField.text);
    }
}
