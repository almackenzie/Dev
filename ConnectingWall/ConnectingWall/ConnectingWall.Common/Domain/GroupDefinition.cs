namespace ConnectingWall.Common.Domain
{
    public class GroupDefinition
    {
        private readonly string _description;
        private readonly WordDefinition[] _words;

        public GroupDefinition(string description, WordDefinition[] words)
        {
            _description = description;
            _words = words;
            foreach (WordDefinition wordDefinition in words)
            {
                wordDefinition.Group = this;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public WordDefinition[] Words
        {
            get
            {
                return _words;
            }
        }

    }
}
