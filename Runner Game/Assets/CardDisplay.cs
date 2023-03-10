using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card card;

    public Text nameText;
    public Text statText;

    public Image artworkImage;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        statText.text = card.stat;

        artworkImage.sprite = card.artwork;
    }

}
