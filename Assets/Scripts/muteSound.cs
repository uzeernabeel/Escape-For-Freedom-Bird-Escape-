using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteSound : MonoBehaviour {

    private bool isMute;

    public void Mute() {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
}
