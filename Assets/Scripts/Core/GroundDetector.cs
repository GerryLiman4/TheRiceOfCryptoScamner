using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
   
    [SerializeField] private LayerMask groundLayer;
    [field: SerializeField] private Vector2 widthDetection = new Vector2(0.6f, -0.001f);
    [SerializeField] private float distance = 0.001f;
    [field: SerializeField] public bool isGrounded { get;private set; }

    public bool CheckGround() {

        RaycastHit2D hitGround = Physics2D.BoxCast(transform.position, widthDetection, 0f, Vector2.down, distance, groundLayer);
        isGrounded = hitGround.collider != null ;
        return isGrounded;
    }
}
