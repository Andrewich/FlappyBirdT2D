function Bird::Jump(%this)
{   
   %this.setLinearVelocity("0 11");   
}

function Bird::onCollision(%this, %object, %collisionDetails)
{
   echo("COLLISION");
}