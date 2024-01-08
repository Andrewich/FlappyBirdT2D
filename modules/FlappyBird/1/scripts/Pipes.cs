// Local functions

function TopPipe::getRandomY()
{
   return %this.getRandom(5, 19);
}

function BottomPipe::getRandomY()
{
   return %this.getRandom(-10, 5);
}

// Callbacks

function Sprite::onAdd(%this)
{   
   %this.onMoveToComplete();
}

function Sprite::onMoveToComplete(%this)
{
   %rand = %this.getRandomY();
   %this.setPositionY( %rand );
   %this.moveTo("-14.5" SPC %rand, 5);
}