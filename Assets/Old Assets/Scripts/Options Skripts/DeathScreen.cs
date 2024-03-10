using UnityEngine;
public class DeathScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup deathscreen;

    public void Toogle(bool isActive) 
    {
        this.deathscreen.alpha = isActive? 1 : 0;
        this.deathscreen.interactable = isActive;
        this.deathscreen.blocksRaycasts = isActive;
    }

  
}
