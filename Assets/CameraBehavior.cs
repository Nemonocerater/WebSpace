using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	private float yaw = 0.0f;
	private float prevPitch = 0.0f;
	private float pitch = 0.0f;
	private float roll = 0.0f;

	private Vector3 degrees = new Vector3(0, 0, 0);

	void Start () {
		Debug.Log(Input.compass.enabled);
		Input.compass.enabled = true;
		Debug.Log(Input.compass.enabled);
	}
	
	void Update () {
		GetYaw();
		GetPitch();
		Debug.Log(degrees);

		Vector3 v = Vector3.forward;
		//v = RotateX(v, degrees.x);
		v = RotateY(v, degrees.y);
		//RotateX(v, degrees.x);
		//RotateY(v, degrees.y);
		//RotateZ(v, degrees.z);
		Debug.Log(v);
		transform.forward = Vector3.RotateTowards(transform.forward, v, 0.01f, 0.0f);
		/*transform.Rotate(new Vector3(0,10,0));

		Vector3 acc = Input.acceleration;
		acc.x = 0.0f;
		float z = Mathf.Abs(acc.y);
		acc.y = acc.z;
		acc.z = z;
		acc.Normalize();
		acc.x = transform.forward.x;
		Debug.Log(acc);
		transform.forward = acc;*/
	}

	private void GetYaw()
	{
		if (Input.touches.Length > 0)
		{
			degrees.y += Input.GetTouch(0).deltaPosition.x;
			//transform.Rotate(new Vector3(0, Input.GetTouch(0).deltaPosition.x, 0));
		}
	}

	private void GetPitch()
	{
		prevPitch = pitch;
		pitch = Input.acceleration.z;
		//transform.Rotate(new Vector3(90 *(prevPitch - pitch), 0, 0));
		degrees.x += 90 * (prevPitch - pitch);
	}

	public Vector3 RotateX( Vector3 v, float angle )
    {
        float sin = Mathf.Sin( angle );
        float cos = Mathf.Cos( angle );

        float ty = v.y;
        float tz = v.z;

        v.y = (cos * ty) - (sin * tz);
        v.z = (cos * tz) + (sin * ty);
        return v;
    }

    public Vector3 RotateY( Vector3 v, float angle )
    {
        float sin = Mathf.Sin( angle );
        float cos = Mathf.Cos( angle );

        float tx = v.x;
        float tz = v.z;

        v.x = (cos * tx) + (sin * tz);
        v.z = (cos * tz) - (sin * tx);
        return v;
    }
	
}

public static class Vector3Ext
{
	public static void RotateX( this Vector3 v, float angle )
    {
        float sin = Mathf.Sin( angle );
        float cos = Mathf.Cos( angle );

        float ty = v.y;
        float tz = v.z;

        v.y = (cos * ty) - (sin * tz);
        v.z = (cos * tz) + (sin * ty);
    }

    

    public static void RotateY( this Vector3 v, float angle )
    {
        float sin = Mathf.Sin( angle );
        float cos = Mathf.Cos( angle );

        float tx = v.x;
        float tz = v.z;

        v.x = (cos * tx) + (sin * tz);
        v.z = (cos * tz) - (sin * tx);
    }

 

    public static void RotateZ( this Vector3 v, float angle )
    {
        float sin = Mathf.Sin( angle );
        float cos = Mathf.Cos( angle );

        float tx = v.x;
        float ty = v.y;

        v.x = (cos * tx) - (sin * ty);
        v.y = (cos * ty) + (sin * tx);
    }
}
