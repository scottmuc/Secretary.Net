using System.Collections.Generic;
using Secretary.Samples.Domain;

namespace Secretary.Samples
{
    public class SampleSetup
    {
        public void Setup()
        {
            var musicSchool = new School("MusicSchool", @"C:\test\music");
            
            musicSchool.Specializations.Add<Artist>(FileType.Audio, a => a.Id.ToString());
            
            var imageSchool = new School("ImageSchool", @"C:\test\images");

            imageSchool.Specializations.Add<Artist>(FileType.Image, a => a.Id.ToString());
            imageSchool.Specializations.Add<User>(FileType.Image, u => u.Id.ToString());

            musicSchool.Enroll(new Secretary()).SpecializingIn(FileType.Audio).For<Artist>();

            imageSchool.Enroll(new Secretary()).SpecializingIn(FileType.Image).For<Artist>();
            imageSchool.Enroll(new Secretary()).SpecializingIn(FileType.Image).For<User>();

            var ceremony = new GraduationCeremony(musicSchool.Enrollments);
            var grads = new List<Secretary>();

            grads.AddRange(ceremony.GetGraduates());

            ceremony = new GraduationCeremony(imageSchool.Enrollments);

            grads.AddRange(ceremony.GetGraduates());


        }
    }
}