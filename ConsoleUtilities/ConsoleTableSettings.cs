namespace ConsoleUtilities
{
    public class ConsoleTableSettings
    {
        public char FieldDelimiter { get; set; }
        public char RowDelimiter { get; set; }
        public int Padding { get; set; }

        public ConsoleTableSettings(char fieldDelimiter = '|', char rowDelimiter = '+', int padding = 2)
        {
            this.FieldDelimiter = fieldDelimiter;
            this.RowDelimiter = rowDelimiter;
            this.Padding = padding;
        }
    }
}


