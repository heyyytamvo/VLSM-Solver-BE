namespace VLSMsolver
{
    public class PriorityQueue<T>
    {
        private List<T> data;
        private IComparer<T> comparer;

        public PriorityQueue(IComparer<T> comparer)
        {
            this.data = new List<T>();
            this.comparer = comparer;
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1;
            while (ci > 0)
            {
                int pi = (ci - 1) / 2;
                if (comparer.Compare(data[ci], data[pi]) >= 0) break;
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            int li = data.Count - 1;
            T frontItem = data[0];
            data[0] = data[li];
            data.RemoveAt(li);

            --li;
            int pi = 0;
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li) break;
                int rc = ci + 1;
                if (rc <= li && comparer.Compare(data[rc], data[ci]) < 0)
                    ci = rc;
                if (comparer.Compare(data[pi], data[ci]) <= 0) break;
                T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp;
                pi = ci;
            }
            return frontItem;
        }

        public T Peek()
        {
            T frontItem = data[0];
            return frontItem;
        }

        public int Count()
        {
            return data.Count;
        }
    }

    public class SubnetComparer : IComparer<Subnet>
    {
        public int Compare(Subnet x, Subnet y)
        {
            if (x.gettingNumberOfHosts() > y.gettingNumberOfHosts())
            {
                return -1;
            }
            else if (x.gettingNumberOfHosts() < y.gettingNumberOfHosts())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

