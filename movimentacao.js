#pragma strict

var Animador: Animator;
var rb2D: Rigidbody2D;


var Velocidade: float;
var VeloPulo: float;
var Chao: boolean;
var IniRaycast: Transform;
var FimRaycast: Transform;

static var Vida: int;

var Danobool: boolean;
var Dano: float;

var IniARaycast: Transform;
var FimARaycast: Transform;
var Lamina: GameObject;

function Start () {
	
	Vida = 100;
	Velocidade = 0.2;
	VeloPulo = 45;
	Dano = 10;
	
}

function Update () {
	
	
  	Raycasting ();
	
	if(Input.GetButtonDown("Fire1"))
   	{
		Animador.SetBool("atka", true);
	}
	else
	{
		Animador.SetBool("atka", false);
	}
      


		
	transform.position.x += Input.GetAxis("Horizontal") * Velocidade * Time.deltaTime;
		
	if(Input.GetAxis("Horizontal") != 0)
	{

	if(Input.GetAxis("Horizontal") > 0)
	
	{
		transform.localScale.x = 5;
	
	}
	else
	{
		transform.localScale.x = -5;
		
	}
	
	}
	
	if(Input.GetKey("left shift"))
	{
	Velocidade = 50;
	}
   else
	{
	Velocidade = 30;
	}

	if(Input.GetButtonDown("Jump") && Chao == true)
{
	rb2D.velocity.y = VeloPulo;
	
}

if(Chao == false)
  {
     if(rb2D.velocity.y > 0)
     {
       Animador.SetBool("pular", true);
       
     }
 		
  } 
 if(Chao == true) 
 {
    Animador.SetFloat("andar", Mathf.Abs(Input.GetAxis("Horizontal")));
    Animador.SetBool("pular", false);
    
 }	
 if(Danobool == true)
 {	
 	Animador.SetBool("Ldano", true); 
 	rb2D.velocity.y = Dano;
 	Danobool = false;
	Vida = Vida - 10;
	PiscandoDano(); 
 }
 if(Vida <= 0)
 {
 	Vida = 0;
 }
  
 }


function Raycasting ()
{
  Debug.DrawLine(IniRaycast.position, FimRaycast.position, Color.red);
  if(Physics2D.Linecast(IniRaycast.position, FimRaycast.position))
  {
   Chao = true;
  }
  else
  {
   Chao = false;
  }
  }
  
  

function OnTriggerEnter2D (Coll: Collider2D)
{
	if(Coll.gameObject.tag == "atake" )
	{	
		
		
		Danobool = true;
		
	yield WaitForSeconds(0.1);
	Danobool = false;
	
		yield WaitForSeconds(0.1);
		Animador.SetBool("Ldano", false);
		Danobool = false;
	}

}

function OnColliderEnter2D (Coll: Collider2D)
{

	if(Coll.gameObject.tag == "ninja enemy" )
	{
		Danobool = true;
		transform.gameObject.tag = "dano";
		yield WaitForSeconds(0.5);
		transform.gameObject.tag = "Player";
	}

}
function PiscandoDano()
{
	for(var n=0; n<3; n++)
	{
		GetComponent.<Renderer>().enabled = true; 
		yield WaitForSeconds(0.1); 
		GetComponent.<Renderer>().enabled = false;
		yield WaitForSeconds(0.1); 
		 
	}
	GetComponent.<Renderer>().enabled = true;
}