using UnityEngine;
using System.Collections;

public class AppDevelopFlag
{
	public static readonly bool	DEVELOP_SYSTEM = true;
    public static readonly bool	DEVELOP_USER   = true;
    public static readonly bool	RELEASE        = false;
}

public class AppPaths
{
	public static readonly string  	PERSISTENT_DATA      = Application.persistentDataPath;
	public static readonly string	PATH_RESOURCE_SFX    = "Sounds/MenuSfx/";
    public static readonly string	PATH_RESOURCE_MUSIC  = "Sounds/Music/";
}

public class AppScenes
{
	public static readonly string 	MAIN_SCENE			= "Menu";
	public static readonly string 	LOADING_SCENE		= "Loading";
	public static readonly string	LOADING_BACK_SCENE	= "LoadingBack";
	public static readonly string 	GAME_SCENE			= "Game";
	public static readonly string   GAME2_SCENE			= "Game2";
}

public class AppPlayerPrefKeys
{
	public static readonly string	MUSIC_VOLUME = "MusicVolume";
	public static readonly string	SFX_VOLUME   = "SfxVolume";
}

public class AppSounds
{
	public static readonly string	MAIN_TITLE_MUSIC = "Zephyr";
	public static readonly string	GAME1_MUSIC      = "Stupid_Dancer";
	public static readonly string	GAME2_MUSIC		 = "StreetLove";
	public static readonly string	BUTTON_SFX       = "Hit4";
	public static readonly string	SHOT1_SFX		 = "pistol_shot";
	public static readonly string   SHOT2_SFX		 = "shoot";

}



