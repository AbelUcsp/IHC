var projectile : Rigidbody;
var speed = 20;
function Update()
{
    
    if (Municion.CurrentAmmo >= 1){
    
        if( Input.GetButtonDown( "Fire1" ) )
        {
            var instantiatedProjectile : Rigidbody = Instantiate(
             projectile, transform.position, transform.rotation );
            instantiatedProjectile.velocity =
             transform.TransformDirection( Vector3( 0, 0, speed ) );
            Physics.IgnoreCollision( instantiatedProjectile. GetComponent.<Collider>(),
             transform.root.GetComponent.<Collider>() );
        }
    }
}