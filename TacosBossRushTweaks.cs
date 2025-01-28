using CalamityMod.Enums;
using CalamityMod.Events;
using CalamityMod.Systems;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using Terraria.ModLoader;

namespace TacosBossRushTweaks;

public class TacosBossRushTweaks : Mod {
	public override void Load() {
		BossRushDialogueSystem.BossRushDialogue[BossRushDialoguePhase.StartRepeat] = BossRushDialogueSystem.BossRushDialogue[BossRushDialoguePhase.Start];
		OriginalMusic.Apply();
	}

	public override void Unload() {
		OriginalMusic.Undo();
	}


	public Hook OriginalMusic = new Hook(
		typeof(BossRushEvent).GetProperty("MusicToPlay", BindingFlags.Public | BindingFlags.Static).GetMethod,
		(Func<int> orig) => {
			return ModContent.GetInstance<TacosBossRushTweaksConfig>().UseBossRushMusic ? orig() : -1;
		},
		false
	);
}