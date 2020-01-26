using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SimultaneousObjects
    {
        GameObject floor;
        GameObject player;
        GameObject player2;
        GameObject player3;
        GameObject button;
        [SetUp]
        public void Setup()
        {
            floor = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Floor"));           
            button = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Button"));
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            player2 = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        }

        //if 2 players then 2 bubbles
        [UnityTest]
        public IEnumerator SimultaneousObjectsWithEnumeratorPasses()
        {
            player.transform.position = new Vector2(-33, 12);
            player2.transform.position = new Vector2(-53, 19);

            yield return new WaitForSeconds(5.0f);
            GameObject[] bubble = GameObject.FindGameObjectsWithTag("Bubble");
            Assert.IsNotNull(bubble);
        }
    }
}
