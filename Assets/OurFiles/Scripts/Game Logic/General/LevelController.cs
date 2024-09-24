using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Logic.Progression
{
    public class LevelController : MonoBehaviour
    {
        // Текущий уровень игрока
        private int _currentLevel = 1;
        // Текущее количество опыта
        private int _currentXP = 0;
        // Начисляемое количество опыта(для теста 10)
        private int _earnedXP = 10;
        // Требуемое количество опыта на каждый уровень
        public List<int> levelThreshhold;

        public void EarnXP()
        {
                /*if (_currentXP + _earnedXP >= levelThreshhold[_currentLevel-1]){
                    // Не знаю, как мы хотим: оставлять опыт или обнулять при левелапе, но это можно исправить быстро
                    _currentXP = _currentXP + _earnedXP - levelThreshhold[_currentLevel-1];
                    _currentLevel++;
                }
                else
                {
                    _currentXP += _earnedXP;
                }*/
        }       
    }
}