using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20151121._2048.VAE2
{
    class MoveWay
    {
         public MoveWay(int num1)
        {
            Num = num1;
            if(num1%4==0)
            {
                IsT1 = true; IsLinkL = false;
            }
            if(num1%4==1)
            {
                IsT2 = true;
            }
            if (num1 % 4 ==2)
            {
                IsT3 = true;
            }
            if (num1 % 4 == 3)
            {
                IsT4 = true; IsLinkR = false;
            }
            if(num1>=0 & num1<4)
            {
                IsL1 = true; IsLinkT = false;
            }
            if (num1 >= 4 & num1 < 8)
            {
                IsL2 = true;
            }
            if (num1 >= 8 & num1< 12)
            {
                IsL3 = true;
            }
            if (num1 >= 12 & num1 < 16)
            {
                IsL4 = true; IsLinkB = false;
            }
          

        }
        /// <summary>
        /// 获取它上，下，左，右是否有label
        /// </summary>
        private bool isLinkT = true;

        public bool IsLinkT
        {
            get { return isLinkT; }
            set { isLinkT = value; }
        }

        private bool isLinkB = true;

        public bool IsLinkB
        {
            get { return isLinkB; }
            set { isLinkB = value; }
        }
        private bool isLinkL = true;

        public bool IsLinkL
        {
            get { return isLinkL; }
            set { isLinkL = value; }
        }
        private bool isLinkR = true;

        public bool IsLinkR
        {
            get { return isLinkR; }
            set { isLinkR = value; }
        }
        private bool isT1 = false;

        public bool IsT1
        {
            get { return isT1; }
            set { isT1 = value; }
        }
        private bool isT2 = false;

        public bool IsT2
        {
            get { return isT2; }
            set { isT2 = value; }
        }
        private bool isT3 = false;

        public bool IsT3
        {
            get { return isT3; }
            set { isT3 = value; }
        }
        private bool isT4 = false;

        public bool IsT4
        {
            get { return isT4; }
            set { isT4 = value; }
        }
        private bool isL1 = false;

        public bool IsL1
        {
            get { return isL1; }
            set { isL1 = value; }
        }
        private bool isL2 = false;

        public bool IsL2
        {
            get { return isL2; }
            set { isL2 = value; }
        }
        private bool isL3 = false;

        public bool IsL3
        {
            get { return isL3; }
            set { isL3 = value; }
        }
        private bool isL4 = false;

        public bool IsL4
        {
            get { return isL4; }
            set { isL4 = value; }
        }

        private bool isNum = false;

        public bool IsNum
        {
            get { return isNum; }
            set { isNum = value; }
        }
        private int num;

        public int Num
        {
            get { return num; }
            set { num = value; }
        }


    
    }
}
