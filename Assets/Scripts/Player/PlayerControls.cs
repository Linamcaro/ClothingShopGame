using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private static PlayerControls _instance;

    public static PlayerControls Instance
    {
        get
        {
            return _instance;
        }
    }

    private InputActions inputActions;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }

        inputActions = new InputActions();
    }

    public void OnEnable()
    {
        inputActions.Enable();

    }

    public void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnDestroy()
    {
        inputActions.Dispose();

    }

    /// <summary>
    /// Get the mouse position
    /// </summary>
    /// <returns></returns>
    /// 
    public bool MouseClick()
    {

        return inputActions.Player.MouseClick.triggered;
    }


    public Vector2 MousePosition()
    {
        Vector2 mousePosition = inputActions.Player.MousePosition.ReadValue<Vector2>();

        return mousePosition;
    }

    public bool PlayerMenu()
    {
        return inputActions.Player.Menu.triggered;

    }


}
