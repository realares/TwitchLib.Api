using TwitchLib.Api.Test.Helpers;
using Xunit;

namespace TwitchLib.Api.Test.Unit.Helix
{
    public class HelixAnalytics
    {
        [Fact]
        public async void TestGetGameAnalytics()
        {
            var mockHandler = HelixSetup.GetMockHttpCallHandler(GetGameAnalyticsResponse);
            var api = TwitchLibMock.TwitchApi(mockHandler);

            var result = await api.Helix.Analytics.GetGameAnalyticsAsync("493057", "RandomTokenThatDoesntMatter");

            Assert.True(result.Data[0].Type == "overview_v2");
            Assert.True(result.Data[0].GameId == "493057");
        }

        [Fact]
        public async void TestGetExtensionAnalytics()
        {
            var mockHandler = HelixSetup.GetMockHttpCallHandler(GetExtensionAnalyticsResponse);
            var api = TwitchLibMock.TwitchApi(mockHandler);

            var result = await api.Helix.Analytics.GetExtensionAnalyticsAsync("abcdefgh", "RandomTokenThatDoesntMatter");

            Assert.True(result.Data[0].Url == "https://twitch-piper-reports.s3-us-west-2.amazonaws.com/games/66170/overview/1518307200000.csv?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=ASIAJP7WFIAF26K7BC2Q%2F20180222%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20180222T220651Z&X-Amz-Expires=60&X-Amz-Security-Token=FQoDYXdzEE0aDLKNl9aCgfuikMKI%2ByK3A4e%2FR%2B4to%2BmRZFUuslNKs%2FOxKeySB%2BAU87PBtNGCxQaQuN2Q8KI4Vg%2Bve2x5eenZdoH0ZM7uviM94sf2GlbE9Z0%2FoJRmNGNhlU3Ua%2FupzvByCoMdefrU8Ziiz4j8EJCgg0M1j2aF9f8bTC%2BRYwcpP0kjaZooJS6RFY1TTkh659KBA%2By%2BICdpVK0fxOlrQ%2FfZ6vIYVFzvywBM05EGWX%2F3flCIW%2BuZ9ZxMAvxcY4C77cOLQ0OvY5g%2F7tuuGSO6nvm9Eb8MeMEzSYPr4emr3zIjxx%2Fu0li9wjcF4qKvdmnyk2Bnd2mepX5z%2BVejtIGBzfpk%2Fe%2FMqpMrcONynKoL6BNxxDL4ITo5yvVzs1x7OumONHcsvrTQsd6aGNQ0E3lrWxcujBAmXmx8n7Qnk4pZnHZLgcBQam1fIGba65Gf5Ern71TwfRUsolxnyIXyHsKhd2jSmXSju8jH3iohjv99a2vGaxSg8SBCrQZ06Bi0pr%2FTiSC52U1g%2BlhXYttdJB4GUdOvaxR8n6PwMS7HuAtDJUui8GKWK%2F9t4OON3qhF2cBt%2BnV%2BDg8bDMZkQ%2FAt5blvIlg6rrlCu0cYko4ojb281AU%3D&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3Bfilename%3Dextabcd-overview-2018-03-12.csv&X-Amz-Signature=49cc07cbd9d753b00315b66f49b9e4788570062ff3bd956288ab4f164cf96708");
        }

        private readonly string GetGameAnalyticsResponse = "{\"data\":[{\"game_id\":\"493057\",\"URL\":\"https://twitch-piper-reports.s3-us-west-2.amazonaws.com/games/66170/overview/1518307200000.csv?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=ASIAJP7WFIAF26K7BC2Q%2F20180222%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20180222T220651Z&X-Amz-Expires=60&X-Amz-Security-Token=FQoDYXdzEE0aDLKNl9aCgfuikMKI%2ByK3A4e%2FR%2B4to%2BmRZFUuslNKs%2FOxKeySB%2BAU87PBtNGCxQaQuN2Q8KI4Vg%2Bve2x5eenZdoH0ZM7uviM94sf2GlbE9Z0%2FoJRmNGNhlU3Ua%2FupzvByCoMdefrU8Ziiz4j8EJCgg0M1j2aF9f8bTC%2BRYwcpP0kjaZooJS6RFY1TTkh659KBA%2By%2BICdpVK0fxOlrQ%2FfZ6vIYVFzvywBM05EGWX%2F3flCIW%2BuZ9ZxMAvxcY4C77cOLQ0OvY5g%2F7tuuGSO6nvm9Eb8MeMEzSYPr4emr3zIjxx%2Fu0li9wjcF4qKvdmnyk2Bnd2mepX5z%2BVejtIGBzfpk%2Fe%2FMqpMrcONynKoL6BNxxDL4ITo5yvVzs1x7OumONHcsvrTQsd6aGNQ0E3lrWxcujBAmXmx8n7Qnk4pZnHZLgcBQam1fIGba65Gf5Ern71TwfRUsolxnyIXyHsKhd2jSmXSju8jH3iohjv99a2vGaxSg8SBCrQZ06Bi0pr%2FTiSC52U1g%2BlhXYttdJB4GUdOvaxR8n6PwMS7HuAtDJUui8GKWK%2F9t4OON3qhF2cBt%2BnV%2BDg8bDMZkQ%2FAt5blvIlg6rrlCu0cYko4ojb281AU%3D&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3Bfilename%3DWarframe-overview-2018-02-11.csv&X-Amz-Signature=49cc07cbd9d753b00315b66f49b9e4788570062ff3bd956288ab4f164cf96708\",\"type\":\"overview_v2\",\"date_range\":{\"started_at\":\"2018-01-01T00:00:00Z\",\"ended_at\":\"2018-03-01T00:00:00Z\"}}]}";
        private readonly string GetExtensionAnalyticsResponse = "{\"data\":[{\"extension_id\":\"abcdefgh\",\"URL\":\"https://twitch-piper-reports.s3-us-west-2.amazonaws.com/games/66170/overview/1518307200000.csv?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=ASIAJP7WFIAF26K7BC2Q%2F20180222%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20180222T220651Z&X-Amz-Expires=60&X-Amz-Security-Token=FQoDYXdzEE0aDLKNl9aCgfuikMKI%2ByK3A4e%2FR%2B4to%2BmRZFUuslNKs%2FOxKeySB%2BAU87PBtNGCxQaQuN2Q8KI4Vg%2Bve2x5eenZdoH0ZM7uviM94sf2GlbE9Z0%2FoJRmNGNhlU3Ua%2FupzvByCoMdefrU8Ziiz4j8EJCgg0M1j2aF9f8bTC%2BRYwcpP0kjaZooJS6RFY1TTkh659KBA%2By%2BICdpVK0fxOlrQ%2FfZ6vIYVFzvywBM05EGWX%2F3flCIW%2BuZ9ZxMAvxcY4C77cOLQ0OvY5g%2F7tuuGSO6nvm9Eb8MeMEzSYPr4emr3zIjxx%2Fu0li9wjcF4qKvdmnyk2Bnd2mepX5z%2BVejtIGBzfpk%2Fe%2FMqpMrcONynKoL6BNxxDL4ITo5yvVzs1x7OumONHcsvrTQsd6aGNQ0E3lrWxcujBAmXmx8n7Qnk4pZnHZLgcBQam1fIGba65Gf5Ern71TwfRUsolxnyIXyHsKhd2jSmXSju8jH3iohjv99a2vGaxSg8SBCrQZ06Bi0pr%2FTiSC52U1g%2BlhXYttdJB4GUdOvaxR8n6PwMS7HuAtDJUui8GKWK%2F9t4OON3qhF2cBt%2BnV%2BDg8bDMZkQ%2FAt5blvIlg6rrlCu0cYko4ojb281AU%3D&X-Amz-SignedHeaders=host&response-content-disposition=attachment%3Bfilename%3Dextabcd-overview-2018-03-12.csv&X-Amz-Signature=49cc07cbd9d753b00315b66f49b9e4788570062ff3bd956288ab4f164cf96708\"}]}";
    }
}
