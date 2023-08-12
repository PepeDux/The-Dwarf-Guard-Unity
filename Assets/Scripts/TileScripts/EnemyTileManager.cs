using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TreeEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.ParticleSystem;

public class EnemyTileManager : MonoBehaviour
{
    private List<Vector3Int> pathToTarget = new List<Vector3Int>(); //Путь к цели
    private List<Node> checkedNodes = new List<Node>(); //Проверенные ноды
    private List<Node> freeNodes = new List<Node>(); //Свободные ноды
    private List<Node> waitingNodes = new List<Node>(); //Ожидающие ноды

    public GameObject target; //Цель
    public bool finishTurn;


    public void Start()
    {
        finishTurn = true;
        target = GetComponent<Enemy>().player;
    }

    public void EnemyMove()
    {
        if (GetComponent<Enemy>().movePoint >= GetComponent<Enemy>().moveCost)
        {
            pathToTarget.Clear();
            pathToTarget = GetPath(target.GetComponent<Player>().coordinate);

            if (pathToTarget.Count > 1)
            {
                pathToTarget.RemoveAt(0);
                GetComponent<Enemy>().coordinate = pathToTarget[pathToTarget.Count - 1];
                GetComponent<Enemy>().UpdateCoordinate();
                GetComponent<Enemy>().movePoint -= 1;
            }
        }



        finishTurn = true;
    }



    public void Turn()
    {
        while(GetComponent<Enemy>().movePoint >= GetComponent<Enemy>().moveCost)
        {
            int startPoints = GetComponent<Enemy>().movePoint;

            EnemyMove();

            if(startPoints == GetComponent<Enemy>().movePoint)
            {
                break;
            }
        }







        while (GetComponent<Enemy>().actionPoints >= GetComponent<Enemy>().meleeAttackCost || GetComponent<Enemy>().actionPoints >= GetComponent<Enemy>().rangeAttackCost)
        {
            int startPoints = GetComponent<Enemy>().actionPoints;

            GetComponent<AttackScript>().CalculationAttack(target.GetComponent<MainObject>());

            if (startPoints == GetComponent<Enemy>().actionPoints)
            {
                break;
            }
        }

    }
    public List<Vector3Int> GetPath(Vector3Int target)
    {
        checkedNodes.Clear(); //Проверенные ноды
        freeNodes.Clear(); //Свободные ноды
        waitingNodes.Clear(); //Ожидающие ноды

        Vector3Int startPosition = GetComponent<Enemy>().coordinate;
        Vector3Int targetPosition = target;

        if (startPosition == targetPosition)
        {
            return pathToTarget;
        }

        Node startNode = new Node(0, startPosition, targetPosition, null); //Создаем новую ноду соответствующую стартовой позиции
        checkedNodes.Add(startNode); //Добавляем в список проверенных нод стартовую ноду
        waitingNodes.AddRange(GetNeighbourNodes(startNode)); //Вычисляем соседей стартовой ноды

        while (waitingNodes.Count > 0)
        {
            Node nodeToCheck = waitingNodes.Where(x => x.F == waitingNodes.Min(y => y.F)).FirstOrDefault();

            //Если нода для проверки является целевой то возвращает значение для начала отсчета поиска пути
            if (nodeToCheck.Position == targetPosition)
            {
                return CalculatePathFromNode(nodeToCheck);
            }

            bool walkable = true;

            //Проверяем ноду на проходимость из списка непроходимых нод
            foreach(var cell in TileManager.impassableCells)
            {
                if(cell == nodeToCheck.Position)
                {
                    walkable = false;
                }
            }

            //Если нода не проходима то...
            if (walkable == false)
            {
                waitingNodes.Remove(nodeToCheck); //Удаляет текущую проверяемую ноду из списка ожидающих проверку
                checkedNodes.Add(nodeToCheck); //Добавляет текущую проверяемую ноду в список проверенных нод
            }
            //Если нода проходима то...
            else if (walkable == true)
            {
                waitingNodes.Remove(nodeToCheck); //Удаляет текущую ноду из списка ожидающих проверку

                if (!checkedNodes.Where(x => x.Position == nodeToCheck.Position).Any())
                {
                    checkedNodes.Add(nodeToCheck);
                    waitingNodes.AddRange(GetNeighbourNodes(nodeToCheck));
                }
            }
        }

        freeNodes = checkedNodes;

        return pathToTarget;
    }

    public List<Vector3Int> CalculatePathFromNode(Node node)
    {
        var path = new List<Vector3Int>();
        path.Clear();

        Node currentNode = node;

        while (currentNode.PreviousNode != null)
        {
            path.Add(new Vector3Int(currentNode.Position.x, currentNode.Position.y, currentNode.Position.z = 0));
            currentNode = currentNode.PreviousNode;
        }

        return path;
    }

    List<Node> GetNeighbourNodes(Node node)
    {
        var Neighbours = new List<Node>();
        Neighbours.Clear();

        if(GetComponent<Enemy>().lineMove == true)
        {
            Neighbours.Add(new Node(node.G + 1, new Vector3Int(
                node.Position.x, node.Position.y + 1, node.Position.z = 0),
                 node.TargetPosition,
                 node));

            Neighbours.Add(new Node(node.G + 1, new Vector3Int(
                 node.Position.x, node.Position.y - 1, node.Position.z = 0),
                 node.TargetPosition,
                 node));

            Neighbours.Add(new Node(node.G + 1, new Vector3Int(
                 node.Position.x + 1, node.Position.y, node.Position.z = 0),
                 node.TargetPosition,
                 node));

            Neighbours.Add(new Node(node.G + 1, new Vector3Int(
                 node.Position.x - 1, node.Position.y, node.Position.z = 0),
                 node.TargetPosition,
                 node));
        }

        if(GetComponent<Enemy>().diagonalMove == true)
        {
            Neighbours.Add(new Node(node.G + 1.4f, new Vector3Int(
                  node.Position.x + 1, node.Position.y + 1, node.Position.z = 0),
                 node.TargetPosition,
                 node));

            Neighbours.Add(new Node(node.G + 1.4f, new Vector3Int(
                 node.Position.x + 1, node.Position.y - 1, node.Position.z = 0),
                 node.TargetPosition,
                 node));

            Neighbours.Add(new Node(node.G + 1.4f, new Vector3Int(
                 node.Position.x - 1, node.Position.y - 1, node.Position.z = 0),
                 node.TargetPosition,
                 node));

            Neighbours.Add(new Node(node.G + 1.4f, new Vector3Int(
                 node.Position.x - 1, node.Position.y - 1, node.Position.z = 0),
                 node.TargetPosition,
                 node));
        }

        return Neighbours;
    }

    public class Node
    {
        public Vector3Int Position; //Позиция ноды
        public Vector3Int TargetPosition; //Позиция цели
        public Node PreviousNode; //Ссылка на предыдущую ноду

        public float F; // F=G+H
        public float G; // расстояние от старта до ноды
        public float H; // расстояние от ноды до цели

        public Node(float g, Vector3Int nodePosition, Vector3Int targetPosition, Node previousNode)
        {
            Position = nodePosition;
            TargetPosition = targetPosition;
            PreviousNode = previousNode;

            G = g;
            H = Mathf.Abs(targetPosition.x - Position.x) + Mathf.Abs(targetPosition.y - Position.y);
            F = G + H;
        }
    }



    
}
