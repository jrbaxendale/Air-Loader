using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knife.HologramEffect
{
    [ExecuteAlways]
    public class MatrixProvider : MonoBehaviour
    {
        [SerializeField] private string propertyName = "_CustomMatrix";
#pragma warning disable CS0649 // Field 'MatrixProvider.targetRenderers' is never assigned to, and will always have its default value null
        [SerializeField] private Renderer[] targetRenderers;
#pragma warning restore CS0649 // Field 'MatrixProvider.targetRenderers' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'MatrixProvider.eliminateRootBoneMatrix' is never assigned to, and will always have its default value false
        [SerializeField] private bool eliminateRootBoneMatrix;
#pragma warning restore CS0649 // Field 'MatrixProvider.eliminateRootBoneMatrix' is never assigned to, and will always have its default value false

        private MaterialPropertyBlock materialPropertyBlock;

        private void OnEnable()
        {
            if (this == null)
                return;

            if (materialPropertyBlock == null)
                materialPropertyBlock = new MaterialPropertyBlock();

            if (targetRenderers != null)
            {
                foreach (var r in targetRenderers)
                {
                    if (r != null)
                    {
                        Matrix4x4 matrix = transform.localToWorldMatrix;

                        if(eliminateRootBoneMatrix)
                        {
                            SkinnedMeshRenderer skinnedMeshRenderer = r as SkinnedMeshRenderer;

                            if(skinnedMeshRenderer != null)
                            {
                                Transform rootBone = skinnedMeshRenderer.rootBone;

                                if(rootBone != null)
                                {
                                    matrix = rootBone.localToWorldMatrix * matrix;
                                }
                            }
                        }

                        r.GetPropertyBlock(materialPropertyBlock);
                        materialPropertyBlock.SetMatrix(propertyName, matrix);
                        r.SetPropertyBlock(materialPropertyBlock);
                    }
                }
            }
        }

        private void OnValidate()
        {
            OnEnable();
        }
    }
}