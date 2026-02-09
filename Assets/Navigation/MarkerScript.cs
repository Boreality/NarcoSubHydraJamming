using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarkerScript : MonoBehaviour
{
    public int Number = 1;
    public TextMeshProUGUI TextField;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextField.text = Number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
