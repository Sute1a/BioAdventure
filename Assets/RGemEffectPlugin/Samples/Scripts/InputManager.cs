using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif // UNITY_EDITOR
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    public Text shiftKeyText = null;
    public Image cursorImage = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif // UNITY_EDITOR

        }

        // マウス位置
        Vector3 mousePosition = Input.mousePosition;
        if(cursorImage != null)
        {
            var p = cursorImage.GetComponent<RectTransform>();
            p.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }

        if (shiftKeyText)
        {
            bool isShiftKey = Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift);

            bool isLBtn = Input.GetMouseButton(0);
            bool isRBtn = Input.GetMouseButton(1);

            bool isShowText = isShiftKey || isLBtn || isRBtn;
            shiftKeyText.enabled = isShowText;

            if (isShowText)
            {
                var text = string.Empty;
                if(isShiftKey)
                {
                    text = "Shift";
                }

                if(isLBtn)
                {
                    if(text.Length != 0)
                    {
                        text += " + ";
                    }

                    text += "LBtn";
                }

                if (isRBtn)
                {
                    if (text.Length != 0)
                    {
                        text += " + ";
                    }

                    text += "RBtn";
                }

                shiftKeyText.text = text;
            }

        }
    }
}
