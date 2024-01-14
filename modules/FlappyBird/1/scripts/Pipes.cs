//-Pipe------------------------------------------------------------------------

function Pipe::create( %class, %position )
{
   %pipe = new Sprite() {
      superclass = "Pipe";
      class = %class;
      SceneLayer = 1;
      Size = "2 12.75";
      BodyType = "Kinematic";
      Image = "FlappyBird:Pipe";
      Frame = 0;
      position = %position;
   };
   %pipe.createPolygonBoxCollisionShape();

   return %pipe;
}

function Pipe::moveToEnd( %this, %posY )
{   
   %this.moveTo("-14.5" SPC %posY, 5);
}

function Pipe::getRandomY( %this )
{
   if ( %this.class $= "TopPipe" )   
      return TopPipe::getRandomY();   
   else
      return BottomPipe::getRandomY();   
}

function Pipe::onMoveToComplete( %this )
{
   %this.setPositionX( 14.5 );
   %posY = Pipe::getRandomY( %this );
   //echo( %this.class SPC ": " SPC %posY );
   %this.setPositionY( %posY );   
   Pipe::moveToEnd( %this, %posY );
}

//-BottomPipe------------------------------------------------------------------

function BottomPipe::getRandomY()
{   
   //return getRandom(-6.75, -12.75) + getRandom();
   %posY = getRandom(-8.375, -15.6) + getRandom();
   echo( %posY );
   return %posY;//getRandom(-9, 0) + getRandom();
}

//-TopPipe---------------------------------------------------------------------

function TopPipe::getRandomY()
{
   //return getRandom( 8.75, 12.75 ) + getRandom();
   %posY = getRandom( 8.375, 15.6 ) + getRandom();
   return %posY;//getRandom( 4, 12.75 ) + getRandom();
}