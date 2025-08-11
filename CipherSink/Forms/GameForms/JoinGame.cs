using CipherSink.Models.GameLogic;
using CipherSink.Models.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CipherSink.Forms.GameForms
{
    public partial class JoinGame : Form
    {
        public JoinGame()
        {
            InitializeComponent();
        }

        private void BtnJoinGame_Click(object sender, EventArgs e)
        {
            Player player1 = new Player("Bob");

            TcpPeer peer = new TcpPeer(player1.Rsa);

            Game game = new Game(peer, player1, false);

            game.HostIp = TxtBxHostIp.Text;

            var placeShipsForm = new PlaceShips(game);
            placeShipsForm.ShowDialog();
        }
    }
}
