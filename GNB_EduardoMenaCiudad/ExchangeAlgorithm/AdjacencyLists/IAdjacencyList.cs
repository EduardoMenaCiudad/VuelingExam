using System.Collections.Generic;

namespace DFSLibrary.AdjacencyLists
{                                   
    public interface IAdjacencyList<Entity>
    {                                   
        Dictionary<string, decimal> GetAdjacentNodes(string key);
        bool IsInList(Entity toCheck);
    }
}