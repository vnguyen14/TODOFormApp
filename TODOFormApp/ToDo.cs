using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOFormApp
{
    public class ToDo
    {
        private int itemNum;
        private string item;
        private string priority;
        private ToDo next;

        public ToDo(int iTemNum, string iTem, string pri)
        {
            this.item = iTem;
            this.priority = pri;
            this.itemNum = iTemNum;
        }

        public int ItemNumber
        {
            get { return this.itemNum; }
        }
        public string Item
        {
            get { return this.item; }
        }

        public string Prority
        {
            get { return this.priority; }
        }

        public ToDo Next
        {
            get { return next; }
            set { next = value; }
        }


    }
}
