setLogMode(2);
// profileEnable( true );
setScriptExecEcho(false);

trace(false);

$Scripts::ignoreDSOs = true;

ModuleDatabase.EchoInfo = false;

AssetDatabase.EchoInfo = false;

AssetDatabase.IgnoreAutoUnload = true;

ModuleDatabase.scanModules("./modules");
ModuleDatabase.LoadExplicit("AppCore");

function onExit()
{
    ModuleDatabase.unloadExplicit("AppCore");
}

function androidBackButton(%val)
{
    if (%val)
    {
        quit();
    }
}