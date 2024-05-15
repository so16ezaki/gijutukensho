using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Image image;
    [SerializeField] GameObject obj;
    [SerializeField] Texture2D tex;
    [SerializeField] int areaSize = 30; // Adjust as needed

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float maxDistance = 1f;

        Ray ray = new Ray(transform.position, -transform.up * maxDistance);
        Debug.DrawRay(transform.position, -transform.up, Color.red);

        RaycastHit hit;


        // Cube�̒��S���牺������ray��L�΂�
        if (Physics.Raycast(ray, out hit, maxDistance))
        {

            obj = hit.collider.gameObject;
            tex = hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
            Vector2 uv = hit.textureCoord;

            

            // Calculate the average brightness
            float totalBrightness = 0f;
            int pixelCount = 0;

            for (int x = -areaSize / 2; x <= areaSize / 2; x++)
            {
                for (int y = -areaSize / 2; y <= areaSize / 2; y++)
                {
                    Color[] pixels = tex.GetPixels(Mathf.FloorToInt(uv.x * tex.width) + x, Mathf.FloorToInt(uv.y * tex.height) + y, 1, 1);
                    Color pixelColor = pixels[0];
                    float brightness;
                    Color.RGBToHSV(pixelColor, out _, out _, out brightness);
                    totalBrightness += brightness;
                    pixelCount++;
                }
            }

            float averageBrightness = totalBrightness / pixelCount;
            Debug.Log("Average Brightness: " + averageBrightness);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {




    }
}