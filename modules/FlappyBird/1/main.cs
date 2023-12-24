function FlappyBird::create( %this )
{   
   // Load all scripts
   exec("./scripts/Bird.cs");
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
   Canvas.setContent(%window);

   %scene = TamlRead("./objects/Scene.taml");
   %window.setScene(%scene);

   %background = TamlRead("./objects/Background.taml");
   %scene.add(%background);
   
   %ground = TamlRead("./objects/Ground.taml");
   %scene.add(%ground);
   
   %bird = TamlRead("./objects/Bird.taml");
   %scene.add(%bird);
   
   %pipe = TamlRead("./objects/Pipe.taml");
   %scene.add(%pipe);
   //%pipe.createPolygonBoxCollisionShape();   
   //TamlWrite( %pipe, "stuff.taml" );
   
   %scene.setDebugOn( "collision" );
}

if (!isObject(SceneWindowProfile)) new GuiControlProfile(SceneWindowProfile)
{
    modal = true;
};