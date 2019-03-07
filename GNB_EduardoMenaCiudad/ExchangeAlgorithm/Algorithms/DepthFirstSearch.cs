using DFSLibrary.AdjacencyLists;
using DFSLibrary.Utility;
using GNB_EduardoMenaCiudad.Entities;
using System;
using System.Collections.Generic;

namespace DFSLibrary.Algorithms
{
    public class DepthFirstSearch : IDepthFirstSearch<ExchangeRate>
    {
        private string _Currency; 
        private IAdjacencyList<ExchangeRate> _AdjList;
        private Dictionary<string, Register> _Parent;

        public DepthFirstSearch(IAdjacencyList<ExchangeRate> AdjList)
        {
            _Parent = new Dictionary<string, Register>();
            _AdjList = AdjList ?? throw new ArgumentNullException();
        }

        public void Calculate(string starter)
        {
            _Currency = starter;
            DFS(starter);
        }

        private void DFS(string starter)
        {
            _Parent = new Dictionary<string, Register>();
            var starterVertex = _AdjList.GetAdjacentNodes(starter);
            AddToParent(starter, string.Empty, 0);

            foreach (var sVertex in starterVertex)
            {
                if (!IsInParent(sVertex.Key))
                {
                    AddToParent(sVertex.Key, starter, sVertex.Value);
                    DFS_Visit(sVertex.Key, _AdjList.GetAdjacentNodes(sVertex.Key));
                }
            }
        }

        private void DFS_Visit(string vertex, Dictionary<string, decimal> adjList)
        {
            foreach (var currentVertex in adjList)
            {
                if (!IsInParent(currentVertex.Key))
                {
                    var node = currentVertex.Key;
                    var parent = vertex;

                    AddToParent(node, parent, currentVertex.Value);
                    DFS_Visit(node, _AdjList.GetAdjacentNodes(node));
                }
            }
        }

        private bool IsInParent(string node)
        {
            return _Parent.ContainsKey(node);
        }

        private void AddToParent(string node, string parent, decimal rate)
        {
            _Parent.Add(node, new Register { Parent = parent, Rate = rate });
        }

        private Register GetParent(string key)
        {
            _Parent.TryGetValue(key, out Register result);
            return result;
        }


        public decimal ConvertFrom(string from, decimal amount, string to)
        {
            _Currency = to;
            CheckAndInitialize(to);

            Register result = null;
            decimal exchangeRate = 1;
            var previous = from;

            if(GetParent(previous) == null)
            {
                throw new NotFoundCurrencyException($"{from} currency not registered");
            }

            do
            {
                result = GetParent(previous);
                exchangeRate = exchangeRate / result.Rate;
                previous = result.Parent;


            } while (result.Parent != to || result == null);

            return exchangeRate;
        }

        private void CheckAndInitialize(string toCurrency)
        {
            var condition = IsParentInitialized() && toCurrency == _Currency;

            if (!condition)
            {
                DFS(toCurrency);

                if (!IsInParent(toCurrency))
                {
                    throw new NotFoundCurrencyException($" Unable to calculate {toCurrency} requested exchangerate with current files");
                }
            }
        }

        private bool IsParentInitialized()
        {
            return _Parent != null && _Parent.Count > 0; 
        }
    }
}
