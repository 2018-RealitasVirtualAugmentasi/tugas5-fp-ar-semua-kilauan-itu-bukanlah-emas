using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{

    public class dataTarget : MonoBehaviour
    {

        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform ButtonAction;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
            //add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

                //Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                TextTargetName.GetComponent<Text>().text = name;
                ButtonAction.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);
                
                if (name == "Kubus")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/kubus"); });
                    TextDescription.GetComponent<Text>().text = "Kubus adalah bangun ruang tiga dimensi yang dibatasi oleh enam bidang sisi yang kongruen berbentuk bujur sangkar. Kubus memiliki 6 sisi, 12 rusuk dan 8 titik sudut. Kubus juga disebut bidang enam beraturan, selain itu juga merupakan bentuk khusus dalam prisma segiempat.";
                }
                
                if (name == "Balok")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/balok"); });
                    TextDescription.GetComponent<Text>().text = "Balok adalah bangun ruang tiga dimensi yang dibentuk oleh tiga pasang persegi atau persegi panjang, dengan paling tidak satu pasang di antaranya berukuran berbeda. Balok memiliki 6 sisi, 12 rusuk dan 8 titik sudut. Balok yang dibentuk oleh enam persegi sama dan sebangun disebut sebagai kubus.";
                }
                if (name == "Tabung")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/tabung"); });
                    TextDescription.GetComponent<Text>().text = "Dalam geometri, tabung atau silinder adalah bangun ruang tiga dimensi yang dibentuk oleh dua buah lingkaran identik yang sejajar dan sebuah persegi panjang yang mengelilingi kedua lingkaran tersebut. Tabung memiliki 3 sisi dan 2 rusuk.";
                }
                if (name == "Kerucut")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/kerucut"); });
                    TextDescription.GetComponent<Text>().text = "Dalam geometri, kerucut adalah sebuah limas istimewa yang beralas lingkaran. Kerucut memiliki 2 sisi dan 1 rusuk. Sisi tegak kerucut tidak berupa segitiga tapi berupa bidang miring yang disebut selimut kerucut.";
                }
                if (name == "Limas")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/limas"); });
                    TextDescription.GetComponent<Text>().text = "Dalam geometri, limas adalah bangun ruang tiga dimensi yang dibatasi oleh alas berbentuk segi-n dan sisi-sisi tegak berbentuk segitiga. Limas memiliki n + 1 sisi, 2n rusuk dan n + 1 titik sudut. ... Limas dengan alas berupa persegi disebut juga piramida.";
                }
                if (name == "Prisma")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/prisma"); });
                    TextDescription.GetComponent<Text>().text = "Dalam geometri, prisma adalah bangun ruang tiga dimensi yang dibatasi oleh alas dan tutup identik berbentuk segi-n dan sisi-sisi tegak berbentuk persegi atau persegi panjang. Dengan kata lain prisma adalah bangun ruang yang mempunyai penampang melintang yang selalu sama dalam bentuk dan ukuran.";
                }
                if (name == "Bola")
                {
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/bola"); });
                    TextDescription.GetComponent<Text>().text = "Dalam geometri, bola adalah bangun ruang tiga dimensi yang dibentuk oleh tak hingga lingkaran berjari-jari sama panjang dan berpusat pada satu titik yang sama. Bola hanya memiliki 1 sisi.";
                }
            }
        }

        //function to play sound
        void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }

    }
}