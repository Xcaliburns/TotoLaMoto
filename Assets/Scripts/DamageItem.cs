using UnityEngine;

public class DamageItem : MonoBehaviour


{
	public int amount = -1;

	// Start is called before the first frame update


	void OnTriggerStay2D(Collider2D other)
	{
		PlayerController controller = other.GetComponent<PlayerController>();

		if (controller != null && controller.Health > 0)
		{
			Debug.Log(other.name + amount + controller.Health );
			controller.ChangeHealth(-1);


		}
	}
}
