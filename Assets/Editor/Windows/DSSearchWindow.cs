using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace DS.Windows
{
    using Elements;
    using Enumerations;
    public class DSSearchWindow : ScriptableObject, ISearchWindowProvider
    {

        private DSGraphView graphView;
        private Texture2D indentationIcon;
        public void Initialize(DSGraphView dSGraphView)
        {
            graphView = dSGraphView;

            indentationIcon = new Texture2D(1, 1);
            indentationIcon.SetPixel(0, 0, Color.clear);
            indentationIcon.Apply();
        }
        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            List<SearchTreeEntry> searchTreeEntries = new List<SearchTreeEntry>()
            {
                new SearchTreeGroupEntry(new GUIContent("Crear Elemento")),
                new SearchTreeGroupEntry(new GUIContent("Nodo de Di�logo"), 1),
                new SearchTreeEntry(new GUIContent("Opci�n simple", indentationIcon))
                {
                    level = 2,
                    userData = DSDialogueType.SingleChoice
                },
                new SearchTreeEntry(new GUIContent("Opci�n m�ltiple", indentationIcon))
                {
                    level = 2,
                    userData = DSDialogueType.MultipleChoice
                },

                new SearchTreeGroupEntry(new GUIContent("Grupo de Di�loos"),1),
                new SearchTreeEntry(new GUIContent("Grupo simple", indentationIcon))
                {
                    level = 2,
                    userData = new Group()
                }
            };

            return searchTreeEntries;
        }

        public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
        {
            Vector2 localMousePosition = graphView.GetLocalMousePosition(context.screenMousePosition, true);

            switch(SearchTreeEntry.userData)
            {
                case DSDialogueType.SingleChoice:
                    {
                        DSSingleChoiceNode singleChoiceNode = (DSSingleChoiceNode)graphView.CreateNode("NombreDelDialogo", DSDialogueType.SingleChoice, localMousePosition);  ;
                        graphView.AddElement(singleChoiceNode);
                        return true;
                    }
                case DSDialogueType.MultipleChoice:
                    {
                        DSMultipleChoiceNode multipleChoiceNode = (DSMultipleChoiceNode)graphView.CreateNode("NombreDelDialogo", DSDialogueType.MultipleChoice, localMousePosition);
                        graphView.AddElement(multipleChoiceNode);
                        return true;
                    }
                case Group _:
                    {
                        graphView.CreateGroup("GrupoDeDi�logos", localMousePosition);

                        return true;
                    }
                default:
                    {
                        return false;
                    }


            }
        }
    }
}
