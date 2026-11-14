using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideImage : MonoBehaviour
{
    public GameObject targetObject;
    // Start is called before the first frame update
    private void Start()
    {

    }
    public void ConcealImage()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
