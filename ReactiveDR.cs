using CalamityMod.Events;
using System;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;
using CalamityMod;

namespace TacosBossRushTweaks;

public class ReactiveDR : GlobalNPC
{
	public override bool InstancePerEntity => true;

	public bool SpawnedInBossRush;

	public override void OnSpawn(NPC npc, IEntitySource source) {
		SpawnedInBossRush = BossRushEvent.BossRushActive && CalamityUtils.IsABoss(npc);
	}

	public override bool PreAI(NPC npc) {
		if (SpawnedInBossRush) npc.takenDamageMultiplier = Math.Clamp(npc.life / (float)npc.lifeMax, 1 - ModContent.GetInstance<TacosBossRushDamageTweaksConfig>().MaxDamageReduction, 1f);
		return true;
	}
}