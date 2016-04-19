using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
		public int collisionSpeed;
        private CarController m_Car; // the car controller we want to use
		private CarAudio carSound;
		private bool crashed;


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
			carSound = GetComponent<CarAudio>();
			crashed = false;
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			if(!crashed)
				m_Car.Move(h, v, v, handbrake);
			else
				m_Car.Move(0, 0, 0, 0);
#else
			if(!crashed)
			{
           		m_Car.Move(h, v, v, 0f);
			}
#endif
        }

		void OnCollisionEnter(Collision col)
		{
			if (col.relativeVelocity.magnitude >= collisionSpeed) 
			{
				crashed = true;
				carSound.maxRolloffDistance = 0;
			}
		}
    }
}
