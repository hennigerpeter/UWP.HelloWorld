using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace UWP.HelloWorld
{
  /// <summary>
  /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Welcomes the User with a short text and SpeechSynthesis.
    /// There is actually no MVVM implentend in this rudimental App.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void button_Click(object sender, RoutedEventArgs e)
    {
      if (txtbox.Text != "")
        txtblock.Text = "Hallo " + txtbox.Text + "!";
      else
        txtblock.Text = "Du hast keinen Namen angegeben.";

      MediaElement mediaElement = new MediaElement();
      var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
      Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(txtblock.Text);
      mediaElement.SetSource(stream, stream.ContentType);
      mediaElement.Play();
    }
  }
}
