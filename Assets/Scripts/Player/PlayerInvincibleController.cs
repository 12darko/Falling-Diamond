using UnityEngine;

namespace Player
{
    public class PlayerInvincibleController : MonoBehaviour
    {
        [SerializeField] private GameObject invincibleEffect;
        [SerializeField] private float currentTime;
        [SerializeField] private bool invincible;
        [SerializeField] private bool impact;

        public GameObject InvincibleEffect
        {
            get => invincibleEffect;
            set => invincibleEffect = value;
        }

        public float CurrentTime
        {
            get => currentTime;
            set => currentTime = value;
        }

        public bool Invincible
        {
            get => invincible;
            set => invincible = value;
        }

        public bool Impact
        {
            get => impact;
            set => impact = value;
        }

        public void PlayerInvincible()
        {
            if (invincible)
            {
                currentTime -= Time.deltaTime * .35f;
                if (!invincibleEffect.activeInHierarchy)
                {
                    invincibleEffect.SetActive(true);
                }
            }
            else
            {
                if (invincibleEffect.activeInHierarchy)
                {
                    invincibleEffect.SetActive(false);
                }

                if (impact)
                {
                    currentTime += Time.deltaTime * 0.8f;
                }
                else
                {
                    currentTime -= Time.deltaTime * 0.5f;
                }
            }
            
            TimeController();
        }

        private void TimeController()
        {
            if (currentTime >= 1.5f)
            {
                currentTime = 1.5f;
                invincible = true;
            }
            else if (currentTime <= 0)
            {
                currentTime = 0;
                invincible = false;
            }
        }
    }
}