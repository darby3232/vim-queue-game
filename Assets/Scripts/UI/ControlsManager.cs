using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsManager : MonoBehaviour
{

    public Image hImage;
    public Image jImage;
    public Image kImage;
    public Image lImage;

    public Sprite upArrow;
    public Sprite downArrow;
    public Sprite leftArrow;
    public Sprite rightArrow;

    public void UpdateImages(PlayerController.KeyMap[] km)
    {
        for(int i = 0; i < 4; i++)
        {
            if(km[i].key == KeyCode.H)
            {
                SetSprite(hImage, km[i]);
            }
            else if(km[i].key == KeyCode.J)
            {
                SetSprite(jImage, km[i]);
            }
            else if(km[i].key == KeyCode.K)
            {
                SetSprite(kImage, km[i]);
            }
            else if(km[i].key == KeyCode.L)
            {
                SetSprite(lImage, km[i]);
            }
        }
    }

    private void SetSprite(Image image, PlayerController.KeyMap km)
    {
        if(km.direction == "Up")
        {
            image.sprite = upArrow;
        }
        else if(km.direction == "Down")
        {
            image.sprite = downArrow;
        }
        else if(km.direction == "Left")
        {
            image.sprite = leftArrow;
        }
        else if(km.direction == "Right")
        {
            image.sprite = rightArrow;
        }
    }
}
