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
   Canvas.setContent(%window);

   %scene = TamlRead("./objects/Scene.taml");
   %window.setScene(%scene);   

   %background = TamlRead("./objects/Background.taml");
   %scene.add(%background);
   
   //%ground = TamlRead("./objects/Ground.taml");
   //%scene.add(%ground);
   
   %bird = TamlRead("./objects/Bird.taml");   
   %scene.add(%bird);
   
   %pipe = new Sprite() {
      class = "Pipe";
      SceneLayer = 1;
      Position = "12.5 -5";
      Size = "2 8.75";
      BodyType = "Kinematic";        
      Image = "FlappyBird:Pipe";
      Frame = 0;         
   };   
   %scene.add(%pipe);
   %pipe.moveTo("-12.5 -5", 5);
      
   
   //TamlWrite( %scene, "stuff.taml");
   
   //for (%count = 0; %count < 4; %count++)
   //{
      //%pipes[%count] = new Sprite() {
         //class = "Pipe";
         //SceneLayer = 1;
         //Size = "2 8.75";
         //BodyType = "Kinematic";
         ////LinearVelocity = "-5 0";
         //Image = "FlappyBird:Pipe";
         //Frame = 0;         
      //};
      ////%pipes[%count].createPolygonBoxCollisionShape();
      //%pos_x = 14.5 + (%count * 9);
      //%pos_y = -5;
      //%pipes[%count].setPosition(%pos_x, %pos_y);      
      //%scene.add(%pipes[%count]);
   //}
   
   //%pipe = TamlRead("./objects/Pipe.taml");
   //%scene.add(%pipe);   
   //TamlWrite( %pipe, "stuff.taml" );
   
   %scene.setDebugOn( "collision" );
}

if (!isObject(SceneWindowProfile)) new GuiControlProfile(SceneWindowProfile)
{
    modal = true;
};