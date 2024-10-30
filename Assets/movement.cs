using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class movement : MonoBehaviour

{
    // Start is called before the first frame update
    Vector2 moveVector;
    public float moveSpeed = 8f;

   public void InputPlayer(InputAction.CallbackContext _context)
    {
        moveVector = _context.ReadValue<Vector2>();   
    }

    // Update is called once per frame
   public void Update()
    {
        Vector3 movement = new Vector3(moveVector.x, 0, moveVector.y);
        transform.Translate(moveSpeed * movement * Time.deltaTime);
    }
}
