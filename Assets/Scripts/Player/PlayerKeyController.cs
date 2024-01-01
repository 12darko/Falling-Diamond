using UnityEngine;

namespace Player
{
    public class PlayerKeyController : MonoBehaviour
    {
        private bool _clicked;

          public bool Clicked
          {
              get => _clicked;
              set => _clicked = value;
          }

          public void PlayerKeyDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
             
                _clicked = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _clicked = false;
               
            }
        }
    }
}