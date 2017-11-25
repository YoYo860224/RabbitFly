using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRayCasting : MonoBehaviour {

    //fields
    public bool collisionUp;
    public bool collisionDown;
    public bool collisionLeft;
    public bool collisionRight;

    //show rays debug
    public bool showRays = false;

    //ray cast fields
    public float rayDistance;

    //the tile that hit the object
    RaycastHit2D TopHit;


    //box rays
    Ray BLRay;
    Ray BRRay;
    Ray TLRay;
    Ray TRRay;
    Ray LTRay;
    Ray LBRay;
    Ray RTRay;
    Ray RBRay;

    //floor
    public GameObject bottomLeft;
    public GameObject bottomRight;

    //wall Left
    public GameObject leftTop;
    public GameObject leftBottom;

    //wall right
    public GameObject rightTop;
    public GameObject rightBottom;

    //ceiling
    public GameObject topLeft;
    public GameObject topRight;

    // Update is called once per frame
    void Update()
    { 
        checkCollision();

        //debug
        if (showRays)
            drawRaycast();
    }

    //debug functions
    void drawRaycast()
    {
        //draw left floor
        Debug.DrawLine(bottomLeft.gameObject.transform.position, new Vector3(bottomLeft.gameObject.transform.position.x, bottomLeft.gameObject.transform.position.y - rayDistance, bottomLeft.gameObject.transform.position.z), Color.red);

        //draw right floor
        Debug.DrawLine(bottomRight.gameObject.transform.position, new Vector3(bottomRight.gameObject.transform.position.x, bottomRight.gameObject.transform.position.y - rayDistance, bottomLeft.gameObject.transform.position.z), Color.red);

        //draw left ceiling
        Debug.DrawLine(topLeft.gameObject.transform.position, new Vector3(topLeft.gameObject.transform.position.x, topLeft.gameObject.transform.position.y + rayDistance, bottomLeft.gameObject.transform.position.z), Color.red);

        //draw right ceiling
        Debug.DrawLine(topRight.gameObject.transform.position, new Vector3(topRight.gameObject.transform.position.x, topRight.gameObject.transform.position.y + rayDistance, bottomLeft.gameObject.transform.position.z), Color.red);

        //draw left wall top
        Debug.DrawLine(leftTop.gameObject.transform.position, new Vector3(leftTop.gameObject.transform.position.x - rayDistance, leftTop.gameObject.transform.position.y, leftTop.gameObject.transform.position.z), Color.red);

        //draw left wall bottom
        Debug.DrawLine(leftBottom.gameObject.transform.position, new Vector3(leftBottom.gameObject.transform.position.x - rayDistance, leftBottom.gameObject.transform.position.y, leftBottom.gameObject.transform.position.z), Color.red);

        //draw right wall top
        Debug.DrawLine(rightTop.gameObject.transform.position, new Vector3(rightTop.gameObject.transform.position.x + rayDistance, rightTop.gameObject.transform.position.y, rightTop.gameObject.transform.position.z), Color.red);

        //draw right wall bottom
        Debug.DrawLine(rightBottom.gameObject.transform.position, new Vector3(rightBottom.gameObject.transform.position.x + rayDistance, rightBottom.gameObject.transform.position.y, rightBottom.gameObject.transform.position.z), Color.red);
    }

    void checkCollision()
    {
        //Collision Detection (with Raycast)
        BLRay = new Ray(new Vector3(bottomLeft.gameObject.transform.position.x, bottomLeft.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.down);
        BRRay = new Ray(new Vector3(bottomRight.gameObject.transform.position.x, bottomRight.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.down);

        TLRay = new Ray(new Vector3(topLeft.gameObject.transform.position.x, topLeft.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.up);
        TRRay = new Ray(new Vector3(topRight.gameObject.transform.position.x, topRight.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.up);

        LTRay = new Ray(new Vector3(leftTop.gameObject.transform.position.x, leftTop.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.left);
        LBRay = new Ray(new Vector3(leftBottom.gameObject.transform.position.x, leftBottom.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.left);

        RTRay = new Ray(new Vector3(rightTop.gameObject.transform.position.x, rightTop.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.right);
        RBRay = new Ray(new Vector3(rightBottom.gameObject.transform.position.x, rightBottom.gameObject.transform.position.y, this.gameObject.transform.position.z), Vector3.right);

        // down
        RaycastHit2D hit_bl = Physics2D.Raycast(BLRay.origin, BLRay.direction, rayDistance);
        RaycastHit2D hit_br = Physics2D.Raycast(BRRay.origin, BRRay.direction, rayDistance);
        if (hit_bl.collider || hit_br.collider)
        {
            collisionDown = true;
        }

        // top
        RaycastHit2D hit_tl = Physics2D.Raycast(TLRay.origin, TLRay.direction, rayDistance);
        RaycastHit2D hit_tr = Physics2D.Raycast(TRRay.origin, TRRay.direction, rayDistance);
        if (hit_tl.collider || hit_tr.collider)
        {
            collisionUp = true;
        }

        // left
        RaycastHit2D hit_lt = Physics2D.Raycast(LTRay.origin, LTRay.direction, rayDistance);
        RaycastHit2D hit_lb = Physics2D.Raycast(LBRay.origin, LBRay.direction, rayDistance);
        if (hit_lt.collider || hit_lb.collider)
        {
            collisionLeft = true;
        }

        // right
        RaycastHit2D hit_rt = Physics2D.Raycast(RTRay.origin, RTRay.direction, rayDistance);
        RaycastHit2D hit_rb = Physics2D.Raycast(RBRay.origin, RBRay.direction, rayDistance);
        if (hit_rt.collider || hit_rb.collider)
        {
            collisionRight = true;
        }
    }
}
