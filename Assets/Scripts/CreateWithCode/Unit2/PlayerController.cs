using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 10f;
        [SerializeField] float horizontalInput;

        [SerializeField] float limitX = 15f;

        [SerializeField] GameObject projectilePrefab;

        void Update()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            float velocity = speed * horizontalInput * Time.deltaTime;
            transform.Translate(Vector3.right * velocity);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            }
        }

        private void LateUpdate()
        {
            if (transform.position.x >= limitX)
            {
                ChangePositionX(limitX);
            }

            if (transform.position.x <= -limitX)
            {
                ChangePositionX(-limitX);
            }
        }

        private void ChangePositionX(float aPositionX)
        {
            transform.position = new Vector3(
                aPositionX, transform.position.y, transform.position.z);
        }
    }
}