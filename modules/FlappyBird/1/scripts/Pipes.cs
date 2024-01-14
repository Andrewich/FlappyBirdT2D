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
   {
      return TopPipe::getRandomY();
   }
   else 
   {
      %rand = BottomPipe::getRandomY(); 
      echo ( %rand );
      return %rand;
   }
}

function Pipe::onMoveToComplete( %this )
{
   %this.setPositionX( 14.5 );
   %posY = Pipe::getRandomY( %this );
   %this.setPositionY( %posY );   
   Pipe::moveToEnd( %this, %posY );
}

//-BottomPipe------------------------------------------------------------------

//function BottomPipe::onMoveToComplete( %this )
//{   
   //%this.setPositionX( 14.5 );
   //%posY = BottomPipe::getRandomY();
   //%this.setPositionY( %posY );
   //%this.moveToEnd( %posY );
//}

function BottomPipe::getRandomY()
{   
   return getRandom(-5.75, -12.75) + getRandom();
}

//function TopPipe::onMoveToComplete( %this )
//{
   //%this.setPositionX( 14.5 );
   //%posY = TopPipe::getRandomY();
   //%this.setPosition( %posY );
   //%this.moveToEnd( %posY );
//}

function TopPipe::getRandomY()
{
   return getRandom( -3, 12.75 ) + getRandom();
}