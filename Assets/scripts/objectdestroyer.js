#pragma strict


function OnCollisionEnter(collision : Collision)
{
    if (collision.gameObject.tag == "Obstacles" || collision.gameObject.tag == "Foreground")
    {
        Destroy(collision.gameObject);
    }
}