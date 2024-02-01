using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    public Camera myCamera;
    private Touch oldTouch1, oldTouch2;
    private float oldTouchDistance;
    public TextMeshPro text;
    //private float maxYCamera = 250f;
    //private float minYCamera = 50f;

    private float minSizeCamera = 5;
    private float maxSizeCamera = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = myCamera.transform.position.y.ToString();

        text.text = myCamera.orthographicSize.ToString();

        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);

        // Tính khoảng cách giữa 2 điểm touch
        float currentTouchDistance = Vector2.Distance(touch1.position, touch2.position);

        // Nếu đang thực hiện pinch/zoom
        if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
        {
            float newAddY = currentTouchDistance / 30;

            // So sánh khoảng cách trước và sau
            if (currentTouchDistance > oldTouchDistance)
            {
                //float newY = myCamera.transform.position.y - newAddY;
                //if (newY < minYCamera)
                //{
                //    newY = minYCamera;
                //}

                //// Thu nhỏ camera
                //myCamera.transform.position = new Vector3(myCamera.transform.position.x, newY, myCamera.transform.position.z);

                myCamera.orthographicSize = myCamera.orthographicSize - newAddY;
                if (myCamera.orthographicSize < minSizeCamera)
                {
                    myCamera.orthographicSize = minSizeCamera;
                }

            }
            else if (currentTouchDistance < oldTouchDistance)
            {
                //float newY = myCamera.transform.position.y + newAddY;
                //if (newY > maxYCamera)
                //{
                //    newY = maxYCamera;
                //}

                // Phóng to camera
                //myCamera.transform.position = new Vector3(myCamera.transform.position.x, newY, myCamera.transform.position.z);
                myCamera.orthographicSize = myCamera.orthographicSize + newAddY;
                if (myCamera.orthographicSize > maxSizeCamera)
                {
                    myCamera.orthographicSize = maxSizeCamera;
                }

            }
            //myCamera.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y + currentTouchDistance, myCamera.transform.position.z);
        }

        // Lưu lại các giá trị cũ 
        oldTouch1 = touch1;
        oldTouch2 = touch2;
        oldTouchDistance = currentTouchDistance;
    }
}
