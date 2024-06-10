using System;
using UnityEngine;

public class CursorAppearanceController : MonoBehaviour
{
    public Texture2D cursor;

    public Texture2D hand;

    public Texture2D sword;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Normal();
    }

    private void UseSkill()
    {
        Vector2 hotspot = new Vector2(5f, 5f);
        ChangeCursor(sword, hotspot);
    }

    private void Normal()
    {
        Vector2 hotspot = new Vector2(12f, 11f);
        ChangeCursor(cursor, hotspot);
    }

    private void ChangeCursor(Texture2D cursorType, Vector2 hotspot)
    {
        Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }
}
