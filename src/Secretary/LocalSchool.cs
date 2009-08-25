using System.IO;

namespace Secretary
{
    /// <summary>
    /// A school that trains secretaries for local file locating.
    /// </summary>
    public class LocalSchool : School
    {
        private readonly DirectoryInfo baseDirectory;

        public LocalSchool(string name, string baseFolder)
            : this (name, new DirectoryInfo(baseFolder))
        {
            
        }

        public LocalSchool(string name, DirectoryInfo baseDirectory)
            : base(name)
        {
            this.baseDirectory = baseDirectory;
        }

        public override string BaseFilePath
        {
            get { return baseDirectory.FullName; }
        }

        public override Location Location
        {
            get { return Location.Local; }
        }

        public override IEnrollment Enroll()
        {
            var enrollment = new Enrollment
            {
                FileType = FileType.Default,
                Secretary = new Secretary(),
                School = this
            };

            Enrollments.Add(enrollment);

            return enrollment;
        }
    }
}