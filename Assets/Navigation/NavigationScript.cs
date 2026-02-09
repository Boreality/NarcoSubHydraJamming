using UnityEngine;
using UnityEngine.UI;

public class NavigationScript : MonoBehaviour
{
    Vector2 Location = new Vector2(0,0);
    Vector2 StartLocation = new Vector2(200,500);
    Vector2 TargetLocation = new Vector2(783,137);
    float Bearing = 45;
    public Image MapImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Location = StartLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowHideMap(bool Show)
    {
        MapImage.enabled = Show;
    }

    void MoveSub()
    {
        
    }
}
