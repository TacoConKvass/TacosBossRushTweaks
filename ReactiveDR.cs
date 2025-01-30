using CalamityMod.Events;
using System;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;
using CalamityMod;

namespace TacosBossRushTweaks;

public class ReactiveDR : GlobalNPC {
	public override bool InstancePerEntity => true;

	public bool SpawnedInBossRush;
	int timer;

	public override void OnSpawn(NPC npc, IEntitySource source) {
		SpawnedInBossRush = BossRushEvent.BossRushActive && CalamityUtils.IsABoss(npc);
		timer = 0;
	}

	public override bool PreAI(NPC npc) {
		timer++;
		return true;
	}

	public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers) {
		if (!SpawnedInBossRush) return;

		float healthRatio = npc.life / (float)npc.lifeMax;
		float timeRatio = timer / (float)CalamityMod.CalamityMod.bossKillTimes[npc.type];

		if (healthRatio + timeRatio >= 1) return;

		float baseDR = npc.Calamity().DR;

		float reactiveDR = ((1 - baseDR) * 10) - (((1 - baseDR) * 10) / (2 - timeRatio - healthRatio));
		modifiers.FinalDamage *= 1 - reactiveDR; 
	}
}