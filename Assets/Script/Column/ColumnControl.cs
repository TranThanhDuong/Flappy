using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnControl : MonoBehaviour
{
    public Transform ColumnTop;
    public Transform ColumnBottom;
    public BoxCollider2D addPointPlace;
    private int distances = 11;
    private ColumnManager columnManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Setup(ColumnManager columnManager)
    {
        this.columnManager = columnManager;
    }

    private void Awake()
    {
        ColumnTop.position = new Vector3(0,distances * 0.5f,-1);
        ColumnBottom.position = new Vector3(0, -distances * 0.5f, -1);
        addPointPlace.size = new Vector2(0.5f, distances * 0.5f);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameManager.instances.B_GamePause)
            return;

        transform.position += new Vector3(-0.05f, 0, 0);
        if (transform.position.x < -7)
        {
            Vector3 columnLast = columnManager.columnLast.position;
            transform.position = new Vector3(columnLast.x + 5, columnManager.rangeY_Function(),0);
            columnManager.columnLast = transform;
        }
    }
}
