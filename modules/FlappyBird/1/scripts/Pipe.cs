function Sprite::onMoveToComplete(%this)
{
   echo("Move complete");
   %this.setPosition(%this.origin);
   echo("origin=" SPC %this.origin);
   %this.moveToEnd();
}

function Sprite::moveToEnd(%this)
{
   %this.moveTo("-14.5 -5", 5);
}