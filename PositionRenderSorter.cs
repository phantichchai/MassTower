using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRenderSorter : MonoBehaviour
{
    private int sortingOrderBase;
    private int offset;
    private float timer;
    private float timerMax = .1f;
    private Renderer myrenderer;

    private void Start()
    {
        myrenderer = GetComponent<Renderer>();
        sortingOrderBase = myrenderer.sortingOrder;
        offset = (int) myrenderer.bounds.size.y;
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = timerMax;
            myrenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
        }
    }
}
