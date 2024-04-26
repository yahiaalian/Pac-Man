using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghosts[] ghosts;

    public PacMan pacman;

    public Transform pellets;

    public int GhostMultiplier { get; private set; } = 1;
    public int score {  get; private set; }
    public int lives { get; private set;}

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (this.lives <= 0 && Input.anyKeyDown)
        {
            NewGame();
        }
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        foreach(Transform pellet in this.pellets)
        {
            pellet.gameObject.SetActive(true);
        }
        ResetState();
    }
    private void ResetState()
    {
        ResetGhostMultiplier();
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }
        this.pacman.gameObject.SetActive(true);
        
    }

    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }
        this.pacman.gameObject.SetActive(false);
    }
    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    public void GhostEaten(Ghosts ghost)
    {
        SetScore(this.score + (ghost.points * this.GhostMultiplier));
        this.GhostMultiplier++;
    }
    public void PacManEaten(PacMan Pacman)
    {
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        if (this.lives > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        }
        else
        {
            GameOver();
        }

    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        SetScore(this.score + pellet.points);
        if(!HasRemainingPellets())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    } 
    public void PowerPelletEaten(PowerPellet pellet)
    {
        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
        
    }
    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in this.pellets)
        {
            if(pellet.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }
    private void ResetGhostMultiplier()
    {
        this.GhostMultiplier = 1;
    }
}

