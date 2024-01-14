function FlappyBird::create( %this )
{
   setRandomSeed(getRealTime());   
   
   // Load all scripts
   exec("./scripts/Bird.cs");
   exec("./scripts/Pipes.cs");
   //exec("./scripts/SceneWindow.cs");
   
   // Load the game
   %this.loadGame();
}

function FlappyBird::destroy( %this )
{

}

//-----------------------------------------------------------------------------

function FlappyBird::loadGame(%this)
{
   %window = TamlRead( "./objects/SceneWindow.taml" );
   %window.setCameraSize(25, 18.75);
   //%window.setCameraSize( 50, 37.5 );
   Canvas.setContent( %window );   

   %scene = TamlRead( "./objects/Scene.taml" );
   %window.setScene( %scene );
   
   new ActionMap(pauseMap);
   pauseMap.bind(keyboard, "p", pause);
   $PAUSE_MODE = false;
   pauseMap.push();
   
   %window.addInputListener( Bird );
   //Bird.setActive(false);
   //Bird.setPosition(0 , -9.375);
   
   createPipes( %scene );

   %scene.setDebugOn( "collision" );
}

function pause(%val)
{
   if(%val)
   {
      if ( $PAUSE_MODE == true )   
         $PAUSE_MODE = false;      
      else   
         $PAUSE_MODE = true;
      
      GameScene.setScenePause( $PAUSE_MODE );
   }
}

function createPipes(%scene)
{   
   for (%i = 0; %i < 3; %i++)
   {            
      %posX = 14.5 + %i * 10;
      %posY = BottomPipe::getRandomY();
      %pipeBottom = Pipe::create( "BottomPipe", %posX SPC %posY );
      %scene.add( %pipeBottom );
      %pipeBottom.moveToEnd( %posY );
      
      %posX = 14.5 + %i * 10;
      %posY = TopPipe::getRandomY();
      %pipeTop = Pipe::create( "TopPipe", %posX SPC %posY );
      %pipeTop.setFlipY( true );
      %scene.add( %pipeTop );
      %pipeTop.moveToEnd( %posY );
      //%pipeTop = Pipe::create( "TopPipe", %posX SPC %posY + getRandom( 2, 8 ) );
      //%scene.add( %pipeTop );
      //%pipeTop.moveToEnd( %posY );
   }   
}

if (!isObject(SceneWindowProfile)) new GuiControlProfile(SceneWindowProfile)
{
    modal = true;
};