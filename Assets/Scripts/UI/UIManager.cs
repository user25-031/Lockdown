using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI battery;
    [SerializeField] private Image healthBar;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private GameOverPopup gameOverPopup;
    private void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.AddListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
    }
    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
        Messenger.RemoveListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
    }
    private void OnPlayerDead()
    {
        gameOverPopup.Open();
        SetGameActive(false);
    }
    private void OnHealthChanged(float percentage)
    {
        UpdateHealth(percentage);
    }
    private void UpdateHealth(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
    }
    void Start()
    {
        Texture2D tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.white);
        tex.Apply();

        healthBar.sprite = Sprite.Create(tex, new Rect(0, 0, 1, 1), Vector2.one * 0.5f);

        healthBar.type = Image.Type.Filled;
        healthBar.fillMethod = Image.FillMethod.Horizontal;

        healthBar.fillAmount = 1f;
        healthBar.color = Color.green;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive())
        {
            SetGameActive(false);
            optionsPopup.Open();
        }
    }
    public void UpdateScore(int newScore)
    {
        battery.text = " Batteries: " +newScore.ToString();
    }
    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor
        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
        }
    }
}
