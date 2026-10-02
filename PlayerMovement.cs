using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour

{

    Transform playerTrans;

    // Start is called once before the first execution of Update after the MonoBehaviour is created 

    void Start()

    {

        playerTrans = GetComponent<Transform>();

    }



    // Update is called once per frame 

    void Update()

    {

        PlayerDrop pd = GetComponent<PlayerDrop>();



        if (pd.GetCollision())

        {

            if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)

            {

                playerTrans.Translate(.05f, 0, 0);

            }

            if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)

            {

                playerTrans.Translate(-.05f, 0, 0);

            }

            if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)

            {

                playerTrans.Translate(0, 0, -.05f);

            }

            if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)

            {

                playerTrans.Translate(0, 0, .05f);

            }

            // for jump
         
            if (Keyboard.current.spaceKey.isPressed)

            {

                playerTrans.Translate(0, 3, 0);

            }

        }

    }

}
