using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace BannerKings.CampaignContent.Economy.Markets
{
    public class MarketGroup : BannerKingsObject
    {
        public MarketGroup(string id) : base(id) {
        }

        public void Initialize(TextObject name, TextObject description, CultureObject culture, Dictionary<CultureObject, float> spawns, Dictionary<ItemCategory, float> demands = null) {
            Initialize(name, description);
            Culture = culture;
            Spawns = spawns;
            Demands = demands;
        }

        public CultureObject Culture { get; private set; }
        public Dictionary<CultureObject, float> Spawns { get; private set; }
        public Dictionary<ItemCategory, float> Demands { get; private set; }

        public float GetSpawn(CultureObject culture) {
            float result = 0f;
            if (culture.StringId == Culture.StringId) result = 1f;
            else if (Spawns.ContainsKey(culture)) result = Spawns[culture];

            return result;
        }

        public float GetDemand(ItemCategory itemCategory) {
            bool flag = this.Demands == null;
            if (flag) {
                this.Demands = new Dictionary<ItemCategory, float>();
            }
            float result;
            bool flag2 = !this.Demands.TryGetValue(itemCategory, out result);
            if (flag2) {
                result = 1f;
            }
            return result;
        }
    }
}
