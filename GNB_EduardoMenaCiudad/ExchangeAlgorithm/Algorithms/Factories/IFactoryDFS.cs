using System.Collections.Generic;

namespace DFSLibrary.Algorithms.Factories
{
    public interface IFactoryDFS <T>
    {
        IDepthFirstSearch<T> Create(IEnumerable<T> entities);
    }
}