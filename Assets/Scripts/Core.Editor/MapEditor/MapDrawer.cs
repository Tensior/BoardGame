using System;
using System.Collections.Generic;
using System.Linq;
using Core.Map;
using UnityEditor;
using UnityEngine;

namespace Core.Editor.MapEditor
{
    public class MapDrawer : EditorWindow
    {
        private static List<Node> _originalNodes = new();
        private Node _newNode;
        private DrawMode _drawMode = DrawMode.None;

        [MenuItem("Tools/MapDrawer")]
        private static void ShowWindow()
        {
            var window = GetWindow<MapDrawer>();
            window.titleContent = new GUIContent("Map Drawer");
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Toggle(_drawMode == DrawMode.AddNode, "AddNode"))
            {
                _drawMode = DrawMode.AddNode;
                GUILayout.Label($"Adding node to {_originalNodes?.Aggregate("", (s, node) => s + node.name + ", ")}");
            }
            else
            {
                _drawMode = DrawMode.None;
            }
        }

        private void OnEnable()
        {
            SceneView.duringSceneGui += OnSceneGUI;
            Selection.selectionChanged += OnSelectionChanged;
        }

        private void OnDisable()
        { 
            SceneView.duringSceneGui -= OnSceneGUI;
            Selection.selectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged()
        {
            _originalNodes = Selection.objects
                                      .Select(obj => (obj as GameObject)?.GetComponent<Node>())
                                      .Where(node => node != null)
                                      .ToList();
            Repaint();
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            if (_originalNodes.Count == 0)
            {
                return;
            }
            
            switch (_drawMode)
            {
                case DrawMode.AddNode:
                    if (Event.current.button == 0 && Event.current.isMouse && Event.current.type == EventType.MouseDown)
                    {
                        var ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

                        if (Physics.Raycast(ray, out var hit, 1000.0f))
                        {
                            Undo.SetCurrentGroupName("Create node");
                            Undo.RecordObjects(_originalNodes.ToArray(), $"Adding new node");

                            var originalTransform = _originalNodes.First().transform;
                            var newNodePosition = new Vector3(hit.point.x, originalTransform.position.y, hit.point.z);
                            _newNode = Instantiate(_originalNodes.First(), newNodePosition, originalTransform.rotation, originalTransform.parent);
                            _newNode.NextNodes.Clear();

                            foreach (var originalNode in _originalNodes)
                            {
                                originalNode.NextNodes.Add(_newNode);
                            }
                            
                            Undo.RegisterCreatedObjectUndo(_newNode.gameObject, $"Created new node {_newNode.name}");
                            Undo.CollapseUndoOperations(Undo.GetCurrentGroup());
                        }
                    }

                    if (Event.current.button == 0 && Event.current.isMouse && Event.current.type is EventType.MouseUp or EventType.MouseDrag)
                    {
                        //Doesn't work
                        Selection.activeGameObject = _newNode.gameObject;
                    }
                    break;
                case DrawMode.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private enum DrawMode
        {
            None,
            AddNode
        }
    }
}