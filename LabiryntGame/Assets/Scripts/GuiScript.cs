using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiScript : MonoBehaviour
{
    public GameObject CreateButton(string name, Transform parent, Vector2 _sizeDelta, Vector2 _anchorMin, Vector2 _anchorMax,
        Vector3 _localScale, Vector2 _pivot, Vector2 _anchoredPosition, Sprite _sprite, Image.Type type)
    {
        GameObject button = new GameObject(name);
        button.transform.SetParent(parent);

        button.AddComponent<RectTransform>();
        button.AddComponent<Image>();
        button.AddComponent<Button>();

        //Set RectTransform
        button.GetComponent<RectTransform>().sizeDelta = _sizeDelta;
        button.GetComponent<RectTransform>().anchorMin = _anchorMin;
        button.GetComponent<RectTransform>().anchorMax = _anchorMax;
        button.GetComponent<RectTransform>().localScale = _localScale;
        button.GetComponent<RectTransform>().pivot = _pivot;
        button.GetComponent<RectTransform>().anchoredPosition = _anchoredPosition;

        //Set Image
        button.GetComponent<Image>().sprite = _sprite;
        button.GetComponent<Image>().type = type;
        return button;
    }

    public GameObject CreateImage(string name, Transform parent, Vector2 _sizeDelta, Vector2 _anchorMin, Vector2 _anchorMax,
       Vector3 _localScale, Vector2 _pivot, Vector2 _anchoredPosition, Vector3 _localPosition, Sprite _sprite, Image.Type type, Color32 _color)
    {
        GameObject image = new GameObject(name);
        image.transform.SetParent(parent);

        image.AddComponent<RectTransform>();
        image.AddComponent<Image>();

        //Set RectTransform
        image.GetComponent<RectTransform>().localPosition = _localPosition;
        image.GetComponent<RectTransform>().sizeDelta = _sizeDelta;
        image.GetComponent<RectTransform>().anchorMin = _anchorMin;
        image.GetComponent<RectTransform>().anchorMax = _anchorMax;
        image.GetComponent<RectTransform>().localScale = _localScale;
        image.GetComponent<RectTransform>().pivot = _pivot;
        image.GetComponent<RectTransform>().anchoredPosition = _anchoredPosition;

        //Set Image
        image.GetComponent<Image>().color = _color;
        image.GetComponent<Image>().sprite = _sprite;
        image.GetComponent<Image>().type = type;
        return image;
    }

    public GameObject CreateText(string name, Transform parent, Vector2 _sizeDelta, Vector2 _anchorMin, Vector2 _anchorMax,
        Vector3 _localScale, Vector2 _pivot, Vector2 _anchoredPosition, string _text, Color32 _color,
        bool _resizeTextForBestFit, Font _font, TextAnchor _textAnchor, FontStyle _fontStyle, int _fontSize)
    {
        GameObject textObject = new GameObject(name);
        textObject.transform.SetParent(parent);
        textObject.AddComponent<RectTransform>();
        textObject.AddComponent<Text>();

        //Set RectTransform
        textObject.GetComponent<RectTransform>().sizeDelta = _sizeDelta;
        textObject.GetComponent<RectTransform>().anchorMin = _anchorMin;
        textObject.GetComponent<RectTransform>().anchorMax = _anchorMax;
        textObject.GetComponent<RectTransform>().localScale = _localScale;
        textObject.GetComponent<RectTransform>().pivot = _pivot;
        textObject.GetComponent<RectTransform>().anchoredPosition = _anchoredPosition;

        //Set Text
        textObject.GetComponent<Text>().fontSize = _fontSize;
        textObject.GetComponent<Text>().resizeTextForBestFit = _resizeTextForBestFit;
        textObject.GetComponent<Text>().font = _font;
        textObject.GetComponent<Text>().alignment = _textAnchor;
        textObject.GetComponent<Text>().fontStyle = _fontStyle;
        textObject.GetComponent<Text>().color = _color;
        textObject.GetComponent<Text>().text = _text;

        return textObject;
    }

    public GameObject[,] FillWithImages(Transform panel, int columnCount, int rowsCount, Sprite image, Color32 color, string name)
    {
        GameObject[,] images = new GameObject[columnCount, rowsCount];
        float imageW = Mathf.Abs(panel.GetComponent<RectTransform>().sizeDelta.x) / (float)columnCount;
        float imageH = Mathf.Abs(panel.GetComponent<RectTransform>().sizeDelta.y) / (float)rowsCount;
        float offsetX = imageW / 2.0f;
        float offsetY = -imageH / 2.0f;
        for (int j = 0; j < rowsCount; j++)
        {
            for (int i = 0; i < columnCount; i++)
            {
                GameObject img = CreateImage((name + (j * rowsCount + i).ToString()), panel, new Vector2(imageW, imageH),
                    new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f),
                   new Vector2(offsetX + (i * imageW), offsetY + (j * -imageH)), new Vector3(0, 0, 0), image, Image.Type.Sliced, color);
                images[i, j] = img;
            }
        }
        return images;
    }

    public GameObject[] FillWithButtons(Transform panel, int buttonCount, int columnCount, Sprite image, string name)
    {
        GameObject[] buttons = new GameObject[buttonCount];
        int rowsCount = (int)Mathf.Ceil((float)buttonCount / (float)columnCount);
        float buttonW = Mathf.Abs(panel.GetComponent<RectTransform>().sizeDelta.x) / (float)columnCount;
        float buttonH = Mathf.Abs(panel.GetComponent<RectTransform>().sizeDelta.y) / (float)rowsCount;
        float offsetX = buttonW / 2.0f;
        float offsetY = -buttonH / 2.0f;
        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                if ((i * columnCount + j) < buttonCount)
                {
                    GameObject but = CreateButton((name + (i * columnCount + j).ToString()), panel, new Vector2(buttonW, buttonH),
                        new Vector2(0, 1), new Vector2(0, 1), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f),
                       new Vector2(offsetX + (j * buttonW), offsetY + (i * -buttonH)), image, Image.Type.Sliced);
                    GameObject text = CreateText("LvlNumber", but.transform, new Vector2(buttonW / 2.0f, buttonH / 2.0f), new Vector2(0.5f, 0.5f),
                        new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(0.0f, 0.0f),
                        (i * columnCount + j + 1).ToString(), new Color32(0, 0, 0, 255), false,
                        Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font, TextAnchor.MiddleCenter, FontStyle.Normal, 50);
                    buttons[i * columnCount + j] = but;
                }
            }
        }
        return buttons;
    }
}
