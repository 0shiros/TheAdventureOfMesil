using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("References")]
    private Animator _playerAnimator;
    private PlayerBar _playerBar;
    private PlayerCharacteristics _playerCharacteristics;
    private PlayerAttack _playerAttack;
    private PlayerDefense _playerDefense;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerBar = GetComponent<PlayerBar>();
        _playerCharacteristics = GetComponent<PlayerCharacteristics>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerDefense = GetComponent<PlayerDefense>();
    }

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_playerCharacteristics.currentStamina >= _playerAttack.attackStaminaCost)
            {
                _playerCharacteristics.currentStamina -= _playerAttack.attackStaminaCost;
                _playerBar.isRegen = false;
                _playerBar.UpdateStaminaBar();
                _playerBar._staminaDelay = Time.time;
                _playerAnimator.SetBool("IsAttacking", true);
            }
        }
        else
        {
            _playerAnimator.SetBool("IsAttacking", false);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            if(_playerCharacteristics.currentStamina >= _playerDefense.defenseStaminaCost)
            {
                _playerCharacteristics.currentStamina -= _playerDefense.defenseStaminaCost;
                _playerBar.isRegen = false;
                _playerBar.UpdateStaminaBar();
                _playerBar._staminaDelay = Time.time;
                _playerAnimator.SetBool("IsDefending", true);
            }
        }
        else
        {
            _playerAnimator.SetBool("IsDefending", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playerAnimator.SetBool("IsFacingRight", true);
        }
        else
        {
            _playerAnimator.SetBool("IsFacingRight", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _playerAnimator.SetBool("IsFacingLeft", true);
        }
        else
        {
            _playerAnimator.SetBool("IsFacingLeft", false);
        }

        if(Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            _playerAnimator.SetBool("IsFacingDown", true);
        }
        else
        {
            _playerAnimator.SetBool("IsFacingDown", false);
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            _playerAnimator.SetBool("IsFacingUp", true);
        }
        else
        {
            _playerAnimator.SetBool("IsFacingUp", false);
        }
    }
}
