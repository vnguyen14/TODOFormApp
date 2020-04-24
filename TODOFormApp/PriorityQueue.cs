using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace TODOFormApp
{
    public class PriorityQueue
    {
        private int count;
        private int countUrgent = 0;
        private int countHigh = 0;
        private int countNormal = 0;
        private int countLow = 0;
        private ToDo first;

        public PriorityQueue()
        {
            count = 0;
            first = null;
        }

        public int Count => count;
        public int CountUrgent => countUrgent;
        public int CountHigh => countHigh;
        public int CountNormal => countNormal;
        public int CountLow => countLow;
        public bool IsReadOnly => false;

        public void Enqueue(ToDo newItem)
        {
            count++;
            if (newItem.ItemNumber == 0)
            {
                countUrgent++;
            }
            if (newItem.ItemNumber == 1)
            {
                countHigh++;
            }
            if (newItem.ItemNumber == 2)
            {
                countNormal++;
            }
            if (newItem.ItemNumber == 3)
            {
                countLow++;
            }

            if (first == null)
            {
                first = newItem;
                return;
            }
            if (newItem.ItemNumber < first.ItemNumber)
            {
                newItem.Next = first;
                first = newItem;
                return;
            }

            ToDo current = first;
            while (current != null)
            {
                if (current.Next == null)       //insert new item at the end of the list
                {
                    current.Next = newItem;
                    break;
                }
                if (current.ItemNumber <= newItem.ItemNumber &&       //insert new item between two other items
                    current.Next.ItemNumber > newItem.ItemNumber)
                {
                    newItem.Next = current.Next;
                    current.Next = newItem;
                    break;
                }
                current = current.Next;     //advance to next node if this is not the right place to insert
            }
        }

        public void Clear()
        {
            count = 0;
            countUrgent = 0;
            countHigh = 0;
            countNormal = 0;
            countLow = 0;
            first = null;
        }

        public IEnumerator<ToDo> GetEnumerator()
        {
            return new PriorityQueueEnumerator(this);
        }

        public string Dequeue()
        {
            string returnVal = first.Item;
            if (first.ItemNumber == 0)
            {
                countUrgent--;
            }
            if (first.ItemNumber == 1)
            {
                countHigh--;
            }
            if (first.ItemNumber == 2)
            {
                countNormal--;
            }
            if (first.ItemNumber == 3)
            {
                countLow--;
            }
            first = first.Next;
            count--;

            return returnVal;
        }

        public string Peek()
        {
            string returnVal = first.Item;
            return returnVal;
        }

        class PriorityQueueEnumerator : IEnumerator<ToDo>
        {
            private ToDo current;
            private int index;
            private PriorityQueue enumList;

            public PriorityQueueEnumerator(PriorityQueue list)
            {
                enumList = list;
                index = -1;
                current = null;
            }

            public ToDo Current => current;

            object IEnumerator.Current => current;

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                //first index gets incremented
                index++;
                if (index >= enumList.Count)
                    return false;
                ToDo c = enumList.first;
                for (int i = 0; i < index; i++)
                    c = c.Next;
                current = c;
                return true;
            }

            public void Reset()
            {
                index = -1;
                current = null;
            }
        }
    }
}
