using System.Collections;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hookrb;
    private bool isPressed = false;
    private float releaseTime = 0.15f;
    private float maxDragDistance = 2.5f;
    public GameObject next;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mpos, hookrb.position) <= maxDragDistance)
            {
                rb.position = mpos;
            }
            else
            {
                rb.position = (mpos - hookrb.position).normalized * maxDragDistance + hookrb.position;
            }
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(release());
    }

    IEnumerator release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;

        if (next != null)
        {
            yield return new WaitForSeconds(5f);
            next.SetActive(true);
        }
    }
}
