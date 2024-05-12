using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Image image;

    [SerializeField] Texture2D tex;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material material;

    // Start is called before the first frame update
    void Start()
    {
        tex = material.mainTexture as Texture2D;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 pos = collision.transform.position;
        RaycastHit hit;

        // Cubeの中心から衝突した地点へ向かってレイを飛ばす
        if (Physics.Raycast(pos, collision.contacts[0].point - pos, out hit, Mathf.Infinity))
        {
            Vector2 uv = hit.textureCoord;
            Color[] pix = tex.GetPixels(Mathf.FloorToInt(uv.x * tex.width), Mathf.FloorToInt(uv.y * tex.height), 1, 1);
            Debug.Log(pix[0].ToString());
            Debug.Log(pix[0]);
            Color a = pix[0];
        }

    }
}