using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class EmpezarDialogo : MonoBehaviour
{

    public NPCConversation npcDialogos;


    private void OnTriggerStay(Collider other)
    {
        //Para que se active solo si el jugador est� dentro del trigger y presiona un bot�n
        if(other.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E)) ConversationManager.Instance.StartConversation(npcDialogos);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //desactiva la conversaci�n autom�ticamente si el jugador se aleja
        ConversationManager.Instance.EndConversation();
    }

}
