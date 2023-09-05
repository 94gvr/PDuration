using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PDuration
{
    class Get
    {
        public static string GetPlaylistDuration(string id)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = APIData.APIKey,
                ApplicationName = "YouTube Playlist Duration Calculator"
            });

            var playlistItemsRequest = youtubeService.PlaylistItems.List("snippet");
            playlistItemsRequest.PlaylistId = id;
            var playlistItemsResponse = playlistItemsRequest.Execute();

            TimeSpan totalDuration = TimeSpan.Zero;

            foreach (var playlistItem in playlistItemsResponse.Items)
            {
                string videoId = playlistItem.Snippet.ResourceId.VideoId;

                var videoRequest = youtubeService.Videos.List("contentDetails");
                videoRequest.Id = videoId;
                var videoResponse = videoRequest.Execute();

                string duration = videoResponse.Items[0].ContentDetails.Duration;
                TimeSpan videoDuration = XmlConvert.ToTimeSpan(duration);

                totalDuration += videoDuration;
            }

            string formattedDuration = string.Format("{0:D2}:{1:D2}:{2:D2}",
                totalDuration.Hours, totalDuration.Minutes, totalDuration.Seconds);

            return formattedDuration;
        }
    }
}
