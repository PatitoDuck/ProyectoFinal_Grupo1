using UnityEditor;
using UnityEngine.UIElements;
using System.IO;
using UnityEditor.UIElements;

namespace DS.Windows
{
    using Utilities;

    public class DSEditorWindow : EditorWindow
    {
        private DSGraphView graphView;
        private readonly string NombreArchivoPorDefecto = "NuevoArchivoDeDi�logo";
        private static TextField fileNameTextField;
        private Button saveButton;
        [MenuItem("Window/DS/Dialogue Graph")]
        public static void Open()
        {
            GetWindow<DSEditorWindow>("Gr�fica de los Di�logos");
        }

        private void OnEnable()
        {
            AddGraphView();
            AddToolbar();
            AddStyles();
        }
        #region A�adir elementos
        private void AddGraphView()
        {
            graphView = new DSGraphView(this);

            graphView.StretchToParentSize(); 

            rootVisualElement.Add(graphView);

        }

        private void AddToolbar()
        {
            Toolbar toolbar = new Toolbar();

            fileNameTextField = DSElementUtility.CreateTextField(NombreArchivoPorDefecto, "Nombre del Archivo:", callback=>
            {
                fileNameTextField.value = callback.newValue.RemoveWhitespaces().RemoveSpecialCharacters();
            });

            saveButton = DSElementUtility.CreateButton("Guardar", () => Save());

            Button loadButton = DSElementUtility.CreateButton("Cargar...",() => Load());
            Button clearButton = DSElementUtility.CreateButton("Limpiar todo", () => Clear());
            Button ResetButton = DSElementUtility.CreateButton("Reiniciar", () => ResetGraph());


            toolbar.Add(fileNameTextField);
            toolbar.Add(saveButton);
            toolbar.Add(loadButton);

            toolbar.Add(clearButton);
            toolbar.Add(ResetButton);


            toolbar.AddStyleSheets("DialogSystem/DSToolbarStyles.uss");
            rootVisualElement.Add(toolbar);
        }



        private void AddStyles()
        {
            rootVisualElement.AddStyleSheets("DialogSystem/DSVariables.uss");

        }
        #endregion

        #region Acciones de la barra de herramientas
        private void Save()
        {
            if(string.IsNullOrEmpty(fileNameTextField.value))
            {
                EditorUtility.DisplayDialog(
                    "Nombre de archivo inv�lido",
                    "El nombre del archivo no puede estar vac�o. Ingresa un nombre v�lido",
                    "Entendido"
                );

                return;
            }


            DSIOUtility.Initialize(graphView, fileNameTextField.value);
            DSIOUtility.Save();
        }

        private void Load()
        {
            string filePath = EditorUtility.OpenFilePanel("Cargar gr�ficas de di�logo","Assets/Editor/DialogueSystem/Graphs", "asset");
        
            if(string.IsNullOrEmpty(filePath))
            {
                return;
            }

            Clear();
            DSIOUtility.Initialize(graphView, Path.GetFileNameWithoutExtension(filePath));
            DSIOUtility.Load();
        }

        private void Clear()
        {
            graphView.ClearGraph();
        }

        private void ResetGraph()
        {
            Clear();

            UpdateFileName(NombreArchivoPorDefecto);

        }
        #endregion

        #region Utilidades
        public static void UpdateFileName(string newFileName)
        {
            fileNameTextField.value = newFileName;
        }

        public void EnableSaving()
        {
            saveButton.SetEnabled(true);
        }

        public void DisableSaving()
        {
            saveButton.SetEnabled(false);
        }


        #endregion
    }
}