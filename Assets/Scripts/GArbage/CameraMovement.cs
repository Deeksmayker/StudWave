using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 0.1f;
    private Vector3 lastPosMove = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovingLogic();
        CameraZoomLogic();
    }

    public void CameraMovingLogic()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = new Vector3(touch.position.x, touch.position.y, 0f);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 moveDelta = (lastPosMove - touchPos) * cameraSpeed;
                transform.Translate(moveDelta);
            }

            lastPosMove = touchPos;
        }
    }

    public void CameraZoomLogic()
    {
        if (Input.touchCount == 2)
        {
            Touch zoomOne = Input.GetTouch(0);
            Touch zoomTwo = Input.GetTouch(1);

            Vector2 zoomOnePrev = zoomOne.position - zoomOne.deltaPosition;
            Vector2 zoomTwoPrev = zoomTwo.position - zoomTwo.deltaPosition;

            var prevTouchDeltaMag = (zoomOnePrev - zoomTwoPrev).magnitude;
            var touchDeltaMag = (zoomOne.position - zoomTwo.position).magnitude;

            var deltaMagnitudeDiff = -(prevTouchDeltaMag - touchDeltaMag);

            transform.Translate(0, 0, deltaMagnitudeDiff);
        }
    }
}
