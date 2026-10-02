using UnityEngine;
using UnityEngine.InputSystem;
public class AvatarMovement : MonoBehaviour
{
    [SerializeField] MeshRenderer obsRend;
    [SerializeField] MeshRenderer obsRend2;
    [SerializeField] MeshRenderer pformRend1;
    [SerializeField] MeshRenderer pformRend2;
    [SerializeField] MeshRenderer pformRend3;

    int ctr = 0;

    [SerializeField] MeshRenderer capRend;

    CharacterController avatarCont;
    float jump;
    bool canJump;

    void Start()
    {
        avatarCont = GetComponent<CharacterController>();
        canJump = false;
        jump = 0;
        obsRend.material.color = Color.white;
    }
    void Update()
    {
        // JUMP
        if (canJump)
        {
            if (Keyboard.current.spaceKey.isPressed && avatarCont.isGrounded)
            {
                jump = 0.8f;
            }

        }
        
        // GRAVITY
        if (!avatarCont.isGrounded)
        {
            jump -= 0.05f;
        }
        else
        {
            if (jump < 0)
            {
                jump = 0;
            }
        }
        float movX = 0;
        float movZ = 0;
        // MOVEMENT
        if (Keyboard.current.aKey.isPressed)
        {
            movX = -0.05f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            movX = 0.05f;
        }
        if (Keyboard.current.wKey.isPressed)
        {
            movZ = 0.05f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            movZ = -0.05f;
        }

        // SHRINK
        if (Keyboard.current.kKey.isPressed)
        {
            avatarCont.height = 0.3f;
            //transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

      
        if (Keyboard.current.kKey.wasReleasedThisFrame) {
            avatarCont.height = 2f;
        }



        // MOVE
        avatarCont.Move(
            transform.TransformDirection(
                new Vector3(movX, jump, movZ)
            )
        );
        // ROTATE WITH MOUSE
        if (Mouse.current != null)
        {
            float rotY = Mouse.current.delta.ReadValue().x;
            transform.Rotate(0, rotY, 0);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {


        // OBS 1
        if (hit.collider.name == "obs")
        {
            obsRend.material.color = new Color[]
            {
               Color.red,
               Color.green,
               Color.blue
            }[Random.Range(0, 3)];
        }
        // OBS 2
        if (hit.collider.name == "obs2")
        {
            obsRend2.material.color = new Color[]
            {
               Color.red,
               Color.green,
               Color.blue
            }[Random.Range(0, 3)];
        }
        // IF BOTH HAVE THE SAME COLOR
        if (obsRend.material.color == obsRend2.material.color)
        {
            
            avatarCont.radius = 0.1f;
        }

        if (hit.collider.name == "Capsule")
        {
            canJump = true;
            Destroy(hit.gameObject);
        }

        if (hit.collider.name == "Platform 6")
        {
            pformRend1.material.color = new Color[]
            {
               Color.red,
               Color.green,
               Color.blue
            }[Random.Range(0, 3)];
        }

        if (hit.collider.name == "Platform 6 (1)")
        {
            pformRend2.material.color = new Color[]
            {
               Color.red,
               Color.green,
               Color.blue
            }[Random.Range(0, 3)];
        }
        if (hit.collider.name == "final platform")
        {
            pformRend3.material.color = new Color[]
            {
               Color.red,
               Color.green,
               Color.blue
            }[Random.Range(0, 3)];

            avatarCont.minMoveDistance = 1;
        }
        if (hit.collider.name == "token")
        {
            ctr++;
            Destroy(hit.gameObject);
        }
        if (ctr >= 3)
        {
            CharacterController avatarCont = GetComponent<CharacterController>();
            avatarCont.stepOffset = 1;
        }
    }
}
