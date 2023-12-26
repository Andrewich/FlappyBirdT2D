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
   %window.setCameraSize(25, 18.75);   
   Canvas.setContent(%window);

   %scene = TamlRead("./objects/Scene.taml");
   %window.setScene(%scene);   

   %background = TamlRead("./objects/Background.taml");
   %scene.add(%background);
   
   //%ground = TamlRead("./objects/Ground.taml");
   //%scene.add(%ground);
   
   %bird = TamlRead("./objects/Bird.taml");   
   %scene.add(%bird);
   
   TamlWrite( %scene, "stuff.taml");
   
   //%pipe = TamlRead("./objects/Pipe.taml");
   //%scene.add(%pipe);
   //%pipe.createPolygonBoxCollisionShape();   
   //TamlWrite( %pipe, "stuff.taml" );
   
   %scene.setDebugOn( "collision" );
}

if (!isObject(SceneWindowProfile)) new GuiControlProfile(SceneWindowProfile)
{
    modal = true;
};