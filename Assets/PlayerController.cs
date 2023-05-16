using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isSelectingDifficulty && Input.GetKeyDown(KeyCode.Escape)) GameManager.setPause(!GameManager.isPaused);
        if (GameManager.isPaused || GameManager.isGameOver) return;
        // Player Movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * y + transform.right * x;
        transform.position += movement * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? 10 : 5);
        
        // Player/Camera Rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mouseX, 0);
        camera.transform.Rotate(-mouseY, 0, 0);
        
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
        }




    }
}
