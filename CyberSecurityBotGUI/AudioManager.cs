using System;
using System.Media;
using System.Windows.Forms;

namespace CyberSecurityBotGUI
{
    public class AudioManager
    {
        public void PlayGreeting()
        {
            try
            {
                SoundPlayer player =
                    new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}