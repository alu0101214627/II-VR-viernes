using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterControler : MonoBehaviour
{
    private float MoveSpeed = 0.25f;
    public float HP = 10; 
    public delegate void mensaje();
    public event mensaje Aumentar;
    public event mensaje nearSpiders;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /**
        Debug part used to move the alien and test
        */
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float horSpeed = horizontal * MoveSpeed;
        float verSpeed = vertical * MoveSpeed;
        gameObject.transform.Translate(horSpeed, 0, verSpeed);
        /**
        Finished the debug part
        */
        if (Input.GetKeyDown("t")) {
            Vector3 randomPosition = new Vector3 (Random.Range(-10, 10), 0, Random.Range(-10, 10));
            gameObject.transform.position = randomPosition;
        }
        nearSpiders();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Chest") {
            Aumentar();
        }
    }
}
