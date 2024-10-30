using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] bool isDestroyOnClose = false;
    // call before canvas active

    private void Awake()
    {
        // xu ly tai tho
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        if(ratio > 2.1f)
        {
            Vector2 leftBottom = rect.offsetMin;
            Vector2 rightTopp = rect.offsetMax;

            leftBottom.y = 0f;
            rightTopp.y = -100f;

            rect.offsetMin = leftBottom;
            rect.offsetMax = rightTopp;
        }
    }

    public virtual void SetUp()
    {

    }

    // call after canvas active
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    // deactive canvas after time(s)
    public virtual void Close(float time)
    {
        Invoke(nameof(CloseDirectly), time);
    }
    // deactive canvas
    public virtual void CloseDirectly()
    {
        if (isDestroyOnClose)
        {
            Destroy(gameObject); 
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
