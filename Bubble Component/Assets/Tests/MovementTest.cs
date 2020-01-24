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
        GameObject particles;
        [SetUp]
        public void Setup()
        {
            bubble = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/BubblePrefab"));
        }
           
        //should pass
        [Test]
        public void MovementTestSimplePasses()
        {
            //is bubble in scene
            Assert.IsNotNull(bubble);            
        }

        //should pass
        [UnityTest]
        public IEnumerator MovementTestWithEnumeratorPasses()
        {
            bubble.transform.position = new Vector2(10, 100);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            float output = bubble.transform.position.y;
            yield return new WaitForSeconds(1.0f);
          
            Assert.AreNotEqual(bubble.transform.position.y, output);
        }

        //should fail
        [UnityTest]
        public IEnumerator BubbleDestroyTestSimplePasses()
        {
            yield return new WaitForSeconds(1.0f);
            Assert.IsNotNull(bubble);
        }
    }
}
