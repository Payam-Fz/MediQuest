using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] float animationSpeed = 15f;
    [SerializeField] int hairType;
    [SerializeField] int skinType;
    [SerializeField] int clothingType;

    public readonly int DIFFERENT_HAIR_TYPES = 2;
    public readonly int DIFFERENT_SKIN_TYPES = 3;
    public readonly int DIFFERENT_CLOTHING_TYPES = 2;

    private float timer;
    private float animationDelay;
    private Dictionary<string, Dictionary<string, Sprite[]>> sprites;
    private string previousDirection;
    private int previousMoveState;
    private int secondPreviousMoveState;
    private float horizontal;
    private float vertical;

    void Awake()
    {
        sprites = new Dictionary<string, Dictionary<string, Sprite[]>>();
        FillDictionary();
        previousDirection = "Front";
        previousMoveState = 0;
        secondPreviousMoveState = 0;
        horizontal = 0f;
        vertical = 0f;
        timer = 0f;
        animationDelay = 10f / animationSpeed;
        UpdateFrame();
    }

    public void setDirection(float horizontal, float vertical)
    {
        this.horizontal = horizontal;
        this.vertical = vertical;
    }

    public void setSpriteType(int hair, int skin, int clothing)
    {
        this.hairType = hair;
        this.skinType = skin;
        this.clothingType = clothing;
        sprites = new Dictionary<string, Dictionary<string, Sprite[]>>();
        FillDictionary();
    }


    private void FillDictionary()
    {
        sprites.Add("Outline", new Dictionary<string, Sprite[]>());
        LoadDirectionSprites("Outline");

        sprites.Add("Skin", new Dictionary<string, Sprite[]>());
        LoadDirectionSprites("Skin");

        sprites.Add("Hair", new Dictionary<string, Sprite[]>());
        LoadDirectionSprites("Hair");

        sprites.Add("Clothing", new Dictionary<string, Sprite[]>());
        LoadDirectionSprites("Clothing");
    }

    private void LoadDirectionSprites(string piece)
    {
        string type = "";
        switch (piece)
        {
            case "Hair":
                type += ("/" + hairType);
                break;
            case "Skin":
                type += ("/" + skinType);
                break;
            case "Clothing":
                type += ("/" + clothingType);
                break;
        }
        sprites[piece].Add("Front", Resources.LoadAll<Sprite>("Character/" + piece + type + "/Front"));
        sprites[piece].Add("RightFront", Resources.LoadAll<Sprite>("Character/" + piece + type + "/RightFront"));
        sprites[piece].Add("Right", Resources.LoadAll<Sprite>("Character/" + piece + type + "/Right"));
        sprites[piece].Add("RightBack", Resources.LoadAll<Sprite>("Character/" + piece + type + "/RightBack"));
        sprites[piece].Add("Back", Resources.LoadAll<Sprite>("Character/" + piece + type + "/Back"));

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= animationDelay)
        {
            timer = 0f;
            UpdateFrame();
        }
    }

    private void UpdateFrame()
    {
        string newDirection = DetermineDirection(horizontal, vertical);

        if (newDirection.Equals(previousDirection))
        {
            if (!newDirection.Equals("Standing"))
            {
                SetSprites(newDirection, NextMoveState());
            }
        }
        else
        {
            if (newDirection.Equals("Standing"))
            {
                SetSprites(previousDirection, 0);
            }
            else
            {
                SetSprites(newDirection, NextMoveState());
            }
        }

        previousDirection = newDirection;
    }

    private void SetSprites(string direction, int movingState)
    {
        bool flip = false;

        if (direction.Contains("Left"))
        {
            flip = true;
            direction = direction.Replace("Left", "Right");
        }

        for (int i = 0; i < 4; i++)
        {
            var piece = gameObject.transform.GetChild(i);
            string pieceName = piece.transform.name;

            if (pieceName.Equals("Hair"))
            {
                piece.GetComponent<SpriteRenderer>().sprite = sprites[pieceName][direction][0];
            } else
            {
                piece.GetComponent<SpriteRenderer>().sprite = sprites[pieceName][direction][movingState];
            }
            piece.GetComponent<SpriteRenderer>().flipX = flip;
        }
    }

    // Determines and returns the index of next moving sprite and updates the secondMoveState
    // MODIFIES: secondPreviousMoveState, previousMoveState
    private int NextMoveState()
    {
        int newMoveState = 0;
        switch (previousMoveState)
        {
            case 0:
                if (secondPreviousMoveState == 1)
                {
                    newMoveState = 2;
                }
                else
                {
                    newMoveState = 1;
                }
                break;
            case 1:
                secondPreviousMoveState = 1;
                break;
            case 2:
                secondPreviousMoveState = 2;
                break;
        }
        previousMoveState = newMoveState;
        return newMoveState;
    }

    private string DetermineDirection(float horizontal, float vertical)
    {
        string direction;
        if (horizontal < 0)
        {
            direction = "Left";
            if (vertical < 0)
            {
                direction += "Front";
            }
            else if (vertical > 0)
            {
                direction += "Back";
            }
        }
        else if (horizontal == 0)
        {
            if (vertical > 0)
            {
                direction = "Back";
            }
            else if (vertical < 0)
            {
                direction = "Front";
            }
            else
            {
                direction = "Standing";
            }
        }
        else
        {
            direction = "Right";
            if (vertical < 0)
            {
                direction += "Front";
            }
            else if (vertical > 0)
            {
                direction += "Back";
            }
        }
        return direction;
    }
}
