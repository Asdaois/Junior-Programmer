using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit1
{
    public class SwitchCamera : MonoBehaviour
    {
        [SerializeField] FollowTransform defaultCameraPosition;
        [SerializeField] FollowTransform alternativeCameraPosition;
        [SerializeField]    bool isDefault = true;
        [SerializeField] KeyCode switchKey;

        // Start is called before the first frame update
        void Start()
        {
            defaultCameraPosition.enabled = true;
            alternativeCameraPosition.enabled = false;

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(switchKey)) {
                Toggle();
            }

        }

        void Toggle()
        {
            isDefault = !isDefault;

            if (isDefault)
            {
                defaultCameraPosition.enabled = true;
                alternativeCameraPosition.enabled = false;
            } else
            {
                defaultCameraPosition.enabled = false;
                alternativeCameraPosition.enabled = true;
            }
        }

    }
}