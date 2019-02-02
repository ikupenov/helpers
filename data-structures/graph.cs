private static IEnumerable<TVertex> DepthFirstTraverse<TVertex, TWeight>(
    IDictionary<TVertex, IEnumerable<(TVertex TargetVertex, TWeight Weight)>> weightedGraph)
{
    var visited = new HashSet<TVertex>(weightedGraph.Count);

    var stack = new Stack<(TVertex SourceVertex, IList<(TVertex TargetVertex, TWeight Weight)> Edges)>(weightedGraph.Count / 2);

    var rootVertex = weightedGraph.First().Key;
    stack.Push((rootVertex, weightedGraph[rootVertex].ToList()));

    while (stack.Any())
    {
        var (sourceVertex, edges) = stack.Pop();

        if (visited.Contains(sourceVertex)) continue;

        yield return sourceVertex;

        visited.Add(sourceVertex);

        for (var i = edges.Count - 1; i >= 0; i--)
        {
            var targetVertex = edges[i].TargetVertex;

            if (visited.Contains(targetVertex)) continue;

            stack.Push((targetVertex, weightedGraph[targetVertex].ToList()));
        }
    }
}

private static IEnumerable<TVertex> BreadthFirstTraverse<TVertex, TWeight>(
    IDictionary<TVertex, IEnumerable<(TVertex TargetVertex, TWeight Weight)>> weightedGraph)
{
    var visisted = new HashSet<TVertex>(weightedGraph.Count);

    var queue = new Queue<(TVertex SourceVertex, IEnumerable<(TVertex TargetVertex, TWeight Weight)> Edges)>(weightedGraph.Count);

    var rootVertex = weightedGraph.First().Key;
    queue.Enqueue((rootVertex, weightedGraph[rootVertex]));

    while (queue.Any())
    {
        var (sourceVertex, edges) = queue.Dequeue();

        if (visisted.Contains(sourceVertex)) continue;

        visisted.Add(sourceVertex);

        yield return sourceVertex;

        foreach (var (targetVertex, weight) in edges)
        {
            if (visisted.Contains(targetVertex)) continue;

            queue.Enqueue((targetVertex, weightedGraph[targetVertex]));
        }
    }
}

private static IDictionary<TVertex, IEnumerable<(TVertex TargetVertex, TWeight Weight)>> CreateGraph<TVertex, TWeight>()
{
    return new Dictionary<TVertex, IEnumerable<(TVertex TargetVertex, TWeight Weight)>>();
}

private static IDictionary<TVertex, IEnumerable<TVertex>> CreateGraph<TVertex>()
{
    return new Dictionary<TVertex, IEnumerable<TVertex>>();
}
