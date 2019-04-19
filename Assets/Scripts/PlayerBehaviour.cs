using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        float xMovement = xPos * speed * Time.deltaTime;
        float yMovement = yPos * speed * Time.deltaTime;

        float xMove = transform.localPosition.x + xMovement;
        float yMove = transform.localPosition.y + yMovement;
        transform.localPosition = new Vector3(xMove, yMove);
    }
}
