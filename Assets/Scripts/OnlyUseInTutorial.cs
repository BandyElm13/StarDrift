using UnityEngine;

public class OnlyUseInTutorial : MonoBehaviour
{
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;

    [SerializeField] private CharacterController characterController;

    void Update()
    {
        if (!characterController.isGrounded)
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }
        else
        {
            playerVelocity.y = 0f;
        }

        characterController.Move(playerVelocity * Time.deltaTime);
    }
}
