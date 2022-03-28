using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    Color materialColor = new Color(0.5f, 0.2f, 0.3f, 1.0f);
    bool[] colorChange = new bool[] { false, false, false };
    Vector3 position = new Vector3(3, 4, 3);
    Vector3 scale = Vector3.one * 1.3f;
    Material material;
    float colourChangeSpeed = 0.05f;
 

    void Start()
    {
        transform.position = position;
        transform.localScale = scale;
        
        material = Renderer.material;

        material.color = materialColor;
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        if (materialColor.b < 1.0f && !colorChange[0])
        {
            if (materialColor.g < 1.0f && !colorChange[1])
            {
                if (materialColor.r < 1.0f && !colorChange[2])
                {
                    materialColor.r += colourChangeSpeed;
                }
                else
                {
                    materialColor.g += colourChangeSpeed;
                    materialColor.r -= colourChangeSpeed;

                    colorChange[2] = true;

                    if (materialColor.r <= 0)
                    {
                        colorChange[2] = false;
                    }
                }
            }

            else
            {
                materialColor.b += colourChangeSpeed;
                materialColor.g -= colourChangeSpeed;

                colorChange[1] = true;

                if (materialColor.g <= 0)
                {
                    colorChange[1] = false;
                }
            }
        }

        else
        {
            materialColor.b -= colourChangeSpeed;

            colorChange[0] = true;

            if (materialColor.b <= 0)
            {
                colorChange[0] = false;
            }
        }

        material.color = materialColor;
    }
}
