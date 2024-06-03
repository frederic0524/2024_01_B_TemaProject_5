using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType:MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Transform buttonScale;
    public BTNType currentType;
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                Debug.Log("������");
                break;

            case BTNType.Continue:
                Debug.Log("�̾��ϱ�");
                break;


        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}

