using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using XboxCtrlrInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use


        public XboxController controller;


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }




        private void FixedUpdate()
        {
            // new input
            float h = XCI.GetAxis(XboxAxis.LeftStickX, controller);
            float v = 0f;
            if (XCI.GetAxis(XboxAxis.RightTrigger, controller) > 0)
            {
                v = XCI.GetAxis(XboxAxis.RightTrigger, controller);
            }
            else
            {
                v = XCI.GetAxis(XboxAxis.LeftTrigger, controller) * -1;
            }
            float handbrake = 0f;
            if (XCI.GetButton(XboxButton.B, controller))
            {
                handbrake = 1f;
            }
            else
            {
                handbrake = 0f;
            }

            // pass the input to the car!
            //float h = CrossPlatformInputManager.GetAxis(horizontal);
            //float v = CrossPlatformInputManager.GetAxis(vertical);
#if !MOBILE_INPUT
            //float handbrake = CrossPlatformInputManager.GetAxis(brake);
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }



}
