using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class NavigationScript : MonoBehaviour
{
    Vector2 Location = new Vector2(0,0);
    Vector2 StartLocation = new Vector2(200,500);
    Vector2 TargetLocation = new Vector2(783,137);
    float Speed = 200;
    int Bearing = 45;

    public Canvas Self;

    int ProgressIndex = 0;
    public Image[] Markers;

    bool ShouldInputBearing = true;
    public TMP_InputField BearingInputField;

    public bool StartShowingMap;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Location = StartLocation;
        BearingInputField.enabled = false;
        ShowHideMap(StartShowingMap);
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

    [YarnCommand("move_sub")]
    public void MoveSub(int Angle, float Distance)
    {
        Location += new Vector2(Mathf.Sin(Bearing),Mathf.Cos(Angle)) * Distance;
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

    [YarnCommand("end_nav_sequence")]
    public void EndSequence()
    {
        ShowHideMap(false);

        if (ShouldInputBearing)
        {
            MoveSub(Bearing, Speed);
        }
        else
        {
            
        }
    }

    [YarnCommand("start_nav_sequence")]
    public void StartSequence(bool InputBearing)
    {
        ShowHideMap(true);

        if (ShouldInputBearing)
        {
            BearingInputField.enabled = true;
        }
        else
        {
            
        }
    }

    void ConfirmBearingNumber()
    {
        Bearing = int.Parse(BearingInputField.text);
    }
}
