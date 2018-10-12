using System;
using System.Text;

namespace Strategy
{
    internal interface ICharCompositionStrategy
    {
        char GetChar();
    }

    class AsteriskComposition : ICharCompositionStrategy
    {
        public char GetChar()
        {
            return '*';
        }
    }
    
    class DotComposition : ICharCompositionStrategy
    {
        public char GetChar()
        {
            return '.';
        }
    }

    class Logo
    {
        public ICharCompositionStrategy CharCompositionStrategy { get; }

        public Logo(ICharCompositionStrategy charCompositionStrategy)
        {
            CharCompositionStrategy = charCompositionStrategy;
        }

        public override string ToString()
        {
            const bool t = true;
            const bool f = false;

            bool[,] text = 
            {
                {f, f, t, f, f, f, t, t, t, t, t, f, t, f, f, f, t},
                {f, t, f, t, f, f, f, f, t, f, f, f, t, f, f, f, t},
                {t, t, t, t, t, f, f, f, t, f, f, f, t, t, t, t, t},
                {t, f, f, f, t, f, f, f, t, f, f, f, t, f, f, f, t},
                {t, f, f, f, t, f, f, f, t, f, f, f, t, f, f, f, t}
            };

            var sb = new StringBuilder();

            for (int i = 0; i < text.GetLength(0); i++)
            {
                for (int j = 0; j < text.GetLength(1); j++)
                {
                    sb.Append(text[i, j] ? CharCompositionStrategy.GetChar() : ' ');
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
    
    class Logo<TType> where TType: ICharCompositionStrategy, new()
    {
        private TType _charCompositeStrategy = new TType();
        
        public override string ToString()
        {
            const bool t = true;
            const bool f = false;

            bool[,] text = 
            {
                {f, f, t, f, f, f, t, t, t, t, t, f, t, f, f, f, t},
                {f, t, f, t, f, f, f, f, t, f, f, f, t, f, f, f, t},
                {t, t, t, t, t, f, f, f, t, f, f, f, t, t, t, t, t},
                {t, f, f, f, t, f, f, f, t, f, f, f, t, f, f, f, t},
                {t, f, f, f, t, f, f, f, t, f, f, f, t, f, f, f, t}
            };

            var sb = new StringBuilder();

            for (int i = 0; i < text.GetLength(0); i++)
            {
                for (int j = 0; j < text.GetLength(1); j++)
                {
                    sb.Append(text[i, j] ? _charCompositeStrategy.GetChar() : ' ');
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine(new Logo(new AsteriskComposition()));
            Console.WriteLine(new Logo(new DotComposition()));
            
            Console.WriteLine(new Logo<AsteriskComposition>());
            Console.WriteLine(new Logo<DotComposition>());
        }
    }
}