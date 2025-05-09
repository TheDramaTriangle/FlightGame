

/*
    Create game events in this file. They can be any kind of struct 
    with any kinds of data. 
*/

namespace GameEvent
{

    /* ------- PLANE EVENTS ------- */ 
    public struct PlaneShoot {} 

    public struct PlaneCrash {} 

    /* ------- GAME STATE EVENTS ------ */ 
    public struct GameStart {} 

    /* ------- ENEMY EVENTS ------- */ 
    public struct EnemyDied 
    {
        public int EnemiesRemaining {get; set;}
        public EnemyDied(int num)
        {
            EnemiesRemaining = num; 
        }
    }
    public struct EnemySpawned 
    {
        public int EnemiesRemaining {get; set;}
        public EnemySpawned(int num)
        {
            EnemiesRemaining = num; 
        }
    }
    public struct AllEnemiesDead {}

    /* ----- DEFENSE EVENTS ------ */ 
    public struct DefenseDestroyed {} 
    public struct DefenseDamaged
    {
        public int HealthRemaining {get; set;}
        public DefenseDamaged(int num)
        {
            HealthRemaining = num; 
        }
    }
    public struct DefenseSpawned
    {
        public int Health{get; set;}
        public DefenseSpawned(int num)
        {
            Health = num; 
        }
    }


}