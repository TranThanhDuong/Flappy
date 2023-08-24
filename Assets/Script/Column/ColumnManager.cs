using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnManager : MonoBehaviour
{
    public Transform columnPrefab;
    private float range_Top = 5;
    private float range_Bottom = 3;
    public Transform columnLast;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            Transform createColumn = column2();
            
            createColumn.position = new Vector3(i * 5, rangeY_Function(), -1);
            createColumn.SetParent(transform);
            ColumnControl columnControl = createColumn.GetComponent<ColumnControl>();
            columnControl.Setup(this);
            if(i == 4)
            {
                columnLast = createColumn;
                
            }
        }
        
    }
    public float rangeY_Function()
    {
        return Random.Range(range_Bottom, range_Top);
        
    }
    private Transform column1()
    {
        //1.  keo tha? component
        Transform column = Instantiate(columnPrefab);
       //column.SetParent(transform);
        return column;
    }
    private Transform column2()
    {
        //2. goi tu` resources
        GameObject goColumnPrefab = Instantiate(Resources.Load("Prefab/ColumnControl", typeof(GameObject))) as GameObject;
        goColumnPrefab.transform.SetParent(transform);
        return goColumnPrefab.transform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
}
