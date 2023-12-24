function Bird::Jump(%this)
{
   //%this.applyLinearImpulse("0 2000", %this.getPosition());
   %this.setLinearVelocity("0 50");
}

function Bird::onCollision(%this, %object, %collisionDetails)
{
   echo("COLLISION");
}