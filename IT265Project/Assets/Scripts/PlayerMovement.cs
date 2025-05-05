using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Tiles currentTile;
    public float moveSpeed = 6f;
    private bool isMoving = false;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        if(currentTile != null){
            transform.position = currentTile.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            MoveToTarget();
            return;
        }

        //jch6 movement test with spacebar
        if(Input.GetKeyDown(KeyCode.Space)){
            if(currentTile.nextTiles.Count > 0){
                Tiles nextTile = currentTile.nextTiles[0];//jch6 will go with whatever is the first option
                targetPosition = nextTile.transform.position;
                currentTile = nextTile;
                isMoving = true;
            }
        }
    }

    void MoveToTarget(){
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPosition) < 0.01f){
            transform.position = targetPosition;
            isMoving = false;
        }
    }
}
