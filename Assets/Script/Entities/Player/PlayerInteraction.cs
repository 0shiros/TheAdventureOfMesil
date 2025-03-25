using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [Header("References")]
    private PlayerAttack _playerAttack;
    private Transform _playerTransform;
    [SerializeField] private LayerMask _interactionLayer;

    [Header("UI")]
    [SerializeField] private GameObject _interactableText;
    [SerializeField] private TextMeshProUGUI _interactionText;

    private void Awake()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        _playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        DirectionLook();
    }

    private void DirectionLook()
    {
        RaycastHit2D hit = Physics2D.Raycast(_playerTransform.position, _playerAttack.attackDirection, 1f, _interactionLayer);

        Debug.DrawRay(_playerTransform.position, _playerAttack.attackDirection, Color.red);

        if (hit.collider)
        {
            Interactions interactions = hit.collider.GetComponent<Interactions>();

            if (Input.GetKeyDown(KeyCode.Q))
            {
               Interact(interactions._interactionMessage);
            }
        }
        else
        {
            _interactableText.SetActive(false);
        }
    }

    public void Interact(string message)
    {
        if (!_interactableText.activeSelf)
        {
            _interactableText.SetActive(true);
            _interactionText.text = message;
        }
        else
        {
            _interactableText.SetActive(false);
        }
    }

    
}
