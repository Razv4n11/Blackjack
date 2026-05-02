using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UIElements.Experimental;

public class CameraController : MonoBehaviour
{
    private Vector3 cameraSize = new Vector3 { x = 5, y = 10 };
    private List<Button_Click> enabledButtons = new List<Button_Click>();
    private List<Button_Click> buttons;
    private bool dragging = false;
    private float speed;
    private float acceleration = 0.02f;
    public GameObject anchor;

    void Start()
    {
        Application.targetFrameRate = 60;

        float screenRatio = (float)Screen.width / Screen.height;
        float targetRatio = cameraSize.x / cameraSize.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = cameraSize.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = cameraSize.y / 2 * differenceInSize;
        }

        buttons = FindObjectsByType<Button_Click>(FindObjectsSortMode.None).ToList();
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.touchCount >= 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    enabledButtons = buttons.FindAll(button => button.enabled);
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
                    if (hit.transform != null)
                    {
                        if (hit.transform.gameObject == GameObject.Find("Board"))
                        {
                            enabledButtons.ForEach(button => button.enabled = false);
                            dragging = true;
                        }
                    }
                }

                else if (Input.GetTouch(0).phase == TouchPhase.Moved && dragging)
                {
                    speed = -Input.GetTouch(0).deltaPosition.x / 200;
                    if (speed > 0.75f)
                        speed = 0.75f;
                    else if (speed < -0.75f)
                        speed = -0.75f;

                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + speed, Camera.main.transform.position.y, -10);
                    if (Camera.main.transform.position.x < anchor.transform.position.x)
                        Camera.main.transform.position = new Vector3(anchor.transform.position.x, Camera.main.transform.position.y, -10);
                    else if (Camera.main.transform.position.x > 0)
                        Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, -10);

                }

                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    enabledButtons.ForEach(button => button.enabled = true);
                    dragging = false;
                }
            }

            else if (Camera.main.transform.position.x > anchor.transform.position.x && Camera.main.transform.position.x < 0)
            {
                float middle = anchor.transform.position.x / 2;
                if (Camera.main.transform.position.x > middle)
                    speed += acceleration;
                else
                    speed -= acceleration;

                if (speed > 0.75f)
                    speed = 0.75f;
                else if (speed < -0.75f)
                    speed = -0.75f;

                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + speed, Camera.main.transform.position.y, -10);
                if (Camera.main.transform.position.x < anchor.transform.position.x)
                    Camera.main.transform.position = new Vector3(anchor.transform.position.x, Camera.main.transform.position.y, -10);
                else if (Camera.main.transform.position.x > 0)
                    Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, -10);
            }
        }
    }
}
