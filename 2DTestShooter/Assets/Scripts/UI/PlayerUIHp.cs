using UnityEngine;
using TMPro;

public class PlayerUIHp : MonoBehaviour, IHpUI
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private string _prefix = "Health";
    
    public void RendererHp(int hp) => _hpText.text = _prefix + " " + hp.ToString();
    

}
