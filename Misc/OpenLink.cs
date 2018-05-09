using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenLink : MonoBehaviour {
    
    public string Link;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OpenUrlLink);
    }

    public void OpenUrlLink()
    {
        Application.OpenURL(Link);
    }
}
