using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    public Color[] colors = new Color[]
  {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow,
        Color.cyan,
        Color.magenta,
        Color.gray,
        Color.white,
        Color.black
  };
    private void Start()
    {
        // choose a random color from the array
        Color randomColor = colors[Random.Range(0, colors.Length)];

        // set the object's color to the random color
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = randomColor;
        }
    }
}
