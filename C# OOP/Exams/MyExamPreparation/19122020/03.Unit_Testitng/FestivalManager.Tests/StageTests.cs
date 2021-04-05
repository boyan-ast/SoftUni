// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private List<Performer> performers;
		private Performer performer;
		private Song song;

		[SetUp]
		public void SetUp()
        {
			this.stage = new Stage();
			this.performers = new List<Performer>();
			this.performer = new Performer("Test", "Testov", 60);
			this.song = new Song("Testing", new TimeSpan(0, 4, 12));
        }

		[Test]
	    public void CtorCreatesStageWithPerformers()
	    {
			Assert.That(this.stage.Performers.Count, Is.EqualTo(0));
			CollectionAssert.AreEqual(this.performers, this.stage.Performers);
		}

		[Test]
		public void AddPerformerThrowsWhenNull()
        {
			Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(null));
        }

		[Test]
		public void AddPerfThrowsWhenAgeIsLess()
        {
			Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(new Performer("Young", "Tester", 16)));
		}

		[Test]
		public void AddPerfIncreasePerfCountWhenAdded()
        {
			this.stage.AddPerformer(this.performer);

			Assert.That(this.stage.Performers.Count, Is.EqualTo(1));
        }

		[Test]
		public void AddSongThrowsWhenNull()
		{
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(null));
		}

		[Test]
		public void AddSongThrowsWhenSongIsShort()
        {
			Assert.Throws<ArgumentException>(() => this.stage.AddSong(new Song("Short", new TimeSpan(0, 0, 10))));
		}

		[Test]
		public void AddSongToPerfNullSongThrows()
        {
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(null, this.performer.FullName));
		}

		[Test]
		public void AddSongToPerfNullPerfThrows()
		{
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(this.song.Name, null));
		}

		[Test]
		public void AddSongCorrectlyAdd()
        {
			this.stage.AddPerformer(this.performer);
			this.stage.AddSong(this.song);

			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

			Assert.That(this.performer.SongList.Contains(this.song), Is.True);
        }

		[Test]
		public void AddSongToPerfReturnsCorrectString()
		{
			this.stage.AddPerformer(this.performer);
			this.stage.AddSong(this.song);

			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

			string expected = $"{this.song} will be performed by {this.performer}";

			string result = this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void PlayWorks()
        {
			this.stage.AddPerformer(this.performer);
			this.stage.AddSong(this.song);

			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

			Performer second = new Performer("Second", "Testov", 21);
			Song secondSong = new Song("Second", new TimeSpan(0, 7, 10));

			this.stage.AddPerformer(second);
			this.stage.AddSong(secondSong);

			this.stage.AddSongToPerformer(secondSong.Name, second.FullName);

			string expected = $"2 performers played 2 songs";

			string result = this.stage.Play();

			Assert.That(result, Is.EqualTo(expected));
        }

	}
}