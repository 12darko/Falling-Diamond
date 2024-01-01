using Unity.VisualScripting;

namespace States
{
    public class PlayerStateFactory
    {
        private PlayerStateMachine _context;

        public PlayerStateFactory(PlayerStateMachine currentContext)
        {
            _context = currentContext;
        }

        public State Normal()
        {
            return new NormalState(_context, this);
        }

        public State Click()
        {
            return new MovementState(_context, this);
        }

        public State Break()
        {
            return new BreakState(_context, this);
        }
    }
}