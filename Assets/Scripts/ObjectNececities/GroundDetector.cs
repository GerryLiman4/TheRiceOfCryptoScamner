using UnityEngine;

namespace Assets.Scripts.ObjectNececities
{
    public class GroundDetector : MonoBehaviour
    {
        [field: SerializeField] public bool isOnGround { get; private set; } = false;
        [field: SerializeField] private Vector2 widthDetection = new Vector2(0.6f, -0.001f);
        [SerializeField] private float distance = 0.001f;
        [SerializeField] private LayerMask defaultLayerMask;

        void Awake()
        {
            defaultLayerMask = LayerMask.GetMask("Default");
        }
        protected virtual void Update()
        {
            if (Physics2D.BoxCast(transform.position, widthDetection, 0f, Vector2.down, distance, defaultLayerMask))
            {
                isOnGround = true;
            }
            else
            {
                isOnGround = false;
            }

        }

        // void OnTriggerEnter2D(Collider2D other)
        // {
        //     isOnGround = true;
        // }

        // private void OnTriggerExit2D(Collider2D other)
        // {
        //     isOnGround = false;
        // }
    }
}