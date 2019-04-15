using System;
using System.Net.Http;
using System.Threading.Tasks;
using LooneyInvaders.Model;
using NUnit.Framework;

namespace LooneyInvaders.Tests
{
    public class RewardManagerTest : TestBase
    {


        [Test]
        public void DoTest()
        {
            var str = RewardsManager.GetWeaponRewardCode(Weapons.Standard);
        }

        [Test]
        public async Task DoTest2Async()
        {
            var client = new HttpClient();
            var str = await RewardsManager.GetWeaponRewardCodeAsync(client, Weapons.Standard);
        }
    }
}
