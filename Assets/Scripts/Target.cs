using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private TargetSize size;
    public enum TargetSize
    {
        Small,
        Middle,
        Large,
    }

    void Start()
    {
        SetUp()
    }
    void SetUp()
    {
        switch (size)
        {
            case TargetSize.Small:
                gameObject.transform.localScale = Vector3.one * 0.05f;
                break;
            case TargetSize.Middle:
                gameObject.transform.localScale = Vector3.one * 1f;
            case TargetSize.Large:
                gameObject.transform.localScale = Vector3.one * 2f;
                break;
            default:
                size = TargetSize.Small;
                break;
        }
    }
}
