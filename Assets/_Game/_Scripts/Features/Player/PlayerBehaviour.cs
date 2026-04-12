using _Game._Scripts.Core.Input;
using _Game._Scripts.Core.UI;
using _Game._Scripts.Features.Overload;
using _Game._Scripts.Features.Oxygen;
using _Game._Scripts.Features.Player.Movement;
using UnityEngine;
using Zenject;

namespace _Game._Scripts.Features.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 3f;
        
        [Header("Oxygen")]
        [SerializeField] private int oxygenStore = 50;  
        [SerializeField] private int oxygenSupply = 5;  
        [SerializeField] private int oxygenSpend = 5;  
        
        //TODO: debug
        [Header("Overload")]
        [SerializeField] private float overloadIncrease = 1;  
        [SerializeField] private float overloadReduce = 1; 

        [Header("Unity Settings")] 
        [SerializeField] private Transform groundCheck;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private InputProvider input;
        [SerializeField] private HUD hud;

        private IMovement _movement;
        private IOxygen _oxygen;
        //TODO: debug
        private IOverload  _overload; 
        [SerializeField] private bool _selfZone; //TODO: debug

        [Inject]
        public void Construct(
            IMovement movement,
            IOxygen oxygen,
            IOverload overload)
        {
            _movement = movement;
            _oxygen = oxygen;
            _overload = overload;
        }

        private void Start()
        {
            _movement.Initialize(groundCheck, spriteRenderer, rb);
            _oxygen.Initialize(oxygenStore, oxygenStore);
            hud.UpdateOxygen(_oxygen.MaxStore, _oxygen.Store);
        }

        private void Update()
        {
            SelfZoneHandle();
            OverloadHandle();

            MovementHandle();
        }

        private void MovementHandle()
        {
            if (input.GetMove.magnitude >= .1f)
                _movement.Move(speed, input.GetMove.x);

            if (input.Jump)
                _movement.Jump(jumpForce);
        }
        

        private void SelfZoneHandle()
        {
            if (_selfZone)
            {
                _oxygen.Supply(oxygenSupply);
                hud.UpdateOxygen(_oxygen.MaxStore, _oxygen.Store);
                return;
            }
            
            _oxygen.Spend(oxygenSpend);
            hud.UpdateOxygen(_oxygen.MaxStore, _oxygen.Store);
        }

        private void OverloadHandle()
        {
            if (input.LeftClick)
            {
                _overload.Increase(overloadIncrease);
                hud.UpdateOverload(_overload.MaxValue, _overload.Value);
                return;
            }
            
            _overload.Reduce(overloadReduce);
            hud.UpdateOverload(_overload.MaxValue, _overload.Value);
        }
    }
}
