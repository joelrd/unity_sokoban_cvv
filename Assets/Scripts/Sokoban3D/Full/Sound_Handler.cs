using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UnedSokoban {}

public enum SoundType
{
    none = -1,
    box = 1,
};
// Declaración de la clase
public class Sound_Handler : MonoBehaviour {
    public static Sound_Handler instance;
    public AudioSource speaker1;
    public AudioSource speaker2;
    public AudioSource speaker3;
    // Arreglo de archivos de audio
    public AudioClip[] sounds;
    // Inicialización del objeto singleton
    void Awake () {
        if(instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Método público para reproducir sonido
    public void playsound(int indexOfSound) {
        if(speaker1 != null && !speaker1.isPlaying) {
            speaker1.PlayOneShot(sounds[indexOfSound]);
        }
        else if(speaker2 != null && !speaker2.isPlaying) {
            speaker2.PlayOneShot(sounds[indexOfSound]);
        }
        else if(speaker3 != null && !speaker3.isPlaying) {
            speaker3.PlayOneShot(sounds[indexOfSound]);
        }
    }
}
