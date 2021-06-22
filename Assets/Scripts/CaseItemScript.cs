using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseItemScript : MonoBehaviour
{
    [SerializeField] private float lifetime = 2f;
    [SerializeField] private CaseItemSprites[] ss;
    private Image sr;

    private void OnEnable()
    {
        this.StartCoroutine("LifeRoutine");
    }

    private void OnDisable()
    {
        this.StopCoroutine("LifeRoutine");
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(this.lifetime);

        this.Deactivate();
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void RanSkin(int cid)
    {
        int procent;

        sr = this.GetComponent<Image>();
        procent = Random.Range(0, 1000);
        
        if (procent >= 0 && procent < 750)
            sr.sprite = ss[cid].blueS[Random.Range(0, ss[cid].blueS.Length)];
        else if (procent >= 750 && procent < 900)
            sr.sprite = ss[cid].purpleS[Random.Range(0, ss[cid].purpleS.Length)];
        else if (procent >= 900 && procent < 990)
            sr.sprite = ss[cid].pinkS[Random.Range(0, ss[cid].pinkS.Length)];
        else
            sr.sprite = ss[cid].redS[Random.Range(0, ss[cid].redS.Length)];

    }
}
