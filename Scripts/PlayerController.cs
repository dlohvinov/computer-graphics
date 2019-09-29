using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 25f;
    private float turnSpeed = 160f;

    private float missleSpeed = 4*1000;
    private float reloadTime = 0.4f;
    private float reloadReady;

    [SerializeField]
    private GameObject missle;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        reloadReady = Time.time + reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Space) && Time.time > reloadReady)
        {
            reloadReady = Time.time + reloadTime;
            GameObject missleInstance = 
                Instantiate(missle, player.transform.position, player.transform.rotation);
            Rigidbody rigidbodyInstance = missleInstance.GetComponent<Rigidbody>();
            rigidbodyInstance.AddForce(transform.forward * missleSpeed);
            Destroy(missleInstance, 3f);
        
        }
    }
}
