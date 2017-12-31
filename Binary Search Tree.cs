using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;
namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BST Bst = new BST();
            SetBST(Bst);

            Write("PreOrder: "); PreOrder(Bst.Root);
            Write("\nInOrder: "); InOrder(Bst.Root);
            Write("\nPostOrder: "); PostOrder(Bst.Root);
        }
        static public BST SetBST(BST T)
        {
            WriteLine("Girilecek veri adeti: ");
            int item = 0, count = ToInt32(ReadLine());
            for (int i = 0; i < count; i++)
            {
                WriteLine(i + 1 + ".Veri: ");
                item = ToInt32(ReadLine());
                T.Add(item);
            }
            return T;
        }
        static public void PreOrder(BSTNode Root)
        {
            if (Root == null) return;
            Write(Root.Data + " ");
            PreOrder(Root.Left);
            PreOrder(Root.Right);
        }
        static public void InOrder(BSTNode Root)
        {
            if (Root == null) return;
            InOrder(Root.Left);
            Write(Root.Data + " ");
            InOrder(Root.Right);
        }
        static public void PostOrder(BSTNode Root)
        {
            if (Root == null) return;
            PostOrder(Root.Left);
            PostOrder(Root.Right);
            Write(Root.Data + " ");
        }
    }
    class BST
    {
        //Tercihen yazılmayabilir.
        public BSTNode Root;
        public BST() { Root = null; }
        public void Add(int e)
        {
            if(Root != null)
            {
                Root.Add(e);
                return;
            }
            Root = new BSTNode(e);
        }
        public void Remove(int e)
        {
            if (Root.Data == e) Root = null;
            if (Root != null) Root.Add(e);
            return;
        }
        public void Search(int e) { Root.Search(e); }
    }
    class BSTNode
    {
        public int Data;
        public BSTNode Left, Right; //PreOrder, InOrder ve PostOrder Dolaşma için erişilebilir olmalıdır.
        public BSTNode(int Data)
        {
            Left = Right = null;
            this.Data = Data;
        }
        public void Add(int Item)
        {
            if(Item < Data)
            {
                if(Left != null)
                {
                    Left.Add(Item);
                    return;
                }
                BSTNode New = new BSTNode(Item);
                Left = New;
            }
            else if(Item > Data)
            {
                if(Right != null)
                {
                    Right.Add(Item);
                    return;
                }
                BSTNode New = new BSTNode(Item);
                Right = New;
            }
        }
        public void Remove(int Item, BSTNode Parent = null)
        {
            if(Item < Data)
            {
                if (Left != null) Left.Remove(Item,this);
                return;
            }
            else if(Item > Data)
            {
                if (Right != null) Right.Remove(Item, this);
                return;
            }

            if ((Left == null) && (Right == null))
            {
                if (Parent.Left == this) Parent.Left = null;
                else Parent.Right = null;
            }
            else if((Right != null) && (Left != null))
            {
                Data = Right.MinValue();
                Right.Remove(Data, this);
                return;
            }
            else if(Right != null)
            {
                if (Parent.Left == this) Parent.Left = Right;
                else Parent.Right = Right;
            }
            else if(Left != null)
            {
                if (Parent.Left == this) Parent.Left = Right;
                else Parent.Right = Left;
            }
        }
        public BSTNode Search(int Item)
        {
            if(Item < Data)
            {
                if (Left != null) return Left.Search(Item);
                else return null;
            }
            else if(Item > Data)
            {
                if (Right != null) return Right.Search(Item);
                else return null;
            }
            return this;
        }
        public int MinValue()
        {
            if (Left != null) return Left.MinValue();
            return Data;
        }
    }
}
