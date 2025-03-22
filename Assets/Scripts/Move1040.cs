using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1040 : MonoBehaviour
{
    //     private bool inForm = ;
    public GameObject form;
    private Vector3 defaultScale;
    private Vector3 defaultPos;
    private bool inPan, oneTime, centered;

    void Start()
    {
        inPan = false;
        oneTime = true;
        // centered = false;
        form = GameObject.Find("/1040");
        defaultScale = form.transform.localScale;
        defaultScale = form.transform.position;
        if (form == null)
        {
            Debug.Log("FUCK");
        }
    }

    void FixedUpdate()
    {

    }

    void OnMouseEnter()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Vector3 pan = form.transform.localScale + new Vector3(1f, 1f, 1f);

        if (!inPan && oneTime)
        {
            if (form.transform.position != Vector3.zero)
                StartCoroutine(LerpFocus(form, form.transform.position, pan, 0.05f));
        }

    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Vector3 pan = form.transform.localScale - new Vector3(1f, 1f, 1f);
        if (inPan && !oneTime)
        {
            if (form.transform.position != Vector3.zero)
                StartCoroutine(LerpFocus(form, form.transform.position, pan, 0.05f));
        }

    }

    void OnMouseDown()
    {
        if (form.transform.position != Vector3.zero)
        {

            centered = true;
            Vector3 pan = new Vector3(6f, 10f, 1f);
            StartCoroutine(LerpFocus(form, Vector3.zero, pan, 0.1f));
        }
        if (form.transform.position == Vector3.zero)
        {
            centered = false;
            Vector3 pan = defaultScale;
            StartCoroutine(LerpFocus(form, defaultPos, pan, 0.1f));
        }
    }




    IEnumerator LerpFocus(GameObject item, Vector3 pos, Vector3 scale, float duration)
    {

        float time = 0;
        Vector3 startPosition = item.transform.position;
        Vector3 startScale = item.transform.localScale;

        while (time < duration)
        {
            item.transform.position = Vector3.Lerp(startPosition, pos, time / duration);
            item.transform.localScale = Vector3.Lerp(startScale, scale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        item.transform.position = pos;
        item.transform.localScale = scale;

        inPan = !inPan;
        oneTime = !oneTime;

    }



}
