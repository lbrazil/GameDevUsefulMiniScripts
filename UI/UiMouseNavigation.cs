using UnityEngine;
using UnityEngine.UI;

public class UiMouseNavigation : MonoBehaviour {

    [SerializeField] Button[] buttonsToNavigate;
    [SerializeField] int currentIndex = 0;

    private void OnEnable()
    {
        buttonsToNavigate = FindObjectsOfType<Button>();
    }

    void Update () {

        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            
            if (currentIndex == buttonsToNavigate.Length-1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
        }
        else if (d < 0f)
        {
            if (currentIndex == 0)
            {
                currentIndex = buttonsToNavigate.Length-1;
            }
            else
            {
                currentIndex--;
            }
        }

        buttonsToNavigate[currentIndex].Select();

        if(Input.GetMouseButtonDown(0))
        {
            buttonsToNavigate[currentIndex].onClick.Invoke();
        }
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.SetActive(false);
        }

    }
}
