using System;

namespace Secretary
{
    public class HttpSchool : School
    {
        private readonly Uri baseUri;

        public HttpSchool(string name, string hostname, string basePath)
            : this (name, new Uri(string.Format("http://{0}{1}", hostname, basePath)))
        {
        }

        public HttpSchool(string name, Uri baseUri)
            : base(name)
        {
            this.baseUri = baseUri;
        }

        public override string BaseFilePath
        {
            get { return baseUri.AbsoluteUri; }
        }

        public override Location Location
        {
            get { return Location.Web; }
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
