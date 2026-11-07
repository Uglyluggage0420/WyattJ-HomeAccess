using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImage : MonoBehaviour
{
    public GameObject targetObject;
    // Start is called before the first frame update
    private void Start()
    {
        targetObject.SetActive(false);
    }
    public void RevealImage()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}
