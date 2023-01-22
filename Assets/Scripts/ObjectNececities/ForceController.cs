using Assets.Scripts.ObjectNececities;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    [SerializeField] public GroundDetector groundDetector;
    [SerializeField] public float knockBackMultiplierX = 0.69f;
    [SerializeField] public float knockBackMultiplierY = 2f;
    public void GravityPull(StateID objectStateID, Rigidbody2D objectRigidBody, float fallStartingSpeed)
    {
        //if (!groundDetector.isOnGround)
        //{
        //    switch (objectStateID)
        //    {
        //        case StateID.Fall:
        //            if (objectRigidBody.velocity.y >= fallStartingSpeed)
        //            {
        //                objectRigidBody.velocity = new Vector2(0, fallStartingSpeed);
        //            }
        //            objectRigidBody.gravityScale = 1 * 3f;
        //            break;
        //        default:
        //            objectRigidBody.gravityScale = 1 * 1.5f;
        //            break;
        //    }
        //}
        //else
        //{
        //    objectRigidBody.velocity = new Vector2(objectRigidBody.velocity.x, 0);
        //}
    }
    public void Stop(Rigidbody2D objectRigidBody){
        objectRigidBody.velocity = Vector2.zero;
    }
    public void KnockBack(Vector2 direction, Rigidbody2D objectRigidBody)
    {
        Vector2 knockBackForce = new Vector2(direction.x * knockBackMultiplierX, direction.y * knockBackMultiplierY);
        objectRigidBody.AddForce(knockBackForce);
    }
}
