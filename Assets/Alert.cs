using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    public string msg = "";
    public GameObject msgUI;

    void Start()
    {
        msgUI.GetComponent<Text>().text = msg;
    }

    void Update()
    {
        
    }

    public void CheckButtonClicked()
    {
        Destroy(gameObject);
    }
}
