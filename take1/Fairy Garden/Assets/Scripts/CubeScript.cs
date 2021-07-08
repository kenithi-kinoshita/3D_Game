using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理
        Move();
    }
    [SerializeField]
    private float speed = 2f;

    private void Move()
    {
        transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
    }
    
}

