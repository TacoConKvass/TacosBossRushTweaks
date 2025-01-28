using CalamityMod.Events;
using System;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;

namespace TacosBossRushTweaks;

public class ReactiveDR : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public bool SpawnedInBossRush;

	public override void OnSpawn(NPC npc, IEntitySource source) {
		SpawnedInBossRush = BossRushEvent.BossRushActive;
	}

	public override bool PreAI(NPC npc) {
		if (SpawnedInBossRush) npc.takenDamageMultiplier = Math.Clamp(npc.life / npc.lifeMax, 1 - ModContent.GetInstance<TacosBossRushDamageTweaksConfig>().MaxDamageReduction, 1f);
		#if DEBUG
			Main.NewText(npc.takenDamageMultiplier);
		#endif
		return true;
	}
}