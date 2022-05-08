using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UpdateMonoBehaviour
{
    public static PlayerController Instance;
    public CharacterController CharacterController;
    public Transform Model;
    public PlayerMovement PlayerMovement;
    public PlayerSensor PlayerSensor;

    protected override void Awake()
    {
        base.Awake();
        if (Instance == null) Instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        CharacterController = GetComponent<CharacterController>();
        LoadScript();
    }

    protected virtual void LoadScript()
    {
        Model = transform.Find("Model");
        PlayerSensor = transform.Find("PlayerSensor").GetComponent<PlayerSensor>();
        PlayerMovement = transform.Find("PlayerMovement").GetComponent<PlayerMovement>();
    }
}
