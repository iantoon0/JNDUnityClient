using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class CameraDrag : MonoBehaviour
    {
        public float dragSpeed = 2;
        private Vector3 dragOrigin, oldPos;
        private bool bDragging;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                bDragging = true;
                oldPos = transform.position;
                dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);                    //Get the ScreenVector the mouse clicked
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - dragOrigin;    //Get the difference between where the mouse clicked and where it moved
                transform.position = oldPos + -pos * dragSpeed;                                         //Move the position of the camera to simulate a drag, speed * 10 for screen to worldspace conversion
            }

            if (Input.GetMouseButtonUp(0))
            {
                bDragging = false;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
