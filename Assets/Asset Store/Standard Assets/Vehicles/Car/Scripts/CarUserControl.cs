using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Rewired;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        private Player player;
        public int playerNum;


        private void Awake()
        {
            player = ReInput.players.GetPlayer(playerNum);
            // get the car controller
            m_Car = GetComponent<CarController>();
        }




        private void FixedUpdate()
        {
            // new input
            float h = player.GetAxis("Turn");
            float v = 0f;
            if (player.GetAxis("Accelerate") > 0)
            {
                v = player.GetAxis("Accelerate");
            }
            else
            {
                v = player.GetAxis("Brake");
            }
            float handbrake = 0f;
            //if (player.GetButton("Handbrake"))
            //{
            //    handbrake = 1f;
            //}
            //else
            //{
            //    handbrake = 0f;
            //}

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
