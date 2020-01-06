namespace Carrosse
{
    public class Son
    {
        private System.Media.SoundPlayer player;
        public Son(string cheminFichier)
        {
            player = new System.Media.SoundPlayer(@"c:\mywavfile.wav");
        }

        public void Joue()
        {
            player.Play();
        }
    }
}