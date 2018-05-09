using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ImageDownloader : MonoBehaviour {

    public string wwwS;
    [SerializeField] Sprite defaultImg;

    private void OnEnable()
    {
        GetComponent<Image>().overrideSprite = defaultImg;
        StartCoroutine(ShowImage());
    }

    IEnumerator ShowImage () {
		if(File.Exists(Application.persistentDataPath + gameObject.name + ".jpg")){
			print("Loading from the device");
			byte[] byteArray = File.ReadAllBytes(Application.persistentDataPath + gameObject.name + ".jpg");
			Texture2D texture = new Texture2D(8,8);
			texture.LoadImage(byteArray);
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
            this.GetComponent<Image>().overrideSprite = newSprite;
        }
		else {
			print("Downloading from the web");
			WWW www = new WWW(wwwS);
			yield return www;
			Texture2D texture = www.texture;
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
            this.GetComponent<Image>().overrideSprite = newSprite;
			byte[] bytes = texture.EncodeToJPG();
			File.WriteAllBytes(Application.persistentDataPath + gameObject.name + ".jpg", bytes);
		}
	}

}
