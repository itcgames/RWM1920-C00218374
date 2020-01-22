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
        // A Test behaves as an ordinary method
        [Test]
        public void MovementTestSimplePasses()
        {
            // Use the Assert class to test conditions
            bool output = MovementFilter.getBubble();

            Assert.AreEqual(false, output);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MovementTestWithEnumeratorPasses()
        {
            bubble = GameObject.FindGameObjectWithTag("bubble");
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            Vector3 output = bubble.transform.position;
            bool outputbool = MovementFilter.getBubble();
            yield return new WaitForSeconds(5.0f);

            Assert.AreNotEqual(MovementFilter.getPosition(), output);
        }
    }
}
