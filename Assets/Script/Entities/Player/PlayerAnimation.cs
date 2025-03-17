using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerAnimator.SetBool("IsAttacking", true);
        }
        else
        {
            _playerAnimator.SetBool("IsAttacking", false);
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
