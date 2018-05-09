using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeActiveStatusBtn : MonoBehaviour {

    [SerializeField] List<GameObject> toActive = new List<GameObject>();
    [SerializeField] List<GameObject> toDeActive = new List<GameObject>();

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ShowAndHide);
    }

    public void ShowAndHide()
    {
        if (toActive.Count > 0)
        {
            foreach (GameObject objects in toActive)
            {
                objects.SetActive(true);
            }
        }
        if (toDeActive.Count > 0)
        {
            foreach (GameObject objects in toDeActive)
            {
                objects.SetActive(false);
            }
        }
    }
}
