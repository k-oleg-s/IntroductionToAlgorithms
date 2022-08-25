using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

public class Node : ILinkedList
{
    public int Value { get; set; }
    public Node? NextNode { get; set; }
    public Node? PrevNode { get; set; }

    public Node(int value)
    {
        Value=value;
    }
    public void AddNode(int value)
    {
        var node = this;
        while (node.NextNode != null)
        {
            node = node.NextNode;
        }
        var newNode = new Node( value);
        node.NextNode = newNode;
    }

    public void AddNodeAfter(Node n1, int value)
    {
        var newNode = new Node(value);
        var n2 = n1.NextNode;

        n1.NextNode = newNode;
        if (n2 is not null) n2.PrevNode = newNode;

        newNode.PrevNode = n1;
        newNode.NextNode = n2;

    }

    public Node FindNode(int searchValue)
    {
        var node = this;

        while (node.PrevNode != null)
        {
            node = node.PrevNode;
            if (node.Value == searchValue) return node;
        }

        while (node.NextNode != null)
        {
            node = node.NextNode;
            if (node.Value == searchValue) return node;
        }

        return null;
    }

    public int GetCount()
    {
        var node = this;
        int counter = 0;
        while (node.PrevNode != null)
        {
            node = node.PrevNode;
            counter++;
        }

        while (node.NextNode != null)
        {
            node = node.NextNode;
            counter++;
        }

        var startNode = node;

        return counter;
    }

    public void RemoveNode(int index)
    {
        var node = this;
        while (node.PrevNode != null)
        {
            node = node.PrevNode;
        }
        var startNode = node;

        int x = 0;
        while(x<=index && startNode is not null)
        {
            startNode = startNode.NextNode;            
            x++;
        }
        var n1 = startNode.PrevNode;
        var n2 = startNode.NextNode;

        n1.NextNode = n2;
        n2.PrevNode = n1;
        startNode = null;
    }

    public void RemoveNode(Node n )
    {
        var n1 = n.PrevNode;
        var n2 = n.NextNode;

        n1.NextNode = n2;
        n2.PrevNode = n1;
        n = null;
    }
}


//Начальную и конечную ноду нужно хранить в самой реализации интерфейса
public interface ILinkedList
{
    int GetCount(); // возвращает количество элементов в списке
    void AddNode(int value); // добавляет новый элемент списка
    void AddNodeAfter(Node node, int value); // добавляет новый элемент    списка после определённого элемента
    void RemoveNode(int index); // удаляет элемент по порядковому номеру
    void RemoveNode(Node node); // удаляет указанный элемент
    Node FindNode(int searchValue); // ищет элемент по его значению
}

