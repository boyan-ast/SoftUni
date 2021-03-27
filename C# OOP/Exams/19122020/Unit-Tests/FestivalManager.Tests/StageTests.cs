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
		private Performer performer;
		private Song song;

		[SetUp]
		public void Setup()
        {
			this.stage = new Stage();
			this.performer = new Performer("Stevie", "Nicks", 30);
			this.song = new Song("Rihannon", new TimeSpan(0, 5, 20));
        }

		[Test]
	    public void Constructor_ShouldCreateInstancesForPerformers_WhenCalled()
	    {
			List<Performer> performers = new List<Performer>();

			Assert.That(this.stage.Performers, Is.EquivalentTo(performers));
		}

		[Test]
		public void AddPerformer_ShouldThrowException_WhenPerformerIsNull()
        {
			Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(null));
        }

		[Test]
		public void AddPerformer_ShouldThrowExcepton_WhenPerformerIsTooYoung()
        {
			Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(new Performer("Justin", "Bieber", 3)));
        }

		[Test]
		public void AddPerformer_ShouldIncreaseTheCount_WhenPerformerAddedCorrectly()
        {
			this.stage.AddPerformer(this.performer);

			Assert.That(this.stage.Performers.Count, Is.EqualTo(1));
        }

		[Test]
		public void AddSong_ShouldThrowException_WhenNullGiven()
        {
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(null));
        }

		[Test]
		public void AddSong_ShouldThrowException_WhenSongIsNotLongEnough()
        {
			Assert.Throws<ArgumentException>(() => this.stage.AddSong(new Song("Underwater", new TimeSpan(0))));
        }

		//Test for adding a song
		[Test]
		public void AddSongToPerformer_ShouldWorkCorrectly_WhenSongAddedAndExisting()
        {
			this.stage.AddSong(this.song);
			this.stage.AddPerformer(this.performer);

			string result = this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);

			Assert.That(result, Is.EqualTo($"{this.song} will be performed by {this.performer.FullName}"));
        }

		[Test]
		public void AddSongToPerformer_ShoudThrowExcepton_WhenSongIsNull()
        {
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(null, "JimmyPage"));
        }

		[Test]
		public void AddSongToPerformer_ShoudThrowExcepton_WhenPerformerIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer("OverTheHillsAndFarAway", null));
		}

		[Test]
		public void AddSongToPerformer_ShouldThrowException_WhenPerformerIsNotInThePerformers()
        {
			this.stage.AddPerformer(this.performer);
			this.stage.AddSong(this.song);

			Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer(this.song.Name, "BonJovi"));
        }

		[Test]
		public void AddSongToPerformer_ShouldThrowException_WhenSongIsNotInThePerformers()
		{
			this.stage.AddPerformer(this.performer);
			this.stage.AddSong(this.song);

			Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer("EnjoyTheSilence", this.performer.FullName));
		}

		[Test]
		public void Play_ShouldReturnCorrectResult()
        {
			this.stage.AddPerformer(this.performer);

			Performer second = new Performer("Armin", "VanBuren", 35);

			this.stage.AddPerformer(second);

			this.stage.AddSong(this.song);
			this.stage.AddSong(new Song("NotGivingUpOnLove", new TimeSpan(0, 6, 30)));

			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
			this.stage.AddSongToPerformer("NotGivingUpOnLove", second.FullName);

			string result = this.stage.Play();

			Assert.That(result, Is.EqualTo($"2 performers played 2 songs"));
        }

	}
}