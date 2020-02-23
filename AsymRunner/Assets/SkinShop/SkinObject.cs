using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Player Data", order = 51)]
public class SkinObject : ScriptableObject
{
    [SerializeField]
    private string skinName;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int cost;
    [SerializeField]
    private bool isAvailable;
    [SerializeField]
    private int jumpForce;


    public string SkinName => skinName;

    public Sprite Icon => icon;

    public int Cost => cost;

    public int JumpForce => jumpForce;

    public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
}
