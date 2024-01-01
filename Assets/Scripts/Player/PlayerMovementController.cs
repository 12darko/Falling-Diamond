using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;

        #region Prop
        public Rigidbody Rb
        {
            get => rb;
            set => rb = value;
        }
        #endregion
       
        #region Class
        [SerializeField] private PlayerKeyController playerKeyController;
        [SerializeField] private PlayerInvincibleController playerInvincibleController;
        #endregion
      
        public void PlayerMovement()
        {
            var keyController = playerKeyController;
            var invincibleController = playerInvincibleController;
            if (!keyController.Clicked)
            {
                invincibleController.Impact = false;
                rb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 0.5f, 0);
            }
            else
            {
                invincibleController.Impact = true;
                rb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 6f, 0);
            }
        }
    }
}