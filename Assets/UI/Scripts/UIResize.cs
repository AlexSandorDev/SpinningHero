using UnityEngine;

[ExecuteInEditMode]
public class UIResize : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] float leftPercent = 0.5f;

    [SerializeField] RectTransform leftRect;
    [SerializeField] RectTransform rightRect;
    [SerializeField] RectTransform parentRect;

    // Update is called once per frame
    void Update()
    {
        //set the size of the redRect as a percentage of the parent
        leftRect.sizeDelta = new Vector2(parentRect.rect.width * leftPercent, leftRect.sizeDelta.y);

        //calculate the percentage size of green as 1 - redPercent
        // i.e. Red = 90% => Green = 10%
        float greenPercent = 1 - leftPercent;

        //set the size of the greenRect to our calculated percent
        rightRect.sizeDelta = new Vector2(parentRect.rect.width * greenPercent, rightRect.sizeDelta.y);
    }
}