using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeHandler : MonoBehaviour
{
    public float currentSize;
    public float maxSize;

    /// <summary>
    /// When called, this function multiplies player size by parameter
    /// </summary>
    /// <param name="rate">value to multiply scale</param>
    public void IncreaseSize(float rate)
    {
        currentSize = transform.localScale.magnitude;
        Debug.Log(currentSize);
        if(transform.localScale.magnitude < maxSize)
        {
            // Multiply current scale by parameter
            transform.localScale *= rate;
        }

    }

    /// <summary>
    /// When called, this function resets the player size to original scale
    /// </summary>
    public void ResetSize()
    {
        transform.localScale = Vector3.one;
    }

}
