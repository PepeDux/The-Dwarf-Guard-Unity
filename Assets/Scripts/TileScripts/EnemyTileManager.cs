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
    private List<Vector3Int> pathToTarget = new List<Vector3Int>(); //���� � ����
    private List<Node> checkedNodes = new List<Node>(); //����������� ����
    private List<Node> freeNodes = new List<Node>(); //��������� ����
    private List<Node> waitingNodes = new List<Node>(); //��������� ����

    public GameObject target; //����
    private GameObject tileManager;
    public bool finishTurn;


    public void Start()
    {
        finishTurn = true;
        target = GetComponent<Enemy>().player;
        tileManager = GameObject.Find("TileManager");
    }

    public void EnemyMove()
    {
        if (GetComponent<Enemy>().movePoint > 0)
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
            else
            {
                //break;
            }




        }

        finishTurn = true;
    }



    public void Turn()
    {
        tileManager.GetComponent<TileManager>().TileGameObjectUpdatePosition();

        EnemyMove();


        while (GetComponent<Enemy>().actionPoints > 0)
        {
            int startActionPoints = GetComponent<Enemy>().actionPoints;

            if (GetComponent<Enemy>().actionPoints > 0)
            {
                GetComponent<EnemyMeleeAttack>().Attack(GetComponent<Enemy>().coordinate + Vector3Int.up);
                GetComponent<EnemyMeleeAttack>().Attack(GetComponent<Enemy>().coordinate + Vector3Int.down);
                GetComponent<EnemyMeleeAttack>().Attack(GetComponent<Enemy>().coordinate + Vector3Int.left);
                GetComponent<EnemyMeleeAttack>().Attack(GetComponent<Enemy>().coordinate + Vector3Int.right);
            }

            if(startActionPoints == GetComponent<Enemy>().actionPoints)
            {
                break;
            }
        }
    }
    public List<Vector3Int> GetPath(Vector3Int target)
    {
        checkedNodes.Clear(); //����������� ����
        freeNodes.Clear(); //��������� ����
        waitingNodes.Clear(); //��������� ����

        Vector3Int startPosition = GetComponent<Enemy>().coordinate;
        Vector3Int targetPosition = target;

        if (startPosition == targetPosition)
        {
            return pathToTarget;
        }

        Node startNode = new Node(0, startPosition, targetPosition, null); //������� ����� ���� ��������������� ��������� �������
        checkedNodes.Add(startNode); //��������� � ������ ����������� ��� ��������� ����
        waitingNodes.AddRange(GetNeighbourNodes(startNode)); //��������� ������� ��������� ����

        while (waitingNodes.Count > 0)
        {
            Node nodeToCheck = waitingNodes.Where(x => x.F == waitingNodes.Min(y => y.F)).FirstOrDefault();

            //���� ���� ��� �������� �������� ������� �� ���������� �������� ��� ������ ������� ������ ����
            if (nodeToCheck.Position == targetPosition)
            {
                return CalculatePathFromNode(nodeToCheck);
            }

            bool walkable = true;

            //��������� ���� �� ������������ �� ������ ������������ ���
            foreach(var cell in TileManager.impassableCells)
            {
                if(cell == nodeToCheck.Position)
                {
                    walkable = false;
                }
            }

            //���� ���� �� ��������� ��...
            if (walkable == false)
            {
                waitingNodes.Remove(nodeToCheck); //������� ������� ����������� ���� �� ������ ��������� ��������
                checkedNodes.Add(nodeToCheck); //��������� ������� ����������� ���� � ������ ����������� ���
            }
            //���� ���� ��������� ��...
            else if (walkable == true)
            {
                waitingNodes.Remove(nodeToCheck); //������� ������� ���� �� ������ ��������� ��������

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



        return Neighbours;
    }

    public class Node
    {
        public Vector3Int Position; //������� ����
        public Vector3Int TargetPosition; //������� ����
        public Node PreviousNode; //������ �� ���������� ����

        public int F; // F=G+H
        public int G; // ���������� �� ������ �� ����
        public int H; // ���������� �� ���� �� ����

        public Node(int g, Vector3Int nodePosition, Vector3Int targetPosition, Node previousNode)
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
