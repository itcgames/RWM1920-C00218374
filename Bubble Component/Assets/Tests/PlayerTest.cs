using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTest
    {
        GameObject bubble = Resources.Load("Prefabs/BubblePrefab") as GameObject;
        GameObject player = Resources.Load("Prefabs/Player") as GameObject;

        [SetUp]
        public void Setup()
        {
            bubble = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/BubblePrefab"));
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        }

        //Player is picked up by the bubble
        [UnityTest]
        public IEnumerator PlayerTestWithEnumeratorPasses()
        {
            bubble.transform.position = new Vector2(10, 0);
            player.transform.position = new Vector2(10, 0);

            yield return new WaitForSeconds(0.1f);
            Assert.True(player.transform.IsChildOf(bubble.transform));
        }

        //should fail
        //only here for the wait for seconds
        [UnityTest]
        public IEnumerator PlayerDestroyTestWithEnumeratorPasses()
        {
            yield return new WaitForSeconds(5.0f);
            Assert.IsNull(player);
        }
    }
}
