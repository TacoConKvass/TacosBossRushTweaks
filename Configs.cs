using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace TacosBossRushTweaks;

public class TacosBossRushTweaksConfig : ModConfig
{
	public override ConfigScope Mode => ConfigScope.ClientSide;

	[Header("Music")]
	[DefaultValue(true)]
	public bool UseBossRushMusic;
}

public class TacosBossRushDamageTweaksConfig : ModConfig
{
	public override ConfigScope Mode => ConfigScope.ServerSide;

	[Header("Dialogue")]
	[ReloadRequired]
	[DefaultValue(true)]
	public bool LongIntro;
}