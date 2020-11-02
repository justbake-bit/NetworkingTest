using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

namespace NetworkingTest {

	public class Player : NetworkBehaviour
	{
	    #region Public Variables
		public float movementSpeed = 5f;
	    #endregion
	
	    #region Private Variables
		
		private Vector2 _input;
		
	    #endregion
	
	    #region NetworkBehaviour Callbacks
		
		/// <summary>
		/// Update is called every frame, if the MonoBehaviour is enabled.
		/// </summary>
		protected void Update()
		{
			if(isLocalPlayer) {
				Vector3 movement = new Vector3(_input.x, _input.y);
				transform.position = transform.position + movement * Time.deltaTime * movementSpeed;
			}
		}
		
	    #endregion
	
	    #region Public Methods
		
		/// <summary>
		/// Function for getting input from player input, called from input system
		/// </summary>
		/// <param name="context">the context of the input event</param>
		public void GetInput(InputAction.CallbackContext context) {
			if(isLocalPlayer)
				_input = context.ReadValue<Vector2>().normalized;
		}
		
	    #endregion
	
	    #region Private Methods
	
	    #endregion
	}

}
