using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoChange : MonoBehaviour
{
    public Sprite[] bulletImages = new Sprite[5];
    public Sprite currentImage;

    public void changeImage(int imageIndex)
    {
        if(imageIndex < 6)
        {
            currentImage = bulletImages[imageIndex];
            this.gameObject.GetComponent<Image>().sprite = currentImage;
        }

    }
}
