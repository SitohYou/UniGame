using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class seed : MonoBehaviour
{
    private Rigidbody2D _rb;

    public bool isMergeFlag = false;
    public bool isDrop = false;
    public int seedNo;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!line.instance.isFinished)
        {
            if (Input.GetMouseButton(0) && isDrop == false)
            {
                Drop();
            }
            if (isDrop) return;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float halfWidth = this.transform.localScale.x * 0.5f;

            mousePos.x = Mathf.Clamp(mousePos.x, -3.45f + halfWidth, 3.45f - halfWidth);
            mousePos.y = 3.5f;

            transform.position = mousePos;
        }
    }

    private void Drop()
    {
        isDrop = true;
        _rb.simulated = true;
        GameManager.Instance.isNext = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colobj = collision.gameObject;

        if (colobj.CompareTag("seed"))
        {
            seed colseed = collision.gameObject.GetComponent<seed>();
            if (seedNo == colseed.seedNo &&
                !isMergeFlag &&
                !colseed.isMergeFlag &&
                seedNo < GameManager.Instance.MaxSeedNo - 1)
            {
                isMergeFlag = true;
                colseed.isMergeFlag = true;
                GameManager.Instance.MergeNext(transform.position, seedNo);
                Destroy(gameObject);
                Destroy(colseed.gameObject);
            }
        }
    }
}
