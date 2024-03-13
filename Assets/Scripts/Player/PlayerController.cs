using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private float speed;
    [SerializeField] private float moveDistance;

    private Vector3 targetPosition;
    private Camera mainCamera;
    private Vector2 mousePosition;


    private bool isFacingRight = true;
    public bool isWalking = false;

    private void Awake()
    {

        mainCamera = Camera.main;

    }

    void Start()
    {
        targetPosition = transform.position;
    }



    void Update()
    {
        if (PlayerControls.Instance.MouseClick())
        {
            SetNewPosition();
            ObjectClicked();


        }

        MovePlayer();

    }

    /// <summary>
    /// Set the target position
    /// </summary>
    private void SetNewPosition()
    {

        mousePosition = mainCamera.ScreenToWorldPoint(PlayerControls.Instance.MousePosition());

        // convert world coordinates to tilemaps coordinates. 
        Vector3Int gridposition = map.WorldToCell(mousePosition);

        //Check if player click the cell
        if (map.HasTile(gridposition))
        {
            targetPosition = mousePosition;

        }

    }

    /// <summary>
    /// Move the player to the target position
    /// </summary>
    private void MovePlayer()
    {
        if (Vector3.Distance(transform.position, targetPosition) > moveDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            isWalking = true;
        }

        else isWalking = false;

        if (!isFacingRight && (transform.position.x - targetPosition.x) < 0)
        {
            Flip();
        }
        else if (isFacingRight && (transform.position.x - targetPosition.x) > 0)
        {
            Flip();
        }

    }

    /// <summary>
    /// Rotate the character's sprite
    /// </summary>
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    /// <summary>
    /// Check which object was clicked and called it's OnMouseClick function
    /// </summary>
    private void ObjectClicked()
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log("Hit collider: " + hit.collider.tag);

            IObjectClicked objectClicked = hit.collider.GetComponent<IObjectClicked>();

            if (objectClicked != null)
            {
                objectClicked.OnMouseClick();

                Debug.Log("objectClicked: " + objectClicked);

            }
        }

    }

}
