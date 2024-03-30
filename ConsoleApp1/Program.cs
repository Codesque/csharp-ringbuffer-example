using System;
using System.Collections.Generic; 
using System.Threading; 
using System.Timers;
using System.Numerics;




    public class RingBuffer<T>  where T : class
    {
        
        T[] queueArr; 
        int _head = 0; 
        int _tail = 0; 

        int _maxSize;


        public RingBuffer(int maxSize){
            this._maxSize = maxSize;
            queueArr = new T[this._maxSize];
        }


        public void Add(T item){

            queueArr[_head] = item; 
            _head = (_head + 1) % this._maxSize; 

        } 

        public T Extract(){

            if(_head == _tail) return null;

            T output = queueArr[_tail]; 
            _tail = (_tail + 1) % this._maxSize;
            return output;
        }


        public override string ToString(){

            string res = String.Empty; 
            for(int i = 0 ; i < queueArr.Length ; i++) 
                if(queueArr[i] != null) 
                    res += queueArr[i].ToString() + " , "; 

            return "RingBuffer : { " + res + " }";
        }



    }


    class Integer{

        public int Value {get;private set;}
        public Integer(int value) {Value = value;}

        public override string ToString()
        {
            return Value.ToString();
        }
}

    public class Program{

        public static void Main(string[] args){
        RingBuffer<Integer> rb = new RingBuffer<Integer>(16);
        System.Timers.Timer t = new System.Timers.Timer();
        bool timerFinished = false;
        t.Elapsed += new System.Timers.ElapsedEventHandler((object source, ElapsedEventArgs e) =>
        {
            timerFinished = true;

        });
        t.Interval = 30000;
        t.Enabled = true;

        while (!timerFinished)
        {

            int rand = new Random().Next(0, 10);
            rb.Add(new Integer(rand));

            Console.WriteLine("Enqued Element :" + rand + " // " + rb.ToString());

            Thread.Sleep(1000);

        }
            
        }
    }




