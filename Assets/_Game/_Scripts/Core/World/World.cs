using System;
using System.Collections.Generic;
using _Game._Scripts.Core.Data;
using _Game._Scripts.Core.Data.ScriptableObjects;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace _Game._Scripts.Core.World
{
    public class World : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;

        private IWorldData _worldData;

        [Inject]
        public void Construct(IWorldData worldData)
        {
            _worldData = worldData;
        }

        private void Awake()
        {
            GenerateWorldData();
        }

        private void GenerateWorldData()
        {
            Dictionary<Vector2Int, BlockData> blocksWithData = new();
            
            foreach (var pos in tilemap.cellBounds.allPositionsWithin)
            {
                var tile = tilemap.GetTile(pos);
                if (tile == null)
                    continue;
                
                if (tile is RuleTileData ruleTileData)
                {
                    var position = new Vector2Int(pos.x, pos.y);
                    blocksWithData[position] = ruleTileData.BlockData;
                }
            }
            
            _worldData.GenerateBlocks(blocksWithData);
        }
    }
}
