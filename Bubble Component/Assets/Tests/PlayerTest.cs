using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTest
    {
        GameObject bubble;
        GameObject player;

        [SetUp]
        public void Setup()
        {
            bubble = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/BubblePrefab"));
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        }
        // A Test behaves as an ordinary method
        [Test]
        public void PlayerTestSimplePasses()
        {
            // Use the Assert class to test conditions
            Assert.IsNull(bubble);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayerTestWithEnumeratorPasses()
        {
            bubble.transform.position = new Vector2(10, 100);
            bubble.transform.position = new Vector2(10, 110);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            yield return new WaitForSeconds(1.0f);
            Assert.AreEqual(bubble.transform.position.y, player.transform.position.y);
        }
    }
}
