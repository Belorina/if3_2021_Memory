using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public int row = 3;
    public int col = 4;

    public float gapRow = 1.5f;     // f pour declarer un float 
    public float gapCol = 1.5f;

    [Range(0f, 5f)]        // /!\ variable mis en slider dans inspecteur (metre juste au dessus du variable)
    public float timeBeforeReset = 1f;
    private bool resetOnGoing = false;


    public GameObject itemPrefab;

    public Material[] materials;
    public Material defaultMaterial;

    public ItemBehavior[] items;        // tableau 

    public List<int> selected = new List<int>();     // declare une liste
    public List<int> matches = new List<int>();

    private Dictionary<int, Material> itemMaterial = new Dictionary<int, Material>();     // <key, value>  & instantiate 
    public UnityEvent whenPlayerWins;

    // Start is called before the first frame update
    void Start()
    {
        items = new ItemBehavior[row * col];    // creation tableau et grandeur 
        int index = 0;

        for (int x = 0; x < col; x++)           // il faut tenir en compte le gap plustard
        {
            for (int z = 0; z < row; z++)
            {
                Vector3 position = new Vector3(x * gapCol, 0, z * gapRow);       // etablir la position ( Vector3(x, y, z) )
                GameObject item = Instantiate(itemPrefab, position, Quaternion.identity);

                item.GetComponent<Renderer>().material = defaultMaterial;

                items[index] = item.GetComponent<ItemBehavior>();       // avoir ItemBehavior sur le prefab sinon null reference exception

                items[index].id = index;            // .id = atteindre l'id de l'object  -- stockuer les object 
                items[index].manager = this;        // this = l'instance en cours du script / le LevelManager qui est entrain de jouer 

                index++;
            }
        }

        GiveMaterials();    // attribuer une couleur a un object
    }

    private void GiveMaterials()
    {
        List<int> possibilities = new List<int>();        // creation list d int, "possibilites"  
        for (int i = 0; i < row * col; i++)     // i < rom * col = nombre d object
        {
            possibilities.Add(i);   // ajouter des chiffre de 0 jusqua nombre d object -1 
        }

        for (int i = 0; i < materials.Length; i++)      // /!\ on n'utilise pas foreach car declare en momoire une variable, ca va alourdir le pc
        {
            if (possibilities.Count < 2) break; // break = sors de la boucle en cours  -- verifie si il y a assez de possibilites 

            int idPos = Random.Range(0, possibilities.Count);    // premier inculive dernier exclusive
            int id1 = possibilities[idPos];
            possibilities.RemoveAt(idPos);

            idPos = Random.Range(0, possibilities.Count);       // on ne redeclare pas idPos car deja fait
            int id2 = possibilities[idPos];
            possibilities.RemoveAt(idPos);

            itemMaterial.Add(id1, materials[i]);
            itemMaterial.Add(id2, materials[i]);                // deux identifiant unique, qui ne reapparait plus plustard, et donner le meme material aux deux

            // // visuel code 
            // items[id1].GetComponent<Renderer>().material = materials[i];             // renderer = composant de rendue 
            // items[id2].GetComponent<Renderer>().material = materials[i];             // renderer = composant de rendue 

        }
    }

    private IEnumerator ResetMaterials(int id1, int id2)
    {
        resetOnGoing = true;
        yield return new WaitForSeconds(timeBeforeReset);                    // yield est un retour, mais recommence (a l apelle) a partir du retour qu il a fait. 

        ResetMaterial(id1);
        ResetMaterial(id2);
        resetOnGoing = false;
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(timeBeforeReset);
        whenPlayerWins?.Invoke();               // /!\ !! 
    }

    public void RevealMaterial(int id)
    {
        if (resetOnGoing == false && !selected.Contains(id) && !matches.Contains(id))     // si on a selectioner 2  object && si l'id n'est pas dans la list "selected" && matches nas pas l identifiant
        {
            selected.Add(id);   // rajouter l id selectione
            Material material = itemMaterial[id];
            items[id].GetComponent<Renderer>().material = material;
        }
    }

    private void ResetMaterial(int id)
    {
        items[id].GetComponent<Renderer>().material = defaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected.Count == 2)
        {
            if (itemMaterial[selected[0]] == itemMaterial[selected[1]])         // si premier obj selectioner et deux obj selection sont egal il y a un match! 
            {
                matches.Add(selected[0]);
                matches.Add(selected[1]);

                if (matches.Count >= row * col)
                {
                    StartCoroutine(Win()); 
                }

            }
            else
            {
                StartCoroutine(ResetMaterials(selected[0], selected[1]));
            }
            selected.Clear();
        }
    }
}
