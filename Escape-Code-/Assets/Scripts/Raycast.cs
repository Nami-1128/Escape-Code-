using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float range = 100f;
    public Camera cam;
    public GameObject logo1;
    public GameObject logo2;
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            rand = Random.Range(0, 2);
            Grafiti();
            Debug.Log(rand);
        }
        
        
    }

    void Grafiti()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Grafiti"))
            {
                if (rand == 0)
                {
                    GameObject go = Instantiate(logo1, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(go, 3f);
                }

                if (rand == 1)
                {
                    GameObject go = Instantiate(logo2, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(go, 3f);
                }
                
                
            }
        }
    }
}
