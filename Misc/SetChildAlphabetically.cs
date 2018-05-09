using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChildAlphabetically : MonoBehaviour {

    [SerializeField] List<GameObject> content = new List<GameObject>();

    private void Awake()
    {
        content.Sort((x, y) => x.name.CompareTo(y.name));
        for(int i = 0; i < content.Count; i++)
        {
            content[i].transform.SetSiblingIndex(i);
        }
    }
}
