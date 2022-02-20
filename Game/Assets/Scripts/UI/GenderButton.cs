using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class GenderButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
private bool buttonPressed;
public Gender genderValue;
private CharacterInfo[] charInfo;


void Start() {
    charInfo = Resources.LoadAll<CharacterInfo>("Data/Character/Player");
}
 
public void OnPointerDown(PointerEventData eventData){
    buttonPressed = true;
    charInfo[0].gender = genderValue;

}
 
public void OnPointerUp(PointerEventData eventData){
    buttonPressed = false;
}
}