using FubuMVC.Authentication.Endpoints;
using FubuMVC.Core.Continuations;
using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;

namespace FubuMVC.Authentication.Tests.Endpoints
{
	[TestFixture]
	public class when_logging_out : InteractionContext<LogoutController>
	{
		private FubuContinuation theContinuation;

		protected override void beforeEach()
		{
			theContinuation = ClassUnderTest.Logout(null);
		}

		[Test]
		public void should_clear_the_authentication()
		{
			MockFor<IAuthenticationSession>().AssertWasCalled(x => x.ClearAuthentication());
		}

		[Test]
		public void should_redirect_to_the_login_page()
		{
			theContinuation.AssertWasRedirectedTo<LoginRequest>(r => r.Url == null);
		}
	}
}