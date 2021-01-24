using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public Rigidbody rb;
   public GameObject player;
    public float speed = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float translation = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float straffe = Input.GetAxis("Horizontal") / 4;

        transform.Translate(straffe, 0, translation);
       // rb.AddForce(0, 0, 2000 * Time.deltaTime);

        if ( player.transform.position.y < -1)
        {
            FindObjectOfType<GameManagerScript>().EndGame();
        }
    }
}
