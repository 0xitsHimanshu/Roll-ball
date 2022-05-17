using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [Header("Output")]
        private StarterAssetsInputs starterAssetsInputs; 
        void Start()
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            
            starterAssetsInputs = Player.GetComponent<StarterAssetsInputs>();
        }        
        public void VirtualMoveInput(Vector2 virtualMoveDirection)

        {
            starterAssetsInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            starterAssetsInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            starterAssetsInputs.SprintInput(virtualSprintState);
        }
        
    }

}
