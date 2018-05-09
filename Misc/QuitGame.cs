using UnityEngine;

public class QuitGame : MonoBehaviour {

    public static QuitGame Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
