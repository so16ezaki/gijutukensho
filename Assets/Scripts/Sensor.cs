using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Image image;

    [SerializeField] Texture2D tex;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        int maxDistance = 2;

        Ray ray = new Ray(transform.position,Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * maxDistance, Color.red);

        RaycastHit hit;
        
        // CubeÇÃíÜêSÇ©ÇÁâ∫ï˚å¸Ç÷rayÇêLÇŒÇ∑
        if (Physics.Raycast(transform.position, Vector3.down, out hit,maxDistance))
        {
            tex = hit.collider.gameObject.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
            Vector2 uv = hit.textureCoord;
            Color[] pix = tex.GetPixels(Mathf.FloorToInt(uv.x * tex.width), Mathf.FloorToInt(uv.y * tex.height), 1, 1);
            //Debug.Log(pix[0].ToString());
            //Debug.Log(pix[0]);
            Color a = pix[0];

            float h, s, v;
            Color.RGBToHSV(a, out h, out s, out v);
            //Debug.Log("h" + h + "s" + s + "v" + v);
            Debug.Log("ñæìx:" + v);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       

        

    }
}