using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Raygun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float coolOnSeconds = 0.2f;
    public float cooldownSeconds = 0.5f;
    public float cooldown = 0f;
    public float coolOn = 0f;
    public bool isOn;
    public Color color = Color.red;
    
    public bool isTriShot = false;
    public bool isSlow = false; // Ray's move through the air, instead of instantly
    // public bool isBouncy = false; // Ray's bounce off walls
    // public bool isPiercing = false; // Ray's pierce through enemies
    // public bool isExplosive = false; // Ray's explode on impact

    // private ParticleSystem ps;

    public Transform rayStick;
    
    // Start is called before the first frame update
    void Start()
    {
        // ps = GetComponent<ParticleSystem>();
        // var shape = ps.shape;
        // shape.scale = new Vector3(range, 1, 1);
        // shape.position = new Vector3(0, range, 0);
        
        // var main = ps.main;
        // main.startColor = color;
        
        rayStick.localScale = new Vector3(0.05f, range, 0.05f);
        rayStick.localPosition = new Vector3(0, range + 1f, 0);
        
        // Set the color of the RayStick (Cylinder representing laser) TODO: FIX
        Material rayMat = rayStick.GetComponent<MeshRenderer>().material;
        Texture2D colorTex = new Texture2D(1, 1);
        colorTex.SetPixel(0, 0, color);
        rayMat.mainTexture = colorTex;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = Mathf.Max(cooldown - Time.deltaTime, 0);
        coolOn = Mathf.Max(coolOn - Time.deltaTime, 0);
        if (Input.GetMouseButton(0) && cooldown <= 0 && coolOn <= 0 && !isOn)
        {
            isOn = true;
            coolOn = coolOnSeconds;
            // ps.Play();
            rayStick.gameObject.SetActive(true);
        }

        if (coolOn <= 0 && cooldown <= 0 && isOn )
        {
            isOn = false;
            // ps.Stop();
            rayStick.gameObject.SetActive(false);
            cooldown = cooldownSeconds;
        }
    }

    // private void OnParticleCollision(GameObject other)
    // {
    //     if (other.CompareTag("Enemy"))
    //     {
    //         other.GetComponent<Enemy>().health -= damage;
    //     }
    // }
}
