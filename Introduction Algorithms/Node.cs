﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

public class Node
{
    public int Value { get; set; }
    public List<Edge> Edges { get; set; }
}

public class Edge
{
    public int Weight { get; set; }
    public Node N { get; set; }
}