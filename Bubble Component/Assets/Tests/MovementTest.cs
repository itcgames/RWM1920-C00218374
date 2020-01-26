using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovementTest
    {
        GameObject bubble;
        [SetUp]
        public void Setup()
        {
            bubble = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/BubblePrefab"));
        }
           
        [Test]
        public void MovementTestSimplePasses()
        {
            //is bubble in scene
            Assert.IsNotNull(bubble);            
        }

        //bubbles move up
        [UnityTest]
        public IEnumerator MovementTestWithEnumeratorPasses()
        {
            bubble.transform.position = new Vector2(10, 100);
            float output = bubble.transform.position.y;
            yield return new WaitForSeconds(1.0f);
          
            Assert.AreNotEqual(bubble.transform.position.y, output);
        }

        //should fail
        //the bubble destroys
        [UnityTest]
        public IEnumerator BubbleDestroyTestSimplePasses()
        {
            yield return new WaitForSeconds(1.0f);
            Assert.IsNotNull(bubble);
        }
    }
}
