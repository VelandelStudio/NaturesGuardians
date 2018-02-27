using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputTest : MonoBehaviour {

    public void Update()
    {
        //for (int i = 0; i < Input.touchCount; ++i)
        //{
        //    if (Input.GetTouch(i).phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Hello penis touch");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (EventSystem.current.IsPointerOverGameObject())    // is the touch on the GUI
            {
                return;
            }

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.GetComponent<ToucheableElement>())
                {
                    hitInfo.collider.GetComponent<ToucheableElement>().ActionOnTouch();
                }
            }
        }
    }
}
