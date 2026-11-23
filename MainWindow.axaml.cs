using Avalonia.Controls;
using System.Collections.Generic;
using Avalonia.Interactivity;
using System;

namespace IlkArayuzProjem;

public partial class MainWindow : Window
{
    public void ListBoxListele()
    {
        KomutListesi.Items.Clear();
        foreach (var komut in komutlar)
        {
            KomutListesi.Items.Add(komut);
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        ListBoxListele();
    }
    public List<string> komutlar = new List<string> { "Ping At", "Port Tara", "Servis Durumu", "Log Temizle" };
    private void KomutListesi_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (KomutListesi.SelectedItem is not string secili)
        {
            return;
        }
        durumYazisi.Text=secili=="Log Temizle"? "Loglar Sıfırlandı!":$"Seçilen İşlem : {secili}";
    }
    private void TemizleButonu_Click(object? sender, RoutedEventArgs e)
    {
        KomutListesi.SelectedItem = null;
        durumYazisi.Text = "Seçim Temizlendi.";
    }
    private void EkleButonu_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            if(!string.IsNullOrWhiteSpace(YeniKomutKutusu.Text))
            {
                komutlar.Add(YeniKomutKutusu.Text);
            }
        }
        catch (Exception ex)
        {
            durumYazisi.Text = $"Hata: {ex.Message}";
        }
        finally
        {
            
            ListBoxListele();
            YeniKomutKutusu.Text = string.Empty;
        }
    }

}