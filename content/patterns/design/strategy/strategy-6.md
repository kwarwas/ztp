## Strategy design pattern

Przykładowa implementacja

    class Logo
    {
        public ICharCompositionStrategy CharCompositionStrategy { get; }

        public Logo(ICharCompositionStrategy charCompositionStrategy)
        {
            CharCompositionStrategy = charCompositionStrategy;
        }

        public override string ToString()
        {
            const bool t = true, f = false;

            bool[,] text = {
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
                    sb.Append(text[i, j] ? CharCompositionStrategy.GetChar() : ' ');
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

