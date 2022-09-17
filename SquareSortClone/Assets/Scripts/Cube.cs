using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube: MonoBehaviour
{
    public Rigidbody rb;
    private Vector2 firstPos, lastPos;
    public Vector2 currentPos;
    public float moveSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Swipe();
    }
   
    public IEnumerator velocityZero()
    {
        yield return new WaitForSeconds(0.25f);
        currentPos.Set(0, 0);
        //currentPos.Normalize();
    }
    private void Swipe()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }
        if (Input.GetMouseButtonUp(0))
        {
            lastPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentPos = new Vector2(lastPos.x - firstPos.x, lastPos.y - firstPos.y);
        }
        currentPos.Normalize();
        
        if (currentPos.y < 0 && currentPos.x < 0.5f && currentPos.x > -0.5f)
        {
            //down
            rb.velocity = Vector3.back * moveSpeed;
            //rb.AddForce(Vector3.back * moveSpeed);
        }
        else if (currentPos.y > 0 && currentPos.x < 0.5f && currentPos.x > -0.5f)
        {
            //up 
            rb.velocity = Vector3.forward * moveSpeed;
            //rb.AddForce(Vector3.forward * moveSpeed);
        }
        else if (currentPos.x < 0 && currentPos.y < 0.5f && currentPos.y > -0.5f)
        {
            // left 
            rb.velocity = Vector3.left * moveSpeed;
            //rb.AddForce(Vector3.left * moveSpeed);
        }
        else if (currentPos.x > 0 && currentPos.y < 0.5f && currentPos.y > -0.5f)
        {
            //right
            rb.velocity = Vector3.right * moveSpeed;
            //rb.AddForce(Vector3.right * moveSpeed);
        }
        else if (currentPos.x == 0 && currentPos.y == 0)
        {
           
            rb.velocity = Vector3.zero;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {   
       
        if(collision.gameObject.tag == "Wall" && collision.gameObject.GetComponent<MeshRenderer>().material.color== this.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject)
        {
            //currentPos.Set(0, 0);
            StartCoroutine(velocityZero());
        }
    }
    




}
