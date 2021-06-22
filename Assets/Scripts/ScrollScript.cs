using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public RouletScript rs;
    private float rX;

    private void Start()
    {
        rX = this.transform.position.x;
    }
    void Update()
    {
        if(rs.isOpenCase)
            gameObject.transform.Translate(new Vector2(rs.scrollSpeed, 0) * Time.deltaTime);
        else
        {
            gameObject.transform.SetPositionAndRotation(new Vector2(rX, 0), Quaternion.identity);
        }
    }
}
