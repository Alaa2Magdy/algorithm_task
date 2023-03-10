using System;

class GFG
{

    static int V = 5;
    static int[] parent = new int[V];
    static int INF = int.MaxValue;

    
    static int find(int i)
    {
        while (parent[i] != i)
            i = parent[i];
        return i;
    }

   
    static void union1(int i, int j)
    {
        int a = find(i);
        int b = find(j);
        parent[a] = b;
    }

    
    static void kruskalMST(int[,] cost)
    {
        int mincost = 0; 

       
        for (int i = 0; i < V; i++)
            parent[i] = i;

       
        int edge_count = 0;
        while (edge_count < V - 1)
        {
            int min = INF, a = -1, b = -1;
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (find(i) != find(j) && cost[i, j] < min)
                    {
                        min = cost[i, j];
                        a = i;
                        b = j;
                    }
                }
            }

            union1(a, b);
            Console.Write("Edge {0}:({1}, {2}) cost:{3} \n",
                edge_count++, a, b, min);
            mincost += min;
        }
        Console.Write("\n Minimum cost= {0} \n", mincost);
    }

   
    public static void Main(String[] args)
    {
       
        int[,] cost = {
        { INF, 2, INF, 6, INF },
        { 2, INF, 3, 8, 5 },
        { INF, 3, INF, INF, 7 },
        { 6, 8, INF, INF, 9 },
        { INF, 5, 7, 9, INF },
    };

       
        kruskalMST(cost);
    }
}