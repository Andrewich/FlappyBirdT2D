// Input listener
function Bird::onTouchDown(%this, %touchID, %worldPosition)
{   
   Bird.jump();
}

function Bird::onCollision(%this, %object, %collisionDetails)
{
   echo("COLLISION");
}

//-----------------------------------------------------------------------------

function Bird::jump(%this)
{   
   %this.setLinearVelocity("0 11");   
}