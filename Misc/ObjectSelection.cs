using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectSelection : MonoBehaviour {

    public TextMeshProUGUI CurObjectName;

    int furnitureIndex;
    public List<GameObject> AvailableFurnitures = new List<GameObject>();

    public void NextObject()
    {
        if(furnitureIndex < AvailableFurnitures.Count-1)
        {
            furnitureIndex++;
        }
        else
        {
            furnitureIndex = 0;
        }
        CurObjectName.text = AvailableFurnitures[furnitureIndex].gameObject.name;
        GetComponent<CreateFurniture>().Object = AvailableFurnitures[furnitureIndex];
    }
}
