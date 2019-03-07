using System.Collections.Generic;

namespace DFSLibrary.AdjacencyLists.Factories
{
    public interface IAdjacencyListFactory <Entity>
    {
        IAdjacencyList<Entity> CreateList(IEnumerable<Entity> list);
    }
}
