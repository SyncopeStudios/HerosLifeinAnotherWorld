using System;
using BayatGames.SaveGameFree;
using Game.Scripts.Extra;
using UnityEngine;

namespace Game.Scripts
{
    public class CoinManager : Singelton<CoinManager>
    {

        [SerializeField] private float coinTest;
        public float coins { get; private set; }
        private const string COIN_KEY = "Coins";

        private void Start()
        {
            coins = SaveGame.Load(COIN_KEY, coinTest);
            SaveGame.Delete(COIN_KEY);
        }


        public void AddCoins(float amount)
        {
            coins += amount;
            SaveGame.Save(COIN_KEY,coins);
        }

        public void RemoveCoin(float amount)
        {
            if (coins>= amount)
            {
                coins -= amount;
                SaveGame.Save(COIN_KEY,coins);
            }
            
            
        }

    }
}