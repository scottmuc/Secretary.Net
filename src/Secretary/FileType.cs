namespace Secretary
{
    /// <summary>
    /// Currently this is just a marker property to differentiate file location contexts
    /// </summary>
    public class FileType
    {
        public static FileType File = new FileType("File");
        public static FileType Image = new FileType("Image");
        public static FileType Audio = new FileType("Audio");
        public static FileType Default = File;

        public FileType(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString() 
        {
            return Name;
        }

    }
}
