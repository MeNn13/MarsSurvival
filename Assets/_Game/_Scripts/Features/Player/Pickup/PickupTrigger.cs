using UnityEngine;
using Zenject;

namespace _Game._Scripts.Features.Player.Pickup
{
    public class PickupTrigger : MonoBehaviour
    {
        private IPickupHandler _pickupHandler;

        [Inject]
        public void Construct(IPickupHandler pickupHandler) => 
            _pickupHandler = pickupHandler;

        private void OnTriggerEnter2D(Collider2D other) => 
            _pickupHandler.Handle(other.gameObject);
    }
}
