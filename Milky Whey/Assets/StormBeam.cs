using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormBeam : MonoBehaviour {

	[Header("Prefabs")]
	public GameObject[] beamLineRendererPrefab;
	public GameObject[] beamStartPrefab;
	public GameObject[] beamEndPrefab;

//	public AudioClip magicBeamShoot;
//	public AudioClip magicBeamHit;

	private int currentBeam = 0;

	private GameObject beamStart;
	private GameObject beamEnd;
	private GameObject beam;
	private LineRenderer line;
//	private AudioSource magicBeamAudio;

	[Header("Adjustable Variables")]
	public float beamEndOffset = 1f; //How far from the raycast hit point the end effect is positioned
	public float textureScrollSpeed = 8f; //How fast the texture scrolls along the beam
	public float textureLengthScale = 3; //Length of the beam texture

	// Use this for initialization
	void Start () {
		beamStart = Instantiate(beamStartPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		beamEnd = Instantiate(beamEndPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		beam = Instantiate(beamLineRendererPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		line = beam.GetComponent<LineRenderer>();
		beamStart.SetActive(false);
		beamEnd.SetActive(false);
		beam.SetActive(false);
//		magicBeamAudio = GetComponent<AudioSource>();

	}

	public void DestroyMagicBeam()
	{
		if(beamStart.activeSelf)
			beamStart.SetActive(false);
		if (beamEnd.activeSelf)
			beamEnd.SetActive(false);
		if (beam.activeSelf)
			beam.SetActive(false);

//		magicBeamAudio.Stop();
	}

	public void FireWeapon(Vector3 from, Vector3 to)
	{
		beamStart.SetActive(true);
		beamEnd.SetActive(true);
		beam.SetActive(true);
		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 tdir = mouse - transform.position;

		ShootBeamInDir(from, to);

//		GetComponent<WeaponStats>().weaponDmgManaCost = GameManager.Manager.GetComponent<SelectSkillUIScript>().GetCertainSkill("BasicAtkDmgSkill").currentLevel - 1;

//		if (GameManager.Manager.GetPlayer.GetComponent<PlayerStats>().CostMana(GetComponent<WeaponStats>().GetTotalManaCost()))
//		{
//			ShootBeamInDir(transform.position, tdir);
//		}
//		else
//		{
//			DestroyMagicBeam();
//		}
	}

	void ShootBeamInDir(Vector3 start, Vector3 dir)
	{
//		if (!magicBeamAudio.isPlaying)
//			magicBeamAudio.PlayOneShot(magicBeamShoot);

		line.positionCount = 2;
		line.SetPosition(0, start);
		beamStart.transform.position = start;
		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 end = dir;

		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(dir.x, dir.y, 0), 100, 1<<LayerMask.NameToLayer("Resource Planet"));

		if (hit.collider!=null)
		{

			Debug.Log("Hit Asteroid");
//			hit.collider.gameObject.GetComponent<EnemyStats>().NowHP -= GetComponent<WeaponStats>().WeaponDmg;
			//end = hit.point;
		}
		else
		{

			//end = start + new Vector3(dir.x, dir.y, 0).normalized * 100;
		}
		//end = hit.point;

		beamEnd.transform.position = end;
		line.SetPosition(1, end);

		beamStart.transform.LookAt(beamEnd.transform.position);
		beamEnd.transform.LookAt(beamStart.transform.position);

		float distance = Vector3.Distance(start, end);
		line.sharedMaterial.mainTextureScale = new Vector2(distance / textureLengthScale, 1);
		line.sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * textureScrollSpeed, 0);
	}
}
