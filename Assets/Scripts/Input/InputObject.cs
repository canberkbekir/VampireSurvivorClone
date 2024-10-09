using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    [CreateAssetMenu(menuName = "Input/InputObject")]
    public class InputObject : ScriptableObject,InputMap.IGameplayActions,InputMap.IUIActions
    {
        private InputMap _inputMap;

        private void OnEnable()
        {
            if (_inputMap != null) return;
            
            _inputMap = new InputMap();
            _inputMap.Gameplay.SetCallbacks(this);
            _inputMap.UI.SetCallbacks(this);
            
            SetGameplay();
        }

        #region GamePlay events
        public event Action<Vector2> OnMovementEvent;
        public event Action OnPauseEvent;
        
        #endregion
        
        #region UI events
        public event Action OnResumeEvent;  
        
        #endregion
    

        public void SetGameplay()
        {
            _inputMap.Gameplay.Enable();
            _inputMap.UI.Disable();
        }
        
        public void SetUI()
        {
            _inputMap.Gameplay.Disable();
            _inputMap.UI.Enable();
        }
        public void OnMovement(InputAction.CallbackContext context)
        {
            OnMovementEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            OnPauseEvent?.Invoke();
        }

        public void OnSelect(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnResume(InputAction.CallbackContext context)
        {
            OnResumeEvent?.Invoke();
        }
    }
}
