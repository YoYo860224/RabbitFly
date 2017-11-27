using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryFireBall : MonoBehaviour {

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
