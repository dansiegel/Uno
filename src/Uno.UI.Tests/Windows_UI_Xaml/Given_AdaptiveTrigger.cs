﻿using Windows.Foundation;
using Windows.UI.Xaml;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Uno.UI.Tests.Windows_UI_Xaml
{
	[TestClass]
	public class Given_AdaptiveTrigger
	{
		[TestMethod]
		public void When_SingleActiveState()
		{
			Window.Current.SetWindowSize(new Size(100, 100));

			var sut = new AdaptiveTrigger { MinWindowHeight = 10, MinWindowWidth = 10 };

			var state = new VisualState { Name = "activeState" };
			state.StateTriggers.Add(sut);

			var group = new VisualStateGroup();
			group.States.Add(state);

			group.CurrentState.Should().Be(state);

			Window.Current.SetWindowSize(new Size(1, 1));
			group.CurrentState.Should().Be(null);
		}

		[TestMethod]
		public void When_SingleActiveState_ExactValue()
		{
			Window.Current.SetWindowSize(new Size(100d, 100d));

			var sut = new AdaptiveTrigger { MinWindowHeight = 100d, MinWindowWidth = 100d };

			var state = new VisualState { Name = "activeState" };
			state.StateTriggers.Add(sut);

			var group = new VisualStateGroup();
			group.States.Add(state);

			group.CurrentState.Should().Be(state);
		}

		[TestMethod]
		public void When_SingleInactiveState()
		{
			Window.Current.SetWindowSize(new Size(5, 5));

			var sut = new AdaptiveTrigger { MinWindowHeight = 10, MinWindowWidth = 10 };

			var state = new VisualState { Name = "activeState" };
			state.StateTriggers.Add(sut);

			var group = new VisualStateGroup();
			group.States.Add(state);

			group.CurrentState.Should().Be(null);

			Window.Current.SetWindowSize(new Size(15, 15));
			group.CurrentState.Should().Be(state);
		}

		[TestMethod]
		public void When_SingleActiveState_DefaultValue()
		{
			Window.Current.SetWindowSize(new Size(100, 100));

			var sut = new AdaptiveTrigger(); // should always be active

			var state = new VisualState { Name = "activeState" };
			state.StateTriggers.Add(sut);

			var group = new VisualStateGroup();
			group.States.Add(state);

			group.CurrentState.Should().Be(state);
		}
	}
}
