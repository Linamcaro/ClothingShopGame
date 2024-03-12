using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private float speed;
    [SerializeField] private float moveDistance;

    private bool isFacingRight = true;

    public bool isWalking = false;

    private Vector3 targetPosition;

    private Camera mainCamera;

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
            MoveToPosition();
       
        }

        MovePlayer();

    }

    private void MoveToPosition()
    {

        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(PlayerControls.Instance.MousePosition());

        // convert world coordinates to tilemaps coordinates. 
        Vector3Int gridposition = map.WorldToCell(mousePosition);

        //Check if player click the cell
        if (map.HasTile(gridposition))
        {
            targetPosition = mousePosition;

        }

    }

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

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

}
