using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private int point;
    [SerializeField]
    public int Point => point;

    private bool b_GamePause = true;

    private PlayerControl playerControl;

    private GameObject columnManager;

    public bool B_GamePause
    {
        get
        {
            return b_GamePause;
        }

        set
        {
            b_GamePause = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        AddColumnManager();
    }

    private void AddColumnManager()
    {
        columnManager = new GameObject();
        columnManager.gameObject.name = "ColumnManager";
        columnManager.AddComponent<ColumnManager>();
        columnManager.transform.SetParent(this.transform);
    }    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        point++;
    }

    public void RestartGame()
    {
        point = 0;
        playerControl.Restart();

        if (!b_GamePause)
            b_GamePause = true;

        Object.Destroy(columnManager.gameObject);
        AddColumnManager();
    }    
}
