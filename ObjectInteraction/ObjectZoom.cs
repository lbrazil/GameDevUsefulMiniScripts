using UnityEngine;

public class ObjectZoom : MonoBehaviour
{
    //MOBILE

    [SerializeField] float scaleFactor = 0.002f;

    [SerializeField] float minScale = .5f;
    [SerializeField] float maxScale = 2;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
            
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            
            transform.localScale -= new Vector3(deltaMagnitudeDiff * scaleFactor, deltaMagnitudeDiff * scaleFactor, deltaMagnitudeDiff * scaleFactor);
            
            transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, minScale, maxScale), Mathf.Clamp(transform.localScale.y, minScale, maxScale), Mathf.Clamp(transform.localScale.z, minScale, maxScale));
        }
    }
}
