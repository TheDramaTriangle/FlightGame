

/*
    Create game events in this file. They can be any kind of struct 
    with any kinds of data. 
*/

namespace GameEvent
{

    /* ------- PLANE EVENTS ------- */
    public struct PlaneShoot { }

    public struct PlaneCrash { }

    /* ------- GAME STATE EVENTS ------ */
    public struct GameStart { }

    public struct Explosion {}

    public struct ExitGame {} 

    /* ------- ENEMY EVENTS ------- */
    public struct EnemyDied
    {
        public int EnemiesRemaining { get; set; }
        public EnemyDied(int num)
        {
            EnemiesRemaining = num;
        }
    }
    public struct EnemySpawned
    {
        public int EnemiesRemaining { get; set; }
        public EnemySpawned(int num)
        {
            EnemiesRemaining = num;
        }
    }
    public struct AllEnemiesDead { }

    /* ----- DEFENSE EVENTS ------ */
    public struct DefenseDestroyed { }
    public struct DefenseDamaged
    {
        public float HealthPercentage { get; set; }
        public string Name { get; set; }
        public DefenseDamaged(float healthPercentage, string name)
        {
            HealthPercentage = healthPercentage;
            Name = name; 
        }
    }
    public struct DefenseSpawned
    {
        public string Name { get; set; }
        public DefenseSpawned(string name)
        {
            Name = name; 
        }
    }

    /* ----- SCORE EVENTS ------ */
    public struct ScoreChanged
    {
        public int NewScore { get; set; }

        public ScoreChanged(int newScore)
        {
            NewScore = newScore;
        }
    }

    /* ----- Player Damaged ------ */
    public struct PlayerDamaged
    {
        public int Health { get; set; }

        public PlayerDamaged(int NewHealth)
        {
            Health = NewHealth;
        }
    }

}
