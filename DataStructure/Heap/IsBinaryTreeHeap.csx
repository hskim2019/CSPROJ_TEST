// https://www.geeksforgeeks.org/problems/is-binary-tree-heap/1?itm_source=geeksforgeeks&itm_medium=article&itm_campaign=bottom_sticky_on_article
using System;

// 노드 정의
class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int data)
    {
        this.data = data;
        left = null;
        right = null;
    }
}

// 힙 조건 검사 함수
bool IsHeap(Node tree)
{
    if (tree == null) return true;

    // 자식이 있는데 왼쪽이 없으면 완전 이진 트리 조건 위반
    if (tree.right != null && tree.left == null)
        return false;

    // 부모가 자식보다 작으면 힙 조건 위반
    if ((tree.left != null && tree.left.data > tree.data) ||
        (tree.right != null && tree.right.data > tree.data))
        return false;

    // 왼쪽 자식이 자식 노드를 갖고 있는데 오른쪽 자식이 없으면 완전 이진 트리 조건 위반
    if (tree.left != null &&
        (tree.left.left != null || tree.left.right != null) &&
        tree.right == null)
        return false;

    // 오른쪽 자식이 자식 노드를 갖고 있는데 왼쪽 자식이 불완전하면 위반
    if (tree.right != null &&
        (tree.right.left != null || tree.right.right != null) &&
        (tree.left == null || tree.left.left == null || tree.left.right == null))
        return false;

    // 재귀적으로 왼쪽과 오른쪽 서브트리 검사
    return IsHeap(tree.left) && IsHeap(tree.right);
}

// 테스트 실행
Node root = new Node(10);
root.left = new Node(9);
root.right = new Node(8);
root.left.left = new Node(7);
root.left.right = new Node(6);
root.right.left = new Node(5);
root.right.right = new Node(4);
root.left.left.left = new Node(3);
root.left.left.right = new Node(2);
root.left.right.left = new Node(1);

if (IsHeap(root))
{
    Console.WriteLine("Given binary tree is a heap");
}
else
{
    Console.WriteLine("Given binary tree is not a heap");
}