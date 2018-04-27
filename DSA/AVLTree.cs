using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class AVLTree
    {
        public MyNode root;

        // A utility function to get nodeHeight of the tree
        int nodeHeight(MyNode N)
        {
            if (N == null)
                return 0;

            return N.nodeHeight;
        }

        // A utility function to get maximum of two integers
        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // A utility function to right rotate subtree rooted with y
        // See the diagram given above.
        MyNode rightRotate(MyNode y)
        {
            MyNode x = y.left;
            MyNode T2 = x.right;

            // Perform rotation
            x.right = y;
            y.left = T2;

            // Update nodeHeights
            y.nodeHeight = max(nodeHeight(y.left), nodeHeight(y.right)) + 1;
            x.nodeHeight = max(nodeHeight(x.left), nodeHeight(x.right)) + 1;

            // Return new root
            return x;
        }

        // A utility function to left rotate subtree rooted with x
        // See the diagram given above.
        MyNode leftRotate(MyNode x)
        {
            MyNode y = x.right;
            MyNode T2 = y.left;

            // Perform rotation
            y.left = x;
            x.right = T2;

            //  Update nodeHeights
            x.nodeHeight = max(nodeHeight(x.left), nodeHeight(x.right)) + 1;
            y.nodeHeight = max(nodeHeight(y.left), nodeHeight(y.right)) + 1;

            // Return new root
            return y;
        }

        // Get Balance factor of MyNode N
        int getBalance(MyNode N)
        {
            if (N == null)
                return 0;

            return nodeHeight(N.left) - nodeHeight(N.right);
        }

        public MyNode insert(MyNode MyNode, MyNode newNode)
        {

            /* 1.  Perform the normal BST insertion */
            if (MyNode == null)
                return newNode;

            if (newNode.gdpGrowth < MyNode.gdpGrowth)
                MyNode.left = insert(MyNode.left, newNode);
            else if (newNode.gdpGrowth > MyNode.gdpGrowth)
                MyNode.right = insert(MyNode.right, newNode);
            else // Duplicate keys not allowed
                return MyNode;

            /* 2. Update nodeHeight of this ancestor MyNode */
            MyNode.nodeHeight = 1 + max(nodeHeight(MyNode.left),
                                  nodeHeight(MyNode.right));

            /* 3. Get the balance factor of this ancestor
                  MyNode to check whether this MyNode became
                  unbalanced */
            int balance = getBalance(MyNode);

            // If this MyNode becomes unbalanced, then there
            // are 4 cases Left Left Case
            if (balance > 1 && newNode.gdpGrowth < MyNode.left.gdpGrowth)
                return rightRotate(MyNode);

            // Right Right Case
            if (balance < -1 && newNode.gdpGrowth > MyNode.right.gdpGrowth)
                return leftRotate(MyNode);

            // Left Right Case
            if (balance > 1 && newNode.gdpGrowth > MyNode.left.gdpGrowth)
            {
                MyNode.left = leftRotate(MyNode.left);
                return rightRotate(MyNode);
            }

            // Right Left Case
            if (balance < -1 && newNode.gdpGrowth < MyNode.right.gdpGrowth)
            {
                MyNode.right = rightRotate(MyNode.right);
                return leftRotate(MyNode);
            }

            /* return the (unchanged) MyNode pointer */
            return MyNode;
        }

        // A utility function to print preorder traversal
        // of the tree.
        // The function also prints nodeHeight of every MyNode
        public void preOrder(MyNode MyNode) {
        if (MyNode != null) {
            Console.WriteLine(MyNode.countryName + " : "+ MyNode.gdpGrowth );
            preOrder(MyNode.left);
            preOrder(MyNode.right);
        }
    }
    }
}
