using System.Collections.Generic;
using UnityEngine;

public class ChangeActiveStatus : MonoBehaviour {

    [SerializeField] List<GameObject> toActive = new List<GameObject>();
    [SerializeField] List<GameObject> toDeActive = new List<GameObject>();

    private void OnMouseDown()
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
