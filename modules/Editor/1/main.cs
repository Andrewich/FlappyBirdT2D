function Editor::create( %this )
{
   new ActionMap(EditorMap);
   EditorMap.push();
   
   EditorMap.bind(keyboard, "ctrl e", toggleEditor);
}

function Editor::destroy( %this )
{
   EditorMap.pop();
   EditorMap.delete();
}

//-----------------------------------------------------------------------------

function toggleEditor( %val )
{
   if (%val)
   {
      if ($editorMode == false)
      {      
         $editorMode = true;
         GameWindow.setCameraSize(50, 37.5);
      } else
      {
         $editorMode = false;
         GameWindow.setCameraSize(25, 18.75);
      }
   }
}