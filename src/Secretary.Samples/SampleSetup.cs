using System.Collections.Generic;
using Secretary.Samples.Domain;
using Xunit;

namespace Secretary.Samples
{
    public class SampleSetup
    {
        private void Sample_ApplicationStartup()
        {
            var musicSchool = new LocalSchool("MusicSchool", @"C:\test\music");

            musicSchool.Specializations.Add<Artist>(FileType.Audio, a => a.Id.ToString());
            musicSchool.Specializations.Add<Artist>(a => @"temp\" + a.Id.ToString());

            var imageSchool = new LocalSchool("ImageSchool", @"C:\test\images");

            imageSchool.Specializations.Add<Artist>(FileType.Image, a => a.Id.ToString());
            imageSchool.Specializations.Add<User>(FileType.Image, u => u.Id.ToString());

            musicSchool.Enroll().SpecializingIn(FileType.Audio).For<Artist>();
            musicSchool.Enroll().For<Artist>();

            imageSchool.Enroll().SpecializingIn(FileType.Image).For<Artist>();
            imageSchool.Enroll().SpecializingIn(FileType.Image).For<User>();

            var ceremony = new GraduationCeremony(musicSchool.Enrollments);
            var grads = new List<Secretary>();

            grads.AddRange(ceremony.GetGraduates());

            ceremony = new GraduationCeremony(imageSchool.Enrollments);

            grads.AddRange(ceremony.GetGraduates());

            Locate.InitializeWith(grads);
        }


        [Fact]
        public void Setup()
        {
            Sample_ApplicationStartup();

            var testArtist = new Artist() {Id = 1};
            var testUser = new User() {Id = 1};

            var test1 = Locate.FileOfType(FileType.Image).Named("Test.jpg").For(testArtist);

            Assert.Equal(@"C:\test\images\1\Test.jpg", test1);

            var test2 = Locate.FileOfType(FileType.Image).Named("Test.jpg").For(testUser);

            // notice how this is the same as the artist image
            Assert.Equal(@"C:\test\images\1\Test.jpg", test2);

            var test3 = Locate.FileOfType(FileType.Audio).Named("Test.mp3").For(testArtist);

            Assert.Equal(@"C:\test\music\1\Test.mp3", test3);

            var test4 = Locate.FolderForType(FileType.Audio).For(testArtist);

            Assert.Equal(@"C:\test\music\1", test4);
        }
    }
}