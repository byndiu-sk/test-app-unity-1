using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class GameScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;
    
    public async Task PlayCountdownAsync()
    {
        int count = 3;
        while (count > 0)
        {
            _countdownText.text = count.ToString();
            await Task.Delay(1000);  // equivalent to 'yield return new WaitForSeconds(1)'
            count--;
        }
        _countdownText.text = "START";
        StartCoroutine(DisableTextAfterDelay(1));
    }
    
    private IEnumerator DisableTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _countdownText.gameObject.SetActive(false); 
    }
}
