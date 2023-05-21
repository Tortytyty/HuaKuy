using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
   [SerializeField] public float playerspeed;
   [SerializeField] public float rotSpeed;
   [SerializeField] public GameInput gameInput;
   private float playerHeight = 2f;
    private float playerRadius = 0.7f;
   private bool isWalking;

   public bool GetIsWalking(){
    return isWalking;
   }
   private void Move() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        
        Vector3 moveDir = new Vector3(inputVector.x,0,inputVector.y);

        float moveDistance = playerspeed* Time.deltaTime;

        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up*playerHeight,playerRadius,moveDir,moveDistance);
        if (!canMove) {
            Vector3 moveDirx = new Vector3(moveDir.x,0,0).normalized;
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position,transform.position + Vector3.up*playerHeight,playerRadius,moveDirx,moveDistance);
            if (canMove) {
                moveDir = moveDirx;
            }
            else {
                Vector3 moveDirZ = new Vector3(0,0,moveDir.z).normalized;
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position,transform.position + Vector3.up*playerHeight,playerRadius,moveDirZ,moveDistance);
                if (canMove) {
                    moveDir = moveDirZ;
                } else {
                    // DO nothing
                }
            }
        }
        if(canMove) {
            transform.position += moveDir * moveDistance;
        }
        isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward,moveDir,rotSpeed *Time.deltaTime);
    }
    void Update()
    {
      Move();
    }
    
}
