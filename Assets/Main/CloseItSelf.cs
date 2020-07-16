using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseItSelf : MonoBehaviour
{

    public void Click()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
