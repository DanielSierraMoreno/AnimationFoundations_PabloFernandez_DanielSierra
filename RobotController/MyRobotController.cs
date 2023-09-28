using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RobotController
{

    public struct MyQuat
    {
        public float x;
        public float y;
        public float z;
        public float w;


        public MyQuat(float _x,float _y,float _z,float _w) 
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }

        public static MyQuat operator +(MyQuat a, MyQuat b)
        {
            return new MyQuat(a.x + b.x, a.y + b.y, a.z * b.z, a.w + b.w);
        }
        public static MyQuat operator *(MyQuat a, MyQuat b)
        {
            MyQuat r = new MyQuat();
            r.w = a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z;
            r.x = a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y;
            r.y = a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x;
            r.z = a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w;

            return r;
        }
        public static MyQuat operator *(MyQuat a, float b)
        {
            MyQuat r = new MyQuat();
            r.w *= b;
            r.x *= b;
            r.y *= b;
            r.z *= b;


            return r;
        }
        public MyQuat Conjugate() 
        {
            x = -x;
            y = -y;
            z = -z;
            return this;
        }
        public static MyQuat Identity()
        {
            return new MyQuat(0,0,0,1);
        }
        public static MyQuat Cross(MyQuat a,MyQuat b) 
        {
            return a * b.Conjugate();
        }
        public float Magnitude() 
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
        }
        public static MyQuat VectoQuad(MyVec v) 
        {
            return new MyQuat(v.x, v.y, v.z, 0);
        }
        public static MyQuat VectoQuad(MyVec v,float w)
        {
            return new MyQuat(v.x, v.y, v.z, w);
        }
        public MyQuat Rotate(MyVec v,float angle) 
        {
            MyQuat q = VectoQuad(v) * (float)Math.Sin(angle);
            q.w = (float)Math.Cos(angle);

            return this = this * q * Conjugate(); ;
        }
    }

    public struct MyVec
    {
        public float x;
        public float y;
        public float z;
    }


    public class MyRobotController
    {

        #region public methods

        public string Hi()
        {

            string s = "hello world from my Robot Controller";
            return s;

        }


        //EX1: this function will place the robot in the initial position

        public void PutRobotStraight(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3) {

            //todo: change this, use the function Rotate declared below
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;
        }

        //EX2: this function will interpolate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.

        public bool PickStudAnim(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            bool myCondition = false;
            //todo: add a check for your condition



            if (myCondition)
            {
                //todo: add your code here
                rot0 = NullQ;
                rot1 = NullQ;
                rot2 = NullQ;
                rot3 = NullQ;


                return true;
            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        //EX3: this function will calculate the rotations necessary to move the arm of the robot until its end effector collides with the target (called Stud_target)
        //it will return true until it has reached its destination. The main project is set up in such a way that when the function returns false, the object will be droped and fall following gravity.
        //the only difference wtih exercise 2 is that rot3 has a swing and a twist, where the swing will apply to joint3 and the twist to joint4

        public bool PickStudAnimVertical(out MyQuat rot0, out MyQuat rot1, out MyQuat rot2, out MyQuat rot3)
        {

            bool myCondition = false;
            //todo: add a check for your condition



            while (myCondition)
            {
                //todo: add your code here

            }

            //todo: remove this once your code works.
            rot0 = NullQ;
            rot1 = NullQ;
            rot2 = NullQ;
            rot3 = NullQ;

            return false;
        }


        public static MyQuat GetSwing(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }


        public static MyQuat GetTwist(MyQuat rot3)
        {
            //todo: change the return value for exercise 3
            return NullQ;

        }




        #endregion


        #region private and internal methods

        internal int TimeSinceMidnight { get { return (DateTime.Now.Hour * 3600000) + (DateTime.Now.Minute * 60000) + (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond; } }


        private static MyQuat NullQ
        {
            get
            {
                MyQuat a;
                a.w = 1;
                a.x = 0;
                a.y = 0;
                a.z = 0;
                return a;

            }
        }

        internal MyQuat Multiply(MyQuat q1, MyQuat q2) {

            return q1 * q2;

        }

        internal MyQuat Rotate(MyQuat currentRotation, MyVec axis, float angle)
        {
            return currentRotation.Rotate(axis,angle);

        }




        //todo: add here all the functions needed

        #endregion






    }
}
