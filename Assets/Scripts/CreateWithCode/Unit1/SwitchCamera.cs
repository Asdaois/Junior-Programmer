using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit1
{
    public class SwitchCamera : MonoBehaviour
    {
        [SerializeField] private FollowTransform defaultCameraPosition;
        [SerializeField] private FollowTransform alternativeCameraPosition;
        [SerializeField] private bool isDefault = true;
        [SerializeField] private KeyCode switchKey;

        // Start is called before the first frame update
        private void Start()
        {
            defaultCameraPosition.enabled = true;
            alternativeCameraPosition.enabled = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyUp(switchKey))
            {
                Toggle();
            }
        }

        private void Toggle()
        {
            isDefault = !isDefault;

            if (isDefault)
            {
                defaultCameraPosition.enabled = true;
                alternativeCameraPosition.enabled = false;
            }
            else
            {
                defaultCameraPosition.enabled = false;
                alternativeCameraPosition.enabled = true;
            }
        }
    }
}