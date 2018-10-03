using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public ActorController[] players;
    [SerializeField]
    private int CantidadEnemigos;
    [SerializeField]
    private AIController enemigoBase;
    [SerializeField]
    private GameObject[] spawnpoints;
    [SerializeField]
    private Text tiempoText;
    [SerializeField]
    private Text ganadorTexto;

    private GameObject ganador;

    public GameObject lastTaggedplayer;
    [SerializeField]
    private float gameTime = 25F;
    

    public float CurrentGameTime { get; private set; }

    // Use this for initialization
    private IEnumerator Start()
    {
        if(CantidadEnemigos < 2)
        {
            CantidadEnemigos = 2;
        }

        if(CantidadEnemigos >= 4)
        {
            CantidadEnemigos = 4;
        }

        for (int i = 0; i < CantidadEnemigos; i++)
        {
            Instantiate(enemigoBase, spawnpoints[Random.Range(0, spawnpoints.Length - 1)].transform.position + new Vector3(Random.Range(-4f,4f),0f,0f), transform.rotation);
        }
        
        CurrentGameTime = gameTime;

        // Sets the first random tagged player
        players = FindObjectsOfType<ActorController>();

        yield return new WaitForSeconds(0.5F);

        players[Random.Range(0, players.Length)].onActorTagged(true);
    }

    private void Update()
    {
        CurrentGameTime -= Time.deltaTime;
        tiempoText.text = CurrentGameTime.ToString("F2");

        if (CurrentGameTime <= 0F)
        {
            CurrentGameTime = 0f;
            for (int i = 0; i < players.Length; i++)
            {
                players[i].canMove = false;
            }

            int puntuacionActual = 10;

            for (int i = 0; i < players.Length; i++)
            {
                if(players[i].puntuacion < puntuacionActual)
                {
                    puntuacionActual = players[i].puntuacion;
                    ganador = players[i].gameObject;
                }
            }

            ganadorTexto.text = "Ganador: " + ganador.name.ToString();
            ganadorTexto.gameObject.SetActive(true);   

        }
    }

    public void GetLastTaggedPlayer(GameObject last)
    {
        lastTaggedplayer = last;
    }
}