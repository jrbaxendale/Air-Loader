using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Knife.HologramEffect
{
    public class Demo : MonoBehaviour
    {
#pragma warning disable CS0649 // Field 'Demo.groups' is never assigned to, and will always have its default value null
        [SerializeField] private GameObjectsGroup[] groups;
#pragma warning restore CS0649 // Field 'Demo.groups' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'Demo.previousButton' is never assigned to, and will always have its default value null
        [SerializeField] private Button previousButton;
#pragma warning restore CS0649 // Field 'Demo.previousButton' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'Demo.nextButton' is never assigned to, and will always have its default value null
        [SerializeField] private Button nextButton;
#pragma warning restore CS0649 // Field 'Demo.nextButton' is never assigned to, and will always have its default value null

        private int currentGroup;

        private void Start()
        {
            currentGroup = 0;
            OpenCurrent();

            previousButton.onClick.AddListener(Previous);
            nextButton.onClick.AddListener(Next);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                Next();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Previous();
            }
        }

        private void Next()
        {
            currentGroup++;
            if (currentGroup >= groups.Length)
            {
                currentGroup = 0;
            }

            OpenCurrent();
        }

        private void Previous()
        {
            currentGroup--;
            if (currentGroup < 0)
            {
                currentGroup = groups.Length - 1;
            }

            OpenCurrent();
        }

        private void OpenCurrent()
        {
            foreach (var g in groups)
            {
                g.SetActive(false);
            }
            groups[currentGroup].SetActive(true);
        }

        [System.Serializable]
        private class GameObjectsGroup
        {
#pragma warning disable CS0649 // Field 'Demo.GameObjectsGroup.gameObjects' is never assigned to, and will always have its default value null
            [SerializeField] private GameObject[] gameObjects;
#pragma warning restore CS0649 // Field 'Demo.GameObjectsGroup.gameObjects' is never assigned to, and will always have its default value null

            public void SetActive(bool enabled)
            {
                foreach(var g in gameObjects)
                {
                    g.SetActive(enabled);
                }
            }
        }
    }
}