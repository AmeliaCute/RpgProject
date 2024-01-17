using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnduranceTaskSystem : MonoBehaviour
{
    [SerializeField] private EnduranceTaskEntity entity;
    [SerializeField] private EnduranceTaskPlayer player;
    private PlayerInput input;
    private Player playerInstance;
    private GameObject playerGameObject;

    void OnEnable()
    {
        GameObject.FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Abort").performed += AbortEvent;
        GameObject.FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Use").performed += Damage;
    }

    void OnDisable()
    {
        GameObject.FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Abort").performed -= AbortEvent;
        GameObject.FindObjectOfType<PlayerInput>().actions.FindActionMap("EnduranceTask").FindAction("Use").performed -= Damage;
    }

    private void Damage(InputAction.CallbackContext context) { entity.Damage(playerInstance.attack.TotalValue); }
    private void AbortEvent(InputAction.CallbackContext context) { Finish(); }

    public void Setup(Player player, GameObject target, ItemInstance itemInstance)
    {
        playerInstance = player;
        playerGameObject = player.gameObject;

        input = GameObject.FindObjectOfType<PlayerInput>();
        input.actions.FindActionMap("Player").Disable();
        input.actions.FindActionMap("EnduranceTask").Enable();
        this.entity = target.AddComponent<EnduranceTaskEntity>();
        this.entity.enduranceTaskSystem = this;
        this.entity.itemInstance = itemInstance;
        this.player = playerGameObject.AddComponent<EnduranceTaskPlayer>();
        this.player.taskPos = target.transform.position;
    }

    public void Finish()
    {
        input.actions.FindActionMap("EnduranceTask").Disable();
        input.actions.FindActionMap("Player").Enable();
        Destroy(player);
    }
}