## Strategy design pattern

Przykładowa implementacja

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

