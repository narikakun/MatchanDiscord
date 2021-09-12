using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = DiscordRPC.Button;

namespace MatchanDiscord
{
    public partial class Form1 : Form
    {
		public DiscordRpcClient client;

		private static RichPresence presence = new RichPresence()
		{
			Details = "まっちゃんに感染なう",
			State = "まちゃウイ製作委員会",
			Assets = new Assets()
			{
				LargeImageKey = "67ea35031cae9961",
				LargeImageText = "まっちゃんだよ！",
				SmallImageKey = "e002d5a2dd18e24db672b017a6865cb3"
			},
			Party = new Party()
			{
				ID = Secrets.CreateFriendlySecret(new Random()),
				Max = 114514,
				Size = 1919,
				Privacy = Party.PrivacySetting.Public
			},
			Timestamps = Timestamps.FromTimeSpan(114514)
		};

		public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new DiscordRpcClient("886522791912947722");
			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
			presence.Secrets = new Secrets()
			{
				JoinSecret = "join_matchaan",
				SpectateSecret = "gahaha"
			}; ;
			client.RegisterUriScheme();
			client.SetSubscription(EventType.Join | EventType.Spectate | EventType.JoinRequest);
			client.SetPresence(presence);
			client.Initialize();
		}
	}
}
