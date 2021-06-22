using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RouletScript : MonoBehaviour
{
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private CaseItemScript SkinPrefab;
    [SerializeField] private Transform grid;

    private PoolMono<CaseItemScript> pool;

    public bool isOpenCase = false;
    public float scrollSpeed = -20f;
    private float velocity;

    private void Start()
    {
        this.pool = new PoolMono<CaseItemScript>(this.SkinPrefab, this.poolCount, grid)
        {
            autoExpand = this.autoExpand
        };
    }

    private void Update()
    {
        if (isOpenCase)
        {
            scrollSpeed = Mathf.MoveTowards(scrollSpeed, 0f, velocity * Time.deltaTime);
            if (scrollSpeed == 0)
            {
                RouletReset();
            }
        }
    }

    public void SkinBtn(int caseid)
    {
        isOpenCase = true;
        this.CreateSkin(caseid);
        velocity = UnityEngine.Random.Range(3f, 3.5f);

    }

    private void CreateSkin(int cid)
    {
        var rPosition = new Vector2(0, 0);
        var skins = this.pool.GetAllFreeElement();
        foreach(var item in skins)
        {
            item.RanSkin(cid);
            item.transform.position = rPosition;
        }
    }

    private void RouletReset()
    {
        isOpenCase = false;
        scrollSpeed = -20f;
    }
}
