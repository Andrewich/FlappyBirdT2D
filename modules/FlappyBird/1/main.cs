function FlappyBird::create( %this )
{   
   // Load all scripts
   exec("./scripts/Bird.cs");
   exec("./scripts/Pipe.cs");
   exec("./scripts/SceneWindow.cs");
   
   // Load the game
   %this.loadGame();
}

//-----------------------------------------------------------------------------

function FlappyBird::destroy( %this )
{

}

//-----------------------------------------------------------------------------

function FlappyBird::loadGame(%this)
{
   %window = TamlRead("./objects/SceneWindow.taml");
   %window.setCameraSize(25, 18.75);
   //%window.setCameraSize(50, 37.5);
   Canvas.setContent(%window);

   %scene = TamlRead("./objects/Scene.taml");
   %window.setScene(%scene);   
   
   %pipes = TamlRead("./objects/Pipes.taml");   
   for (%index = 0; %index < %pipes.getCount(); %index++)
   {
      %pipe = %pipes.getObject(%index);
      %scene.add(%pipe);
      %pipe.moveToEnd();
   }
   
   %scene.setDebugOn( "collision" );
}

if (!isObject(SceneWindowProfile)) new GuiControlProfile(SceneWindowProfile)
{
    modal = true;
};