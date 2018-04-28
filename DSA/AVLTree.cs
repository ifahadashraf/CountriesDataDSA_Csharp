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

        MyNode minValueNode(MyNode node)
        {
            MyNode current = node;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
                current = current.left;

            return current;
        }

        public MyNode deleteNode(MyNode root, MyNode key)
        {
            // STEP 1: PERFORM STANDARD BST DELETE
            if (root == null)
                return root;

            // If the key to be deleted is smaller than
            // the root's key, then it lies in left subtree
            if (key.gdpGrowth < root.gdpGrowth)
                root.left = deleteNode(root.left, key);

            // If the key to be deleted is greater than the
            // root's key, then it lies in right subtree
            else if (key.gdpGrowth > root.gdpGrowth)
                root.right = deleteNode(root.right, key);

            // if key is same as root's key, then this is the node
            // to be deleted
            else
            {

                // node with only one child or no child
                if ((root.left == null) || (root.right == null))
                {
                    MyNode temp = null;
                    if (temp == root.left)
                        temp = root.right;
                    else
                        temp = root.left;

                    // No child case
                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else   // One child case
                        root = temp; // Copy the contents of
                    // the non-empty child
                }
                else
                {

                    // node with two children: Get the inorder
                    // successor (smallest in the right subtree)
                    MyNode temp = minValueNode(root.right);

                    // Copy the inorder successor's data to this node
                    root.gdpGrowth = temp.gdpGrowth;

                    // Delete the inorder successor
                    root.right = deleteNode(root.right, temp);
                }
            }

            // If the tree had only one node then return
            if (root == null)
                return root;

            // STEP 2: UPDATE HEIGHT OF THE CURRENT NODE
            root.nodeHeight = max(nodeHeight(root.left), nodeHeight(root.right)) + 1;

            // STEP 3: GET THE BALANCE FACTOR OF THIS NODE (to check whether
            //  this node became unbalanced)
            int balance = getBalance(root);

            // If this node becomes unbalanced, then there are 4 cases
            // Left Left Case
            if (balance > 1 && getBalance(root.left) >= 0)
                return rightRotate(root);

            // Left Right Case
            if (balance > 1 && getBalance(root.left) < 0)
            {
                root.left = leftRotate(root.left);
                return rightRotate(root);
            }

            // Right Right Case
            if (balance < -1 && getBalance(root.right) <= 0)
                return leftRotate(root);

            // Right Left Case
            if (balance < -1 && getBalance(root.right) > 0)
            {
                root.right = rightRotate(root.right);
                return leftRotate(root);
            }

            return root;
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
