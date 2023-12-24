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
   %ground.createPolygonBoxCollisionShape();
   %ground.setSceneGroup( 2 );
   %ground.setCollisionGroups( 15 );
   //%ground.setCollisionLayers(1);
   //%ground = new Scroller();
   //%ground.Size = "100 5";
   //%ground.Position = "0 -36";
   //%ground.FixedAngle = "1";
   //%ground.BodyType = "static";
   //%ground.Image = "@asset=FlappyBird:Ground";
   //%ground.Frame = "0";
   //%ground.repeatX="1";
   //%ground.scrollX="3";
   //%ground.scrollPositionX="0.5";
   //%ground.createPolygonBoxCollisionShape();   
   //%ground.setCollisionGroups( 15 );
   //%ground.setCollisionLayers(1);
   %scene.add(%ground);   
   
   %groundBoundary = new SceneObject() { class = "GroundBoundary"; };
   %groundBoundary.setBodyType( "static" );
   %groundBoundary.createEdgeCollisionShape(-50, -10, 50, -10);   
   %groundBoundary.setCollisionGroups( 14 );
   %groundBoundary.setSceneGroup( 1 );
   %scene.add(%groundBoundary);
   
   //%box = new SceneObject();
   //%box.createPolygonBoxCollisionShape( 5, 4);
   //%box.setCollisionGroups( none );
   //%box.position = "25 0";
   //%box.setCollisionGroups( 15 );   
   //%scene.add(%box);
   
   %bird = TamlRead("./objects/Bird.taml");
   %bird.setBodyType( "dynamic" );
   %bird.createPolygonBoxCollisionShape();
   %bird.setSceneGroup( 15 );
   %bird.setCollisionCallback( true );
   %scene.add(%bird);
   
   %pipe = TamlRead("./objects/Pipe.taml");
   %pipe.createPolygonBoxCollisionShape();
   %pipe.setSceneGroup( 2 );
   %scene.add(%pipe);   
   
   %scene.setDebugOn( "collision" );
}

if (!isObject(SceneWindowProfile)) new GuiControlProfile(SceneWindowProfile)
{
    modal = true;
};