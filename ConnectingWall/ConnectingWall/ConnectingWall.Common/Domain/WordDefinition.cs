namespace ConnectingWall.Common.Domain
{
    public class WordDefinition
    {
        private readonly string _word;

        public WordDefinition(string word)
        {
            _word = word;
        }

        public string Word
        {
            get
            {
                return _word;
            }
        }

        public GroupDefinition Group { get; set; }

    }
}
