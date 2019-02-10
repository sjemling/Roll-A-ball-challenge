using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    private Vector3 pos1;
    private Vector3 pos2;
    public Vector3 posDiff = new Vector3(-140f, -110f, -7f);
    public float speed = 1.0f;

    void Start()
    {
        pos1 = transform.position;
        pos2 = transform.position + posDiff;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        transform.Rotate(Vector3.up * 10f * Time.deltaTime);
    }

}