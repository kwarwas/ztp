## Method Signature Honesty

    public int Divide(int a, NotZeroNumber b)
    {
        return a / b.Value;
    }

    class NotZeroNumber 
    {
        private int _value = 1;
        
        public int Value 
        {
            get { return _value; }
            set { if (value != 0) _value = value; }
        }
    }