using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Master : MonoBehaviour {

	public GameObject go;
	public GameObject pause;
	public GameObject obs1;
	public GameObject powerUp;
	public GameObject textScore,panelWin,winText,enterText;
	public GameObject bg1,bg2,bg3,bg4;
	Renderer RBG1,RBG2,RBG3,RBG4,RBG5;
	float startX;
	float fWidth1,fWidth2,fWidth3,fWidth4,fWidth5;
	Rigidbody2D rg;
	Rigidbody2D rgObs1;
	Rigidbody2D rgPowerUp;
	Rigidbody2D rgBG1,rgBG2,rgBG3,rgBG4;
	Transform Tgo;
	Transform Tbg1,Tbg2,Tbg3,Tbg4,Tbg5;
	Vector2 tempRG;
	public BoxCollider2D topWall;
	public BoxCollider2D bottomWall;
	public BoxCollider2D leftWall;
	public BoxCollider2D rightWall;
	public Camera mainCam;
	Transform TCam;
	Rigidbody2D rgCam;
	Vector2 tempRGCam;
	Vector2 empty;
	public AudioSource flapEffect;
	private Animator animator;
	SpriteRenderer spPause;
	public int level;
	int score;
	int multi,tempMulti;
	int isWin;

	int flagPause ;

	// Use this for initialization
	void Start () {
		initVar ();

		topWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2f, 0f, 0f)).x, 1f);
		topWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3 ( 0f, Screen.height, 0f)).y - 1.2f);
		
		bottomWall.size = new Vector2 (mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 2, 0f, 0f)).x, 1f);
		bottomWall.offset = new Vector2 (0f, mainCam.ScreenToWorldPoint (new Vector3( 0f, 0f, 0f)).y - 0.5f);
		
		leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);;
		leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 7.8f, 0f);
		
		rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);
		rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.3f, 0f);

		InvokeRepeating("Plus", 0, 1.0f);
	//	Tbg3.position = new Vector2(51.5f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		RotateBackground ();
		tempRG = rg.velocity;
		if (flagPause == 1) {
			tempRG.x = 0f;
		} else {
			tempRG.x = -5f;
		}
		rgBG1.velocity = tempRG;
		rgBG2.velocity = tempRG;
		rgBG3.velocity = tempRG;
		rgBG4.velocity = tempRG;

		tempRG = rg.velocity;
		if (Input.GetKeyDown (KeyCode.Space)) {
			rg.AddForce (new Vector2 (0, 300f));
			flapEffect.Play ();
		} else if (Input.GetKeyDown (KeyCode.LeftArrow) && flagPause != 1) {
			tempRG.x = -5f;
			tempRGCam = tempRG;
			tempRGCam.y = 0f;
			if (Tgo.position.x < -5.4) {
				tempRG.x = 0;
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow) && flagPause != 1) {
			tempRG.x = 2f;
			if (Tgo.position.x >= 5.2) {
				tempRG.x = 0;
			}
		} else if (isWin == 0 && Input.GetKeyDown (KeyCode.Escape)) {
			if (flagPause == 0)
				MakePause ();
			else
				MakeUnpause ();
		} else if (isWin == 1) {
			if(Input.GetKeyDown (KeyCode.Return)){
				if(level == 1)
					Application.LoadLevel("Story2");
				else if(level == 2)
					Application.LoadLevel("Story3");
				else if(level == 3)
					Application.LoadLevel("EndStory");
			}
			tempRG.x = 3f;
			tempRG.y = 0f;
		}
		rg.velocity = tempRG;
	}

	public void Multiply(){
		if (multi < 100) {
			multi *= 2;
		}
	}
	public void EndMultiply(){
		multi=0;
	}

	void Plus(){
		score += 100*multi;
		textScore.GetComponent<Text> ().text = score.ToString();
		if (level==1 && score >= 2500) {
			MakeWin();
		}else if (level==2 && score >= 7500) {
			MakeWin();
		}if (level==3 && score >= 15000) {
			MakeWin();
		}
	}

	void initVar(){
		isWin = 0;
		score = 0;
		multi = 1;
		rg = go.GetComponent<Rigidbody2D>();
		TCam = mainCam.GetComponent<Transform> ();
		Tgo = go.GetComponent<Transform> ();
		empty = Vector2.zero;
		rgObs1 = obs1.GetComponent<Rigidbody2D> ();
		rgBG1 = bg1.GetComponent<Rigidbody2D> ();
		rgBG2 = bg2.GetComponent<Rigidbody2D> ();
		rgBG3 = bg3.GetComponent<Rigidbody2D> ();
		rgBG4 = bg4.GetComponent<Rigidbody2D> ();
		rgPowerUp = powerUp.GetComponent<Rigidbody2D> ();
		Tbg1 = bg1.GetComponent<Transform> ();
		Tbg2 = bg2.GetComponent<Transform> ();
		Tbg3 = bg3.GetComponent<Transform> ();
		Tbg4 = bg4.GetComponent<Transform> ();
		startX = Tbg1.position.x;
		RBG1 = bg1.GetComponent<Renderer> ();
		RBG2 = bg2.GetComponent<Renderer> ();
		RBG3 = bg3.GetComponent<Renderer> ();
		RBG4 = bg4.GetComponent<Renderer> ();
		fWidth1 = RBG1.bounds.size.x;
		fWidth2 = RBG2.bounds.size.x;
		fWidth3 = RBG3.bounds.size.x;
		fWidth4 = RBG4.bounds.size.x;

		spPause = pause.GetComponent<SpriteRenderer> ();
		spPause.enabled = false;

		flagPause = 0;
	}

	void RotateBackground(){
		if (Tbg1.position.x <= startX - fWidth1) {
			Tbg1.position = new Vector3(Tbg4.position.x+fWidth4-0.25f,Tbg1.position.y,20f);
		}
		if (Tbg2.position.x <= startX - fWidth2) {
			Tbg2.position = new Vector3(Tbg1.position.x+fWidth1-0.235f,Tbg1.position.y,20f);
		}
		if (Tbg3.position.x <= startX - fWidth3) {
			Tbg3.position = new Vector3(Tbg2.position.x+fWidth2-0.26f,Tbg1.position.y,20f);
		}
		if (Tbg4.position.x <= startX - fWidth4) {
			Tbg4.position = new Vector3(Tbg3.position.x+fWidth3-0.26f,Tbg1.position.y,20f);
		}
	}

	void MakeWin(){
		isWin = 1;
		flagPause=-1;
		panelWin.GetComponent<Image>().enabled = true;
		winText.GetComponent<Text>().enabled = true;
		enterText.GetComponent<Text>().enabled = true;
		multi = 0;

		rg.isKinematic = true;
		rgObs1.isKinematic = true;
		rgPowerUp.isKinematic = true;
		rgBG1.isKinematic = true;
		rgBG2.isKinematic = true;
		rgBG3.isKinematic = true;
		rgBG4.isKinematic = true;
		GameObject.Find ("GelombangKecil").GetComponent<Obstacle>().Pause();
		GameObject.Find ("Item_Bubble_Shiled").GetComponent<PowerUp>().Pause();
	}

	void MakePause(){
		flagPause = 1;
		tempMulti = multi;
		multi = 0;
		spPause.enabled = true;
		rg.isKinematic = true;
		rgObs1.isKinematic = true;
		rgPowerUp.isKinematic = true;
		rgBG1.isKinematic = true;
		rgBG2.isKinematic = true;
		rgBG3.isKinematic = true;
		rgBG4.isKinematic = true;
		GameObject.Find ("Penyu").GetComponent<Penyu1>().Pause ();
		GameObject.Find ("GelombangKecil").GetComponent<Obstacle>().Pause();
		GameObject.Find ("Item_Bubble_Shiled").GetComponent<PowerUp>().Pause();
	}

	void MakeUnpause(){
		flagPause = 0;
		multi = tempMulti;
		spPause.enabled = false;
		rg.isKinematic = false;
		rgObs1.isKinematic = false;
		rgPowerUp.isKinematic = false;
		rgBG1.isKinematic = false;
		rgBG2.isKinematic = false;
		rgBG3.isKinematic = false;
		rgBG4.isKinematic = false;
		GameObject.Find ("Penyu").GetComponent<Penyu1>().Unpause ();
		GameObject.Find ("GelombangKecil").GetComponent<Obstacle>().Unpause();
		GameObject.Find ("Item_Bubble_Shiled").GetComponent<PowerUp>().Unpause();
	}
}
